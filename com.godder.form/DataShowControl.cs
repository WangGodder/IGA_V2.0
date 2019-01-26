using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IGAv2._0.com.godder.form
{
    public partial class DataShowControl : UserControl
    {
        private static int id = 0;
        private List<string> dataList = new List<string>();
        public DataShowControl(string title)
        {
            InitializeComponent();
            this.label.Text = title;
            this.button.Name = "delete_" + id.ToString();
            this.Name = "dataShowControl_" + id++.ToString();
        }

        public DataShowControl(string title, string data)
        {
            InitializeComponent();
            this.label.Text = title;
            this.button.Name = "delete_" + id.ToString();
            this.Name = "dataShowControl_" + id++.ToString();
            addData(data);
        }

        public void addData(string data)
        {
            this.panel.Height += 40;
            this.Height += 40;
            this.button.Location = new Point(button.Location.X, button.Location.Y + 40);
            RichTextBox textBox = new RichTextBox();
            textBox.Size = new Size(110, 30);
            textBox.Text = data;
            textBox.Name = "richTextBox_" + panel.Controls.Count.ToString();
            this.panel.Controls.Add(textBox);
            textBox.Location = new Point(0, 40 * (panel.Controls.Count - 1));
            textBox.Visible = true;
            textBox.Enabled = true;
            textBox.TextChanged += richTextBox_TextChanged;
            this.dataList.Add(data);
        }

        public void deleteDataAt(int i)
        {
            if (i > this.dataList.Count)
            {
                return;
            }
            for (int j = i; j < dataList.Count -1;)
            {
                swapData(j, ++j);
            }
            panel.Controls.RemoveAt(panel.Controls.Count - 1);
            dataList.RemoveAt(dataList.Count - 1);
            panel.Height -= 40;
            this.Height -= 40;
            this.button.Location = new Point(button.Location.X, button.Location.Y - 40);
        }

        public string getDataAt(int i)
        {
            if (i > this.dataList.Count)
            {
                return null;
            }
            return this.dataList.ElementAt<string>(i);
        }

        public void changeUnit(double multiple)
        {
            foreach (RichTextBox textBox in panel.Controls)
            {
                try
                {
                    double value = Convert.ToDouble(textBox.Text);
                    textBox.Text = (value * multiple).ToString();
                }
                catch (Exception)
                {
                }
            }
        }

        public void swapData(int index1, int index2)
        {
            RichTextBox textBox1 = (panel.Controls.Find("richTextBox_" + index1.ToString(), false)[0] as RichTextBox);
            RichTextBox textBox2 = (panel.Controls.Find("richTextBox_" + index2.ToString(), false)[0] as RichTextBox);
            if (textBox1 == null || textBox2 == null)
            {
                MessageBox.Show("A mistake has happened.");
                return;
            }
            string swap = textBox1.Text;
            textBox1.Text = textBox2.Text;
            textBox2.Text = swap;

        }

        private void button_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((sender as RichTextBox).Name.Split('_').Last());
            this.dataList.RemoveAt(index);
            this.dataList.Insert(index, (sender as RichTextBox).Text);
        }

        private void DataShowControl_Enter(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.Fixed3D;
        }

        private void DataShowControl_Leave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
        }
    }
}
