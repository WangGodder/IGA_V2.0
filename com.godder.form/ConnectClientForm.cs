using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using IGAv2._0.com.godder.animal;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace IGAv2._0.com.godder.form
{
    public partial class ConnectClientForm : Form
    {
        private AnimalFormAbstract animalForm;
        private Socket socket;
        private IPAddress targetIP;
        private int port;
        private Thread clientThread;
        private Thread infoThread;
        private int listBoxIndex = -1;
        public ConnectClientForm(AnimalFormAbstract animalForm)
        {
            this.animalForm = animalForm;
            InitializeComponent();
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            ComboBox.CheckForIllegalCrossThreadCalls = false;
            TextBox.CheckForIllegalCrossThreadCalls = false;
            Button.CheckForIllegalCrossThreadCalls = false;
            foreach (string history in animalForm.connectHistory)
            {
                comboBox1.Items.Add(history.Split(':')[0]);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (portTextBox.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    targetIP = IPAddress.Parse(comboBox1.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("wrong ip format");
                    comboBox1.Text = "";
                    return;
                }
                try
                {
                    port = Convert.ToInt32(portTextBox.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Port must be an integer");
                    portTextBox.Clear();
                    return;
                }
                connectButton.Enabled = true;
            }
        }

        private void portTextBox_TextChanged(object sender, EventArgs e)
        {
            if (portTextBox.Text != "" && comboBox1.Text != "")
            {
                try
                {
                    targetIP = IPAddress.Parse(comboBox1.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("wrong ip format");
                    comboBox1.Text = "";
                    return;
                }
                try
                {
                    port = Convert.ToInt32(portTextBox.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Port must be an integer");
                    portTextBox.Clear();
                    return;
                }
                connectButton.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            if (index >= 0)
            {
                portTextBox.Text = animalForm.connectHistory[index].Split(':')[1];
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = portTextBox.Enabled = keyTextBox.Enabled = connectButton.Enabled= false;
            listBox1.Items.Clear();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (animalForm.clientipV6)
            {
                socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
            }
            IPEndPoint point = new IPEndPoint(this.targetIP, this.port);
            try
            {
                socket.Connect(point);
                richTextBox1.AppendText(getDateTime() + ": Connecting server: verify key...\n");
            }
            catch 
            {
                richTextBox1.AppendText(getDateTime() + ": Connect failure: cannot find target\n\n");
                comboBox1.Enabled = portTextBox.Enabled = keyTextBox.Enabled = connectButton.Enabled = true;
                return;
            }

            clientThread = new Thread(verify);
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        private void verify()
        {
            try
            {
                byte[] buffer = new byte[1024];
                socket.Receive(buffer);
                bool isKey = BitConverter.ToBoolean(buffer, 0);
                if (isKey)
                {
                    string key = keyTextBox.Text;
                    buffer = Encoding.UTF8.GetBytes(key);
                    socket.Send(buffer);
                }
            }
            catch
            {
                richTextBox1.AppendText(getDateTime() + ": Connect failure: key is wrong \n\n");
                comboBox1.Enabled = portTextBox.Enabled = keyTextBox.Enabled = connectButton.Enabled = false;
                return;
            }

            if (!animalForm.connectHistory.Contains(comboBox1.Text + ":" + port.ToString()))
            {
                animalForm.connectHistory.Add(comboBox1.Text + ":" + port.ToString());
            }
            richTextBox1.AppendText(getDateTime() + ": connect successfully \n");
            infoThread = new Thread(exchangeInfo);
            infoThread.IsBackground = true;
            infoThread.Start();
        }

        private void exchangeInfo()
        {
            byte[] buffer = new byte[1024 * 1024];
            try
            {
                socket.Receive(buffer, 4, 0);
                int fileNum = BitConverter.ToInt32(buffer, 0);
                // receive filename
                for (int i = 0; i < fileNum; i++)
                {
                    socket.Receive(buffer, 4, 0);
                    int length = BitConverter.ToInt32(buffer, 0);
                    int strLength = socket.Receive(buffer, length, 0);
                    string filename = Encoding.UTF8.GetString(buffer, 0, strLength);
                    listBox1.Items.Add(filename);
                }
                richTextBox1.AppendText(getDateTime() + ": file information receive completed\n");
            }
            catch
            {
                richTextBox1.AppendText(getDateTime() + ": Connect supend. Server may close connection.\n\n");
                socket.Close();
                connectButton.Enabled = true;
                return;
            }
            listBox1.Enabled = true;
        }

        private string getDateTime()
        {
            return DateTime.Now.ToString();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            Thread readThread = new Thread(readFile);
            readThread.IsBackground = true;
            readThread.Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBoxIndex = listBox1.SelectedIndex;
            if (this.listBoxIndex >= 0)
            {
                readButton.Enabled = true;
            }
        }

        private void readFile()
        {
            readButton.Enabled = false;
            try
            {
                byte[] selectedIndex = new byte[4];
                selectedIndex = BitConverter.GetBytes(this.listBoxIndex);
                socket.Send(selectedIndex);
                selectedIndex = null;

                byte[] isGoat = new byte[1];
                socket.Receive(isGoat);
                if (!BitConverter.ToBoolean(isGoat, 0))
                {
                    richTextBox1.AppendText(getDateTime() + ": Type wrong\n");
                    listBox1.Items.RemoveAt(this.listBoxIndex);
                    readButton.Enabled = true;
                    return;
                }

                // receive animal
                byte[] animalLength = new byte[4];
                socket.Receive(animalLength);
                byte[] buffer = new byte[1024 * 1024];
                int length = socket.Receive(buffer, BitConverter.ToInt32(animalLength, 0), 0);
                Object obj = Deserialize(buffer);
                AnimalAbstract animal = (AnimalAbstract)obj;
                // receive image
                byte[] imgNum = new byte[4];
                socket.Receive(imgNum, 4, 0);
                for (int i = 0; i < BitConverter.ToInt32(imgNum, 0); i++)
                {
                    receiveImg();
                    richTextBox1.AppendText(getDateTime() + ": picture receive ..." + (i + 1) + "/" + BitConverter.ToInt32(imgNum, 0) + "\n");
                }

                richTextBox1.AppendText(getDateTime() + ": receive file successfully\n");
                animalForm.animal = animal;
                animalForm.loadAnimalInfo();
                listBox1.Enabled = true;
                readButton.Enabled = true;
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show("client:" + ex.Message + ex.Source);
                richTextBox1.AppendText(getDateTime() + ": Server close connection.\n");
                socket.Close();
                connectButton.Enabled = true;
            }
           
        }

        private void receiveImg()
        {
            // get img length (long int)
            byte[] buffer = new byte[8];
            socket.Receive(buffer, buffer.Length, 0);
            
            int length = BitConverter.ToInt32(buffer, 0);
            buffer = null;
            if (length == 0) return;
            receiveFile(length);
        }

        private void receiveFile(int length)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[5 * 1024];
            int times = length / buffer.Length;
            int count = 0;
            int readed = 0;
            while (count < times)
            {
                int byteRead = socket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                ms.Write(buffer, 0, byteRead);
                count++;
                readed += byteRead;
                Thread.Sleep(1);
            }
            int readBytes = socket.Receive(buffer, 0, length - buffer.Length * count, 0);
            ms.Write(buffer, 0, readBytes);
            readed += readBytes;
            if (readed != length)
            {
                readBytes = socket.Receive(buffer, 0, length - readBytes, 0);
                ms.Write(buffer, 0, readBytes);
                readed += readBytes;
                MessageBox.Show(readed + "");
            }
            byte[] nameLength = new byte[4];
            socket.Receive(nameLength, 4, 0);
            byte[] nameBuffer = new byte[1024];
            readBytes = socket.Receive(nameBuffer, BitConverter.ToInt32(nameLength, 0), 0);
            string name = Encoding.UTF8.GetString(nameBuffer, 0, readBytes);
            Bitmap image = new Bitmap(ms);
            image.Save(name);
        }

        private static object Deserialize(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(data, 0, data.Length);
            data = null;
            return formatter.Deserialize(ms);
        }

        private void ConnectClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (socket != null)
            {
                socket.Close();
                clientThread.Abort();
            }
        }

        private void connectButton_EnabledChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = portTextBox.Enabled = keyTextBox.Enabled = connectButton.Enabled;
        }
    }
}
