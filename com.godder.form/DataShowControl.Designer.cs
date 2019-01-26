namespace IGAv2._0.com.godder.form
{
    partial class DataShowControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 14);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 12);
            this.label.TabIndex = 0;
            this.label.Text = "title";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.AutoSize = true;
            this.panel.Location = new System.Drawing.Point(0, 38);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(115, 12);
            this.panel.TabIndex = 2;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(19, 54);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 2;
            this.button.Text = "delete";
            this.button.UseVisualStyleBackColor = true;
            // 
            // DataShowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.button);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DataShowControl";
            this.Size = new System.Drawing.Size(120, 80);
            this.Enter += new System.EventHandler(this.DataShowControl_Enter);
            this.Leave += new System.EventHandler(this.DataShowControl_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button button;
        public System.Windows.Forms.Label label;
        public System.Windows.Forms.Panel panel;
    }
}
