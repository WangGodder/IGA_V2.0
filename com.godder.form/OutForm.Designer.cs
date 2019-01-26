namespace IGAv2._0.com.godder.form
{
    partial class OutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutForm));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lengthComboBox = new System.Windows.Forms.ComboBox();
            this.weigthComboBox = new System.Windows.Forms.ComboBox();
            this.txtButton = new System.Windows.Forms.Button();
            this.wordButton = new System.Windows.Forms.Button();
            this.excelButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataPanel
            // 
            resources.ApplyResources(this.dataPanel, "dataPanel");
            this.dataPanel.Name = "dataPanel";
            // 
            // leftButton
            // 
            resources.ApplyResources(this.leftButton, "leftButton");
            this.leftButton.Name = "leftButton";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // rightButton
            // 
            resources.ApplyResources(this.rightButton, "rightButton");
            this.rightButton.Name = "rightButton";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "iga";
            this.openFileDialog.FileName = "openFileDialog";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            this.openFileDialog.Multiselect = true;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Maximum = 40;
            this.progressBar.Name = "progressBar";
            this.progressBar.Step = 1;
            // 
            // lengthComboBox
            // 
            this.lengthComboBox.FormattingEnabled = true;
            this.lengthComboBox.Items.AddRange(new object[] {
            resources.GetString("lengthComboBox.Items"),
            resources.GetString("lengthComboBox.Items1"),
            resources.GetString("lengthComboBox.Items2")});
            resources.ApplyResources(this.lengthComboBox, "lengthComboBox");
            this.lengthComboBox.Name = "lengthComboBox";
            // 
            // weigthComboBox
            // 
            this.weigthComboBox.FormattingEnabled = true;
            this.weigthComboBox.Items.AddRange(new object[] {
            resources.GetString("weigthComboBox.Items"),
            resources.GetString("weigthComboBox.Items1"),
            resources.GetString("weigthComboBox.Items2")});
            resources.ApplyResources(this.weigthComboBox, "weigthComboBox");
            this.weigthComboBox.Name = "weigthComboBox";
            // 
            // txtButton
            // 
            resources.ApplyResources(this.txtButton, "txtButton");
            this.txtButton.Name = "txtButton";
            this.txtButton.UseVisualStyleBackColor = true;
            this.txtButton.Click += new System.EventHandler(this.txtButton_Click);
            // 
            // wordButton
            // 
            resources.ApplyResources(this.wordButton, "wordButton");
            this.wordButton.Name = "wordButton";
            this.wordButton.UseVisualStyleBackColor = true;
            this.wordButton.Click += new System.EventHandler(this.wordButton_Click);
            // 
            // excelButton
            // 
            resources.ApplyResources(this.excelButton, "excelButton");
            this.excelButton.Name = "excelButton";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // resetButton
            // 
            resources.ApplyResources(this.resetButton, "resetButton");
            this.resetButton.Name = "resetButton";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.button10_Click);
            // 
            // openFileButton
            // 
            resources.ApplyResources(this.openFileButton, "openFileButton");
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            resources.GetString("typeComboBox.Items"),
            resources.GetString("typeComboBox.Items1"),
            resources.GetString("typeComboBox.Items2"),
            resources.GetString("typeComboBox.Items3"),
            resources.GetString("typeComboBox.Items4"),
            resources.GetString("typeComboBox.Items5"),
            resources.GetString("typeComboBox.Items6")});
            resources.ApplyResources(this.typeComboBox, "typeComboBox");
            this.typeComboBox.Name = "typeComboBox";
            // 
            // OutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.wordButton);
            this.Controls.Add(this.txtButton);
            this.Controls.Add(this.weigthComboBox);
            this.Controls.Add(this.lengthComboBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FlowLayoutPanel dataPanel;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox lengthComboBox;
        private System.Windows.Forms.ComboBox weigthComboBox;
        private System.Windows.Forms.Button txtButton;
        private System.Windows.Forms.Button wordButton;
        private System.Windows.Forms.Button excelButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}