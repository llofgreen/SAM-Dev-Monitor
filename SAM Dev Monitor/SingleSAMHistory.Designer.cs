namespace SAM_Dev_Monitor
{
    partial class SingleSAMHistory
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
            this.lstSAMS = new System.Windows.Forms.ListBox();
            this.btHistory = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaxRows = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstSAMS
            // 
            this.lstSAMS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSAMS.FormattingEnabled = true;
            this.lstSAMS.Location = new System.Drawing.Point(12, 12);
            this.lstSAMS.Name = "lstSAMS";
            this.lstSAMS.Size = new System.Drawing.Size(369, 329);
            this.lstSAMS.TabIndex = 0;
            // 
            // btHistory
            // 
            this.btHistory.Location = new System.Drawing.Point(12, 390);
            this.btHistory.Name = "btHistory";
            this.btHistory.Size = new System.Drawing.Size(75, 23);
            this.btHistory.TabIndex = 1;
            this.btHistory.Text = "Get History";
            this.btHistory.UseVisualStyleBackColor = true;
            this.btHistory.Click += new System.EventHandler(this.btHistory_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(306, 390);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Maximum Rows:";
            // 
            // txtMaxRows
            // 
            this.txtMaxRows.Location = new System.Drawing.Point(103, 357);
            this.txtMaxRows.Name = "txtMaxRows";
            this.txtMaxRows.Size = new System.Drawing.Size(68, 20);
            this.txtMaxRows.TabIndex = 4;
            this.txtMaxRows.Text = "200";
            this.txtMaxRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SingleSAMHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 425);
            this.Controls.Add(this.txtMaxRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btHistory);
            this.Controls.Add(this.lstSAMS);
            this.Name = "SingleSAMHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SingleSAMHistory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSAMS;
        private System.Windows.Forms.Button btHistory;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxRows;
    }
}