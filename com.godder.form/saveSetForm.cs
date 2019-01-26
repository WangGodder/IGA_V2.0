using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Xml.Linq;

namespace IGAv2._0.com.godder.form
{
    public partial class saveSetForm : Form
    {
        private AnimalFormAbstract superForm;
        public saveSetForm(AnimalFormAbstract superForm)
        {
            this.superForm = superForm;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(superForm.language);
            InitializeComponent();
            linkLabel1.Text = superForm.saveUrl;
            linkLabel2.Text = superForm.imgUrl;
            enctyptyCheckBox.Checked = superForm.fileEncrypt;
            textBox1.Text = superForm.fileKey;
            autoVerifyCheckBox.Checked = superForm.autoVerify;
            textBox2.Text = superForm.defaultKey;
        }

        private void enctyptyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            keyPanel1.Visible = enctyptyCheckBox.Checked;
            if (!enctyptyCheckBox.Checked)
            {
                textBox1.Text = null;
            }
        }

        private void autoVerifyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            keyPanel2.Visible = autoVerifyCheckBox.Checked;
            if (!autoVerifyCheckBox.Checked)
            {
                textBox2.Text = null;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = default(char);
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.PasswordChar = '●';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.PasswordChar = default(char);
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.PasswordChar = '●';
            }
        }

        private void changeButton1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folder = folderBrowserDialog.SelectedPath;
                linkLabel1.Text = folder;
            }
        }

        private void changeButton2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folder = folderBrowserDialog.SelectedPath;
                linkLabel2.Text = folder;
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!Directory.Exists(linkLabel2.Text))
            {
                MessageBox.Show("Directory doesn't exist");
                return;
            }
            System.Diagnostics.Process.Start(linkLabel2.Text);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            superForm.saveUrl = linkLabel1.Text;
            superForm.openUrl = linkLabel1.Text;
            XElement root = superForm.document.Root;
            root.Element("saveUrl").SetValue(linkLabel1.Text);
            root.Element("openUrl").SetValue(linkLabel1.Text);
            root.Element("imgUrl").SetValue(linkLabel2.Text);
            root.Element("isSaveKey").SetValue(enctyptyCheckBox.Checked);
            root.Element("saveKey").SetValue(textBox1.Text);
            root.Element("autoVerify").SetValue(autoVerifyCheckBox.Checked);
            root.Element("defaultKey").SetValue(textBox2.Text);
            this.Close();
            this.Dispose();
        }
    }
}
