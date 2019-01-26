using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.IO;
using IGAv2._0.com.godder.animal;
using System.Runtime.Serialization.Formatters.Binary;

namespace IGAv2._0.com.godder.form
{
    public partial class ConnectServerForm : Form
    {
        public string key = null;
        public string fileDirectory;
        public int port;
        public int listenBackLong;
        public Socket socket = null;
        public IPAddress iPAddress;
        public int selectedIndex = -1;
        Thread listenThread;
        public Dictionary<string, Socket> clientDictionary = new Dictionary<string, Socket>();
        public List<Thread> clientThread = new List<Thread>();
        public string portWarn = "Port has been occupied. Please change other port";
        public string wrongKeyMsg = "Key is wrong, connection failure";
        public ConnectServerForm(int port, int listenBackLong, string fileDirectory, string key = null, bool IPV6 = false )
        {
            InitializeComponent();

            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            ListBox.CheckForIllegalCrossThreadCalls = false;
            this.key = key;
            this.fileDirectory = fileDirectory;
            iPAddress = loadInfo(IPV6);
            this.port = port;
            portTextBox.Text = port.ToString();
            this.listenBackLong = listenBackLong;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                IPEndPoint point = new IPEndPoint(iPAddress, port);
                socket.Bind(point);
            }
            catch (Exception ex)
            {
                MessageBox.Show(port + portWarn);
                Debug.WriteLine(ex.Message);
                return;
            }
            socket.Listen(listenBackLong);
            richTextBox.AppendText(GetCurrentTime() + ": Listen successfully\n");

            listenThread = new Thread(listen);
            listenThread.IsBackground = true;
            listenThread.Start();

        }

        private void listen()
        {
            Socket connection = null;
            while (true)
            {
                try
                {
                    connection = socket.Accept();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Thread.Sleep(5000);
                    continue;
                }
                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                richTextBox.AppendText("\n" + GetCurrentTime() + ": " + remoteEndPoint + ":\t connecting...\n");

                Thread thread = new Thread(verify);
                thread.IsBackground = true;
                thread.Start(connection);           
            }
        }

        private void verify(Object conn)
        {
            Socket connection = conn as Socket;
            string remoteEndPoint = connection.RemoteEndPoint.ToString();
            if (this.key == null)
            {
                byte[] isKey = { Convert.ToByte(false) };
                connection.Send(isKey);
            }
            else
            {
                byte[] isKey = { Convert.ToByte(true) };
                connection.Send(isKey);
                try
                {
                    if (receiveInfo(connection, 1024) != this.key)
                    {
                        sendMsg(connection, wrongKeyMsg);
                        richTextBox.AppendText(GetCurrentTime() + ": " + wrongKeyMsg + "\n");
                        connection.Close();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            richTextBox.AppendText(GetCurrentTime() + ": Connection successfully \n");
            clientDictionary.Add(remoteEndPoint, connection);
            listBox1.Items.Add(remoteEndPoint);

            Thread thread = new Thread(exchangeInfo);
            thread.IsBackground = true;
            clientThread.Add(thread);
            thread.Start(connection);
        }

        private void exchangeInfo(Object conn)
        {
            Socket connection = conn as Socket;
            DirectoryInfo folder = new DirectoryInfo(this.fileDirectory);
            byte[] bytes = { Convert.ToByte(folder.GetFiles("*.iga").Count()) };
            connection.Send(bytes);
            try
            {
                foreach (FileInfo file in folder.GetFiles("*.iga"))
                {
                    bytes = Encoding.UTF8.GetBytes(file.Name);
                    byte[] length = BitConverter.GetBytes(bytes.Length);
                    connection.Send(length);
                    connection.Send(bytes);
                }
            } catch
            {
                richTextBox.AppendText(GetCurrentTime() + ": client: " + connection.RemoteEndPoint.ToString() + " close connection");
                clientDictionary.Remove(connection.RemoteEndPoint.ToString());
                listBox1.Items.Remove(connection.RemoteEndPoint.ToString());
            }
            
            while (true)
            {
                byte[] buffer = new byte[4];
                try
                {
                    connection.Receive(buffer);
                    int index = BitConverter.ToInt32(buffer, 0);
                    string filename = folder.GetFiles("*.iga")[index].FullName;
                    this.richTextBox.AppendText(GetCurrentTime() + ": request file: " + filename + "\n");
                    Goat goat = null;
                    try
                    {
                        goat = Goat.load(filename);
                    }
                    catch (Exception)
                    {
                        buffer = BitConverter.GetBytes(false);
                        connection.Send(buffer);
                        continue;
                    }
                    buffer = BitConverter.GetBytes(true);
                    connection.Send(buffer);
                    List<string> imgList = new List<string>(goat.imgUrl);
                    string datetimeStr = (DateTime.Now.Subtract(DateTime.Parse("2018-1-1"))).TotalMilliseconds.ToString().Split('.')[0];
                    for (int i = 0; i < goat.imgUrl.Count; i++)
                    {
                        goat.imgUrl[i] = @"cache/picture/" + datetimeStr + i + "." + goat.imgUrl[i].Split('.').Last();
                    }
                    buffer = serialize(goat);
                    byte[] animalLength = BitConverter.GetBytes(buffer.Length);
                    connection.Send(animalLength);
                    connection.Send(buffer);
                    buffer = BitConverter.GetBytes(imgList.Count);
                    connection.Send(buffer);
                    
                    for (int i = 0; i < imgList.Count; i++)
                    {
                        byte[] length;
                        if (!File.Exists(imgList[i]))
                        {
                            richTextBox.AppendText(GetCurrentTime() + ": Warn: " + imgList[i] + " doesn't exist! \n");
                            length = BitConverter.GetBytes(0L);
                            connection.Send(length, 8, 0);
                            continue;
                        }
                        FileInfo fileInfo = new FileInfo(imgList[i]);
                        length = BitConverter.GetBytes(fileInfo.Length);
                        byte[] name = Encoding.UTF8.GetBytes(goat.imgUrl[i]);
                        byte[] nameLength = BitConverter.GetBytes(name.Length);
                        connection.SendFile(imgList[i], length, nameLength, 0);
                        connection.Send(name);
                        richTextBox.AppendText(GetCurrentTime() + ": send image: " + imgList[i] + "\t...\n");
                        Thread.Sleep(100);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break ;
                }
            }
        }

        private void sendCallBack(IAsyncResult iar)
        {
            Socket connection = (Socket)iar.AsyncState;
            if (iar.IsCompleted)
            {
                connection.EndSendTo(iar);
            }
        }

        private string receiveInfo(Socket conn, int bufferSize)
        {
            byte[] buffer = new byte[bufferSize];
            int length = conn.Receive(buffer);
            string str = Encoding.UTF8.GetString(buffer, 0, length);
            return str;
        }

        private void sendMsg(Socket conn, string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            conn.Send(bytes);
        }

        private IPAddress loadInfo(bool IPV6)
        {
            string name = Dns.GetHostName();
            IPHostEntry iPHostEntry = Dns.GetHostEntry(name);
            IPAddress iPAddress = iPHostEntry.AddressList.FirstOrDefault(a => a.AddressFamily.ToString().Equals("InterNetwork"));
            if (IPV6)
            {
                iPAddress = iPHostEntry.AddressList.FirstOrDefault(a => a.AddressFamily.ToString().Equals("InterNetworkV6"));
            }
            ipTextBox.Text = iPAddress.ToString();
            return iPAddress;
        }

        private string GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime.ToString();
        }

        private byte[] serialize(object data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, data);
            return stream.GetBuffer();
        }

        private class CallBackObject
        {
            public Socket conn { get; set; }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedIndex = listBox1.SelectedIndex;
            breakButton.Enabled = true;
            if (listBox1.SelectedIndex < 0)
            {
                breakButton.Enabled = false;
            }
        }

        private void breakButton_Click(object sender, EventArgs e)
        {
            int index = this.selectedIndex;
            string ipStr = (listBox1.Items[index] as string);
            clientDictionary[ipStr].Close();
            richTextBox.AppendText(GetCurrentTime() + ": " + ipStr + " has close by server.\n");
            clientThread[index].Abort();
            clientThread.RemoveAt(index);
            clientDictionary.Remove(ipStr);
            listBox1.Items.RemoveAt(index);
        }

        private void ConnectServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            richTextBox.AppendText(GetCurrentTime() + ": Server close.");
            try
            {
                string datetimeStr = (DateTime.Now.Subtract(DateTime.Parse("2018-1-1"))).TotalMilliseconds.ToString().Split('.')[0];
                string path = @"cache\log\" + datetimeStr + ".log";
                FileStream fs = File.Create(path);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(richTextBox.Text);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show( ex.Message);
            }
            if (clientDictionary.Count > 0)
            {
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    Thread.Sleep(10);
                }
                catch { }
            }
            try
            {
                listenThread.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.socket.Dispose();
            socket = null;
            this.Dispose();
        }
    }
}
