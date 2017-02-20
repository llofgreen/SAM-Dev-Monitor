namespace SAM_Dev_Monitor
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nudTimerInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEDWInstance = new System.Windows.Forms.TextBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.nudLookBack = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSlackName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ckNoActivity = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLookBack)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timer Interval:";
            // 
            // nudTimerInterval
            // 
            this.nudTimerInterval.Location = new System.Drawing.Point(106, 11);
            this.nudTimerInterval.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudTimerInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimerInterval.Name = "nudTimerInterval";
            this.nudTimerInterval.Size = new System.Drawing.Size(78, 20);
            this.nudTimerInterval.TabIndex = 1;
            this.nudTimerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudTimerInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "EDW Instance:";
            // 
            // txtEDWInstance
            // 
            this.txtEDWInstance.Location = new System.Drawing.Point(106, 64);
            this.txtEDWInstance.Name = "txtEDWInstance";
            this.txtEDWInstance.Size = new System.Drawing.Size(292, 20);
            this.txtEDWInstance.TabIndex = 4;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(281, 170);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(117, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // nudLookBack
            // 
            this.nudLookBack.Location = new System.Drawing.Point(106, 37);
            this.nudLookBack.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.nudLookBack.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLookBack.Name = "nudLookBack";
            this.nudLookBack.Size = new System.Drawing.Size(78, 20);
            this.nudLookBack.TabIndex = 8;
            this.nudLookBack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLookBack.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "minutes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Look Back:";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(106, 170);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(117, 23);
            this.btSave.TabIndex = 9;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(106, 90);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(292, 20);
            this.txtUserName.TabIndex = 11;
            this.txtUserName.TabStop = false;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "User:";
            // 
            // txtSlackName
            // 
            this.txtSlackName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlackName.Location = new System.Drawing.Point(106, 116);
            this.txtSlackName.Name = "txtSlackName";
            this.txtSlackName.ReadOnly = true;
            this.txtSlackName.Size = new System.Drawing.Size(292, 20);
            this.txtSlackName.TabIndex = 13;
            this.txtSlackName.TabStop = false;
            this.txtSlackName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Slack Name:";
            // 
            // ckNoActivity
            // 
            this.ckNoActivity.AutoSize = true;
            this.ckNoActivity.Location = new System.Drawing.Point(106, 143);
            this.ckNoActivity.Name = "ckNoActivity";
            this.ckNoActivity.Size = new System.Drawing.Size(186, 17);
            this.ckNoActivity.TabIndex = 14;
            this.ckNoActivity.Text = "Receive \"No Activity\" Notification";
            this.ckNoActivity.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 205);
            this.Controls.Add(this.ckNoActivity);
            this.Controls.Add(this.txtSlackName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.nudLookBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.txtEDWInstance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudTimerInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLookBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudTimerInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEDWInstance;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.NumericUpDown nudLookBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSlackName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox ckNoActivity;
    }
}