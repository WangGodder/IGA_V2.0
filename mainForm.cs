using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using IGAv2._0.com.godder.form;

namespace IGAv2._0
{
    public partial class mainForm : Form
    {
        private bool isMultwindows = true;
        private int multwindowNum = 10;
        private int currentWindowNum = 0;
        private string isCloseWindowString = "";
        private List<Form> forms = new List<Form>();
        public string currentUrl;
        public mainForm()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
            EnglishToolStripMenuItem.Checked = true;
            this.isCloseWindowString = "Close the redundant windows? (save the first window)";
        }

        private void poluToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goatPictureBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (currentWindowNum < multwindowNum)
            {
                GoatForm newForm = new GoatForm(this);
                forms.Add(newForm);
                currentWindowNum++;
                newForm.Show();
            }
            else
            {
                this.forms.First<Form>().Show();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void hideWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void showContextMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void exitContextMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.notifyIcon1.Visible = true;
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            this.Controls.Clear();
            InitializeComponent();
            ChineseToolStripMenuItem.Checked = true;
            multipleWindowsToolStripMenuItem.Checked = isMultwindows;
            this.isCloseWindowString = "关闭多余窗口？(保留第一个窗口)";
        }

        private void 英文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this.Controls.Clear();
            InitializeComponent();
            EnglishToolStripMenuItem.Checked = true;
            multipleWindowsToolStripMenuItem.Checked = isMultwindows;
            this.isCloseWindowString = "Close redundant windows? (Save the first window)";
        }

        private void multipleWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isMultwindows = !isMultwindows;
            multipleWindowsToolStripMenuItem.Checked = isMultwindows;
            if (isMultwindows)
            {
                this.multwindowNum = 10;
            }
            if (!isMultwindows)
            {
                this.multwindowNum = 1;
                if (currentWindowNum > 1)
                {
                    DialogResult isCloseWindows = MessageBox.Show(isCloseWindowString, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (isCloseWindows == DialogResult.Yes)
                    {
                        foreach (Form form in this.forms)
                        {
                            if (form != forms.First())
                            {
                                form.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
