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
    public partial class UserDefinedImgeForm : Form
    {
        private string url;
        private string overwriteWarn = "Are you sure to overwrite original file?";
        private Bitmap bitmap;
        private List<Bitmap> bitmapList = new List<Bitmap>();
        private Brush newBrush;
        private Color color = Color.Black;
        private Font font = new Font("微软雅黑", 18.0f);
        private string text;
        private int border = 1;
        private Point point;

        public UserDefinedImgeForm(string url, string language)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
            InitializeComponent();
            this.url = url;
            FileStream fs = new FileStream(url, FileMode.Open);
            Bitmap bmp = new Bitmap(fs);
            bitmap = new Bitmap(450, 450);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(225, 225, 225));
            graphics.DrawImage(bmp, new System.Drawing.Rectangle(0, 0, 450, 450),
                    new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                    System.Drawing.GraphicsUnit.Pixel);
            pictureBox.Image = bitmap;
            bitmapList.Add(bitmap);
            Color col = Color.FromArgb(51, 51, 51);
            newBrush = new SolidBrush(col);
            fs.Close();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            text = richTextBox1.Text;
            pictureBox.MouseClick += fontInsert;
        }

        private void fontInsert(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                Bitmap newBitmap = new Bitmap(bitmapList.Last());
                bitmapList.Add(newBitmap);
                Graphics graphics = Graphics.FromImage(newBitmap);
                float X = e.Location.X;
                float Y = e.Location.Y;
                this.newBrush = new SolidBrush(color);
                graphics.DrawString(text, font, newBrush, X, Y);
                pictureBox.MouseClick -= fontInsert;
                pictureBox.Image = bitmapList.Last();
                undoButton.Enabled = true;
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            bitmapList[bitmapList.Count - 1].Dispose();
            this.bitmapList.RemoveAt(bitmapList.Count - 1);
            this.pictureBox.Image = bitmapList.Last();
            if (bitmapList.Count <= 1)
            {
                undoButton.Enabled = false;
            }
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.font = fontDialog.Font;
                fontLabel.Text = font.FontFamily.Name;
                fontSytleLabel.Text = font.Style.ToString();
                fontSizeLabel.Text = font.Size.ToString();
            }
        }

        private void colorButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.color = colorDialog.Color;
                this.colorLabel.Text = color.Name;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void breadthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.border = breadthComboBox.SelectedIndex;
        }

        private void printButton3_Click(object sender, EventArgs e)
        {
            pictureBox.MouseDown += firstPointGet;
            pictureBox.MouseUp += drawRectangle;
        }

        private void firstPointGet(Object sender, MouseEventArgs e)
        {
            this.point = e.Location;
            
        }

        private void drawRectangle(Object sender, MouseEventArgs e)
        {
            Point newPoint = e.Location;
            Bitmap newBitmap = new Bitmap(bitmapList.Last());
            bitmapList.Add(newBitmap);
            Graphics graphics = Graphics.FromImage(newBitmap);
            Pen pen = new Pen(this.color, this.border);
            graphics.DrawRectangle(pen, Math.Min(point.X, newPoint.X), Math.Min(point.Y, newPoint.Y), Math.Abs(newPoint.X - point.X), Math.Abs(newPoint.Y - point.Y));
            pictureBox.MouseUp -= drawRectangle;
            pictureBox.MouseDown -= firstPointGet;
            pictureBox.Image = bitmapList.Last();
            undoButton.Enabled = true;
        }

        private void printButton4_Click(object sender, EventArgs e)
        {
            pictureBox.MouseDown += firstPointGet;
            pictureBox.MouseUp += drawEllipse;
        }

        private void drawEllipse(object sender, MouseEventArgs e)
        {
            Point newPoint = e.Location;
            Bitmap newBitmap = new Bitmap(bitmapList.Last());
            bitmapList.Add(newBitmap);
            Graphics graphics = Graphics.FromImage(newBitmap);
            Pen pen = new Pen(this.color, this.border);
            graphics.DrawEllipse(pen, Math.Min(point.X, newPoint.X), Math.Min(point.Y, newPoint.Y), Math.Abs(newPoint.X - point.X), Math.Abs(newPoint.Y - point.Y));
            pictureBox.MouseUp -= drawEllipse;
            pictureBox.MouseDown -= firstPointGet;
            pictureBox.Image = bitmapList.Last();
            undoButton.Enabled = true;
        }

        private void printButton2_Click(object sender, EventArgs e)
        {
            pictureBox.MouseDown += firstPointGet;
            pictureBox.MouseUp += drawArrow;
        }

        private void drawArrow(object sender, MouseEventArgs e)
        {
            Point newPoint = e.Location;
            Bitmap newBitmap = new Bitmap(bitmapList.Last());
            bitmapList.Add(newBitmap);
            Graphics graphics = Graphics.FromImage(newBitmap);
            Pen pen = new Pen(this.color, this.border);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            graphics.DrawLines(pen, new Point[]{point, newPoint});
            pictureBox.MouseUp -= drawArrow;
            pictureBox.MouseDown -= firstPointGet;
            pictureBox.Image = bitmapList.Last();
            undoButton.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < bitmapList.Count; i++)
            {
                bitmapList[i].Dispose();
            }
            bitmapList.Clear();
            bitmapList.Add(bitmap);
            undoButton.Enabled = false;
            pictureBox.Image = bitmapList.Last();
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.InitialDirectory = url;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog.FileName.Split('.').Last())
                {
                    case "png": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png); break;
                    case "jpeg": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case "gif": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case "bmp": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    default: this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png); break;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(overwriteWarn, "Warn", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                switch (url.Split('.').Last())
                {
                    case "png": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png); break;
                    case "jpg": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case "jpeg": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case "gif": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case "bmp": this.bitmapList.Last().Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp); break;
                }
            }
        }
    }
}
