using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace IGAv2._0.com.godder.form
{
    public partial class socketForm : Form
    {
        private AnimalFormAbstract animalForm;
        private bool serverIPV6;
        private bool clientIPV6;
        private int port;
        private int listen;
        public socketForm(AnimalFormAbstract animalForm)
        {
            InitializeComponent();
            this.animalForm = animalForm;
            this.radioButton1.Checked = !animalForm.serveripV6;
            this.radioButton3.Checked = !animalForm.clientipV6;
            if (animalForm.socketKey != "" && animalForm.socketKey != null)
            {
                checkBox1.Checked = true;
            }
            this.textBox2.Text = animalForm.port.ToString();
            this.linkLabel1.Text = animalForm.socketUrl;
            if (animalForm.socketUrl == "")
            {
                this.linkLabel1.Text = animalForm.saveUrl;
            }
            comboBox1.SelectedIndex = animalForm.listen;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = checkBox1.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = !radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = !radioButton2.Checked;
            serverIPV6 = radioButton2.Checked;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton4.Checked = !radioButton3.Checked;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton3.Checked = !radioButton4.Checked;
            clientIPV6 = radioButton4.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPGlobalProperties iPGlobal = IPGlobalProperties.GetIPGlobalProperties();
            foreach (IPEndPoint point in iPGlobal.GetActiveTcpListeners())
            {
                if (point.Port == port)
                {
                    MessageBox.Show("port: " + port + " is in used.", "warn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Clear();
                    return;
                }
            }
            MessageBox.Show("port: " + port + " is not in used");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                port = Convert.ToInt32(textBox2.Text);
                if (port > 1000) checkButton.Enabled = true;
            }
            catch { }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            animalForm.connectHistory.Clear();
            foreach (XElement element in animalForm.document.Root.Element("connectHistory").Elements())
            {
                element.Remove();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Directory.Exists(linkLabel1.Text))
            {
                MessageBox.Show("Directory doesn't exist");
                return;
            }
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                linkLabel1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            animalForm.serveripV6 = this.serverIPV6;
            animalForm.clientipV6 = this.clientIPV6;
            animalForm.socketKey = this.textBox1.Text;
            animalForm.socketUrl = linkLabel1.Text;
            animalForm.listen = this.listen;
            this.Close();
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listen = comboBox1.SelectedIndex;
        }
    }
}
