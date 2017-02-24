namespace SAM_Dev_Monitor
{
    partial class RTB
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btRun = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.rbParse1 = new System.Windows.Forms.RadioButton();
            this.rbParse2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(410, 476);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btRun
            // 
            this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRun.Location = new System.Drawing.Point(329, 484);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(75, 23);
            this.btRun.TabIndex = 1;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Location = new System.Drawing.Point(329, 513);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // rbParse1
            // 
            this.rbParse1.AutoSize = true;
            this.rbParse1.Location = new System.Drawing.Point(13, 489);
            this.rbParse1.Name = "rbParse1";
            this.rbParse1.Size = new System.Drawing.Size(61, 17);
            this.rbParse1.TabIndex = 3;
            this.rbParse1.TabStop = true;
            this.rbParse1.Text = "Parse 1";
            this.rbParse1.UseVisualStyleBackColor = true;
            // 
            // rbParse2
            // 
            this.rbParse2.AutoSize = true;
            this.rbParse2.Location = new System.Drawing.Point(13, 513);
            this.rbParse2.Name = "rbParse2";
            this.rbParse2.Size = new System.Drawing.Size(61, 17);
            this.rbParse2.TabIndex = 4;
            this.rbParse2.TabStop = true;
            this.rbParse2.Text = "Parse 2";
            this.rbParse2.UseVisualStyleBackColor = true;
            // 
            // RTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 556);
            this.Controls.Add(this.rbParse2);
            this.Controls.Add(this.rbParse1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.richTextBox1);
            this.Name = "RTB";
            this.Text = "RTB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.RadioButton rbParse1;
        private System.Windows.Forms.RadioButton rbParse2;
    }
}