using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM_Dev_Monitor
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.nudTimerInterval.Value = (Decimal) Properties.Settings.Default.TimerIntervalMinutes;
            this.nudLookBack.Value = (Decimal)Properties.Settings.Default.LookBackMinutes;
            this.txtEDWInstance.Text = Properties.Settings.Default.EDWInstance;
            this.txtUserName.Text = Environment.UserName;
            EDWAdmin edw = new EDWAdmin();
            this.txtSlackName.Text = edw.slackUserName;
            this.ckNoActivity.Checked = Properties.Settings.Default.NoActivityNotification;
            
            edw.Dispose();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(this.txtEDWInstance.Text.Length == 0)
            {
                MessageBox.Show("You must specify the EDW Instance");
                return;
            }

            Properties.Settings.Default.TimerIntervalMinutes = (double)this.nudTimerInterval.Value;
            Properties.Settings.Default.LookBackMinutes = (double)this.nudLookBack.Value;
            Properties.Settings.Default.EDWInstance = this.txtEDWInstance.Text;
            Properties.Settings.Default.NoActivityNotification = this.ckNoActivity.Checked;
                
            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
