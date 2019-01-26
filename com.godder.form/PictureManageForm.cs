using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace IGAv2._0.com.godder.form
{
    public partial class PictureManageForm : Form
    {
        private AnimalFormAbstract superForm;
        private List<string> imgUrlList;
        private List<string> imgDescribeList;
        private int currentImg = 0;

        public PictureManageForm(AnimalFormAbstract superForm)
        {
            this.superForm = superForm;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(superForm.language);
            InitializeComponent();
            this.imgUrlList = new List<string>(superForm.animal.imgUrl);
            this.imgDescribeList = new List<string>(superForm.animal.imgDepict);
            initializePicture();
        }

        private void initializePicture()
        {
            foreach (string url in imgUrlList)
            {
                listBox.Items.Add(url.Split('\\').Last());
            }
            listBox.SelectedIndex = 0;
            richTextBox.Text = this.imgDescribeList.First();
            try
            {
                pictureBox.ImageLocation = this.imgUrlList.First();
            }
            catch (Exception)
            {
                MessageBox.Show(this.superForm.wrongUrlWarn);
                pictureBox.Image = null;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            superForm.animal.imgUrl = this.imgUrlList;
            superForm.animal.imgDepict = this.imgDescribeList;
            this.Close();
            this.Dispose();
        }

        private void canelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (currentImg < 0)
            {
                return;
            }
            this.imgDescribeList.RemoveAt(currentImg);
            this.imgDescribeList.Insert(currentImg, richTextBox.Text);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.imgDescribeList.RemoveAt(currentImg);
            this.imgUrlList.RemoveAt(currentImg);
            listBox.Items.RemoveAt(currentImg);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            this.imgUrlList = new List<string>(superForm.animal.imgUrl);
            this.imgDescribeList = new List<string>(superForm.animal.imgDepict);
            initializePicture();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentImg = listBox.SelectedIndex;
            button1.Enabled = button2.Enabled = false;
            if (currentImg >= 0)
            {
                deleteButton.Enabled = true;
            }
            if (currentImg > 0)
            {
                button1.Enabled = true;
            }
            if (currentImg < imgUrlList.Count - 1)
            {
                button2.Enabled = true;
            }
            if (imgUrlList.Count == 0)
            {
                pictureBox.ImageLocation = null;
                richTextBox.Text = "";
                return;
            }
            if (currentImg < 0)
            {
                richTextBox.Text = this.imgDescribeList.First();
                try
                {
                    pictureBox.ImageLocation = this.imgUrlList.First();
                }
                catch (Exception)
                {
                    MessageBox.Show(this.superForm.wrongUrlWarn);
                    pictureBox.Image = null;
                }
                deleteButton.Enabled = false;
                return;
            }
            try
            {
                pictureBox.ImageLocation = this.imgUrlList.ElementAt(currentImg);
            }
            catch (Exception)
            {
                MessageBox.Show(this.superForm.wrongUrlWarn);
                pictureBox.Image = null;
            }
            richTextBox.Text = this.imgDescribeList.ElementAt(currentImg);
        }

        private void swap(int index1, int index2)
        {
            string describe = imgDescribeList[index1];
            imgDescribeList[index1] = imgDescribeList[index2];
            imgDescribeList[index2] = describe;

            string image = imgUrlList[index1];
            imgUrlList[index1] = imgUrlList[index2];
            imgUrlList[index2] = image;

            object item = listBox.Items[index1];
            listBox.Items[index1] = listBox.Items[index2];
            listBox.Items[index2] = item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            swap(currentImg, currentImg - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            swap(currentImg, currentImg + 1);
        }
    }
}
