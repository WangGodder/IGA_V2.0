namespace IGAv2._0.com.godder.form
{
    partial class ConnectServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.breakButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(13, 13);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(330, 186);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(363, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(138, 184);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // breakButton
            // 
            this.breakButton.Enabled = false;
            this.breakButton.Font = new System.Drawing.Font("宋体", 10F);
            this.breakButton.Location = new System.Drawing.Point(363, 210);
            this.breakButton.Name = "breakButton";
            this.breakButton.Size = new System.Drawing.Size(138, 33);
            this.breakButton.TabIndex = 2;
            this.breakButton.Text = "break connection";
            this.breakButton.UseVisualStyleBackColor = true;
            this.breakButton.Click += new System.EventHandler(this.breakButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(12, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(231, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "port";
            // 
            // portTextBox
            // 
            this.portTextBox.Enabled = false;
            this.portTextBox.Font = new System.Drawing.Font("宋体", 12F);
            this.portTextBox.Location = new System.Drawing.Point(271, 210);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(72, 26);
            this.portTextBox.TabIndex = 3;
            // 
            // ipTextBox
            // 
            this.ipTextBox.Enabled = false;
            this.ipTextBox.Font = new System.Drawing.Font("宋体", 12F);
            this.ipTextBox.Location = new System.Drawing.Point(106, 210);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(119, 26);
            this.ipTextBox.TabIndex = 3;
            // 
            // ConnectServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 248);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.breakButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.richTextBox);
            this.Name = "ConnectServerForm";
            this.Text = "ConnectServerForm";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectServerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button breakButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.RichTextBox ipRichTextBox;
        private System.Windows.Forms.TextBox ipTextBox;
        public System.Windows.Forms.RichTextBox richTextBox;
        public System.Windows.Forms.ListBox listBox1;
    }
}