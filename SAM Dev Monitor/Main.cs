using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM_Dev_Monitor
{
    public partial class Main : Form
    {
        private int childFormNumber = 0;
        private bool timerEnabled;
        private EDWAdmin edw;
        
        public Main()
        {
            InitializeComponent();
            
            timerEnabled = false;
            this.timer1.Enabled = false;
            edw = new EDWAdmin();
            this.SetEDW();
            this.SetStatus();
            this.SetTimer();
            this.testToolStripMenuItem.Visible = (Environment.UserName == "s0173317");
            Version temp = new Version(1, 0, 0, 21);
            this.Text = "SAM Monitor v" + temp.ToString();
            this.tmrSAMUsage.Enabled = true;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

      
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAll();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            using (Settings frm = new Settings())
            {
                frm.ShowDialog();
            }
            // Timer settings may have changed
            this.SetTimer();
        }


        #region Private Methods
        private void CloseAll()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void SetEDW()
        {
            edw = new EDWAdmin();
        }

        private void SetStatus()
        {
            if (Properties.Settings.Default.SlackNotification)
            {
                this.tssSlackEnabledLink.Text = "Slack Enabled";
                this.tssSlackEnabledLink.LinkColor = Color.Green;
            }
            else
            {
                this.tssSlackEnabledLink.Text = "Slack Disabled";
                this.tssSlackEnabledLink.LinkColor = Color.Red;
            }
            if (this.timerEnabled)
            {
                this.tssTimerEnabledLink.Text = "Timer Enabled";
                this.tssTimerEnabledLink.LinkColor = Color.Green;
            }
            else
            {
                this.tssTimerEnabledLink.Text = "Timer Disabled";
                this.tssTimerEnabledLink.LinkColor = Color.Red;
            }
        }
        private void SetTimer()
        {
            this.timer1.Interval = (int)(Properties.Settings.Default.TimerIntervalMinutes * 60000.0);
            timerEnabled = Properties.Settings.Default.Enabled;
            this.timer1.Enabled = timerEnabled;
        }

        public void ProcessTick(bool ForceTick)
        {
            ProcessTick(ForceTick, 0, "");
        }

        public void ProcessTick(bool ForceTick, int OverrideRowCount, string OverrideSAMNM)
        {
            if (!ForceTick)
            {
                if (!this.timerEnabled)
                    return;
            }

            this.Cursor = Cursors.WaitCursor;
            this.timer1.Enabled = false;

            double LookBackMinutes = Properties.Settings.Default.LookBackMinutes;

            DateTime CheckTime = DateTime.Now.AddMinutes(-LookBackMinutes);

            bool slackNotification = Properties.Settings.Default.SlackNotification;
            bool slackNoActivityNotification = Properties.Settings.Default.NoActivityNotification;

            if (edw.slackUserName.Length == 0 || edw.slackURI.Length == 0)
            {
                slackNotification = false;
            }

            CloseAll();

            if (edw.GetUpdates(CheckTime,OverrideRowCount, OverrideSAMNM) > 0)
            {
                frmData m = new frmData();
                m.Text = "SAM Audit Log";
                m.MdiParent = this;
                m.SetData(edw.AuditLog);
                m.Show();

                if (slackNotification)
                {
                    string message = "";
                    string lastMessage = "";
                    string newMessage = "";
                    for(int i = 0; i < edw.AuditLog.Rows.Count; i++)
                    {
                        DataRow d = edw.AuditLog.Rows[i];
                        string SAMNM = d[0].ToString();
                        string ObjectNM = d[1].ToString();
                        string UpdatedByNM = d[2].ToString();
                        string ChangedDSC = d[3].ToString();

                        newMessage = ObjectNM + " updated by " + UpdatedByNM + " at " + ChangedDSC;
                        if(newMessage != lastMessage)
                        {
                            lastMessage = newMessage;
                            message = message + newMessage + "\n";
                        }
                        
                    }
                    SlackIntegration si = new SlackIntegration();
                    si.Send(edw.slackURI, edw.slackUserName, "SAM Updates - " + Properties.Settings.Default.EDWInstance, message);
                }

            }
            else
            {
                if(slackNotification && slackNoActivityNotification)
                {
                    SlackIntegration si = new SlackIntegration();
                    si.Send(edw.slackURI, edw.slackUserName, "SAM Updates - " + Properties.Settings.Default.EDWInstance, "No Activity");
                }
            }

            if (edw.GetExecutions(CheckTime, OverrideRowCount, OverrideSAMNM) > 0)
            {
                frmData m = new frmData();
                m.Text = "SAM Executions";
                m.MdiParent = this;
                m.SetData(edw.ExecutionLog);
                m.Show();

                if (slackNotification)
                {
                    string message = "";
                    for (int i = 0; i < edw.ExecutionLog.Rows.Count; i++)
                    {
                        DataRow d = edw.ExecutionLog.Rows[i];
                        string SAMNM = d[0].ToString();
                        string ExecutionTypeCD = d[1].ToString();
                        string LogicTypeCD = d[2].ToString();
                        string LogicNM = d[3].ToString();
                        string StartDTS = d[4].ToString();
                        string StatusCD = d[5].ToString();

                        message = message + SAMNM;
                        if(ExecutionTypeCD == "Binding")
                        {
                            message = message + " (" + LogicTypeCD + ": " + LogicNM + ") ";
                        }
                        message = message + " started " + StartDTS + " [" + StatusCD + "]\n";
                    }
                    SlackIntegration si = new SlackIntegration();
                    si.Send(edw.slackURI, edw.slackUserName, "SAM Executions - " + Properties.Settings.Default.EDWInstance, message);
                }
            }
            else
            {
                if (slackNotification && slackNoActivityNotification)
                {
                    SlackIntegration si = new SlackIntegration();
                    si.Send(edw.slackURI, edw.slackUserName, "SAM Executions - " + Properties.Settings.Default.EDWInstance, "No Activity");
                }
            }
            LayoutMdi(MdiLayout.TileHorizontal);
            this.Cursor = Cursors.Default;

            this.timer1.Enabled = this.timerEnabled;
        }


        #endregion Private Methods

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProcessTick(false);
            

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ProcessTick(true);
            
        }

        private void tssTimerEnabledLink_Click(object sender, EventArgs e)
        {
            this.timerEnabled = !this.timerEnabled;
            this.timer1.Enabled = timerEnabled;
            this.SetStatus();
        }

        private void tssSlackEnabledLink_Click(object sender, EventArgs e)
        {
            if (edw.slackURI.Length > 0 && edw.slackUserName.Length > 0)
            {
                Properties.Settings.Default.SlackNotification = !Properties.Settings.Default.SlackNotification;
                this.SetStatus();
            }
        }

        private void selectSAMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SelectSAMs frm = new SelectSAMs())
            {
                frm.ShowDialog();
            }

        }

        private void singleSAMHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SingleSAMHistory frm = new SingleSAMHistory())
            {
                frm.myParent = this;
                frm.ShowDialog();
                LayoutMdi(MdiLayout.TileHorizontal);
            }
        }

        private void test01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessTick(true, 10, "");
        }

        private void test02ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RTB frm = new RTB();
            frm.ShowDialog();
        }

        public void GetSAMProcesses()
        {
            this.tssSAMProcesses.Text = "Get SAM Processes";
            Application.DoEvents();
            this.Cursor = Cursors.WaitCursor;

            Process[] processlist = Process.GetProcesses();

            foreach (Process p in processlist)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    if(p.ProcessName == "SAMDesigner")
                    {
            
                        string temp = p.MainWindowTitle;
                        int x = temp.IndexOf("-");
                        if(x > 0)
                        {
                            string SAMNM = temp.Substring(0, x - 1).Trim();
                            string samdConnection = "";

                            // Get Connection
                            temp = temp.Substring(x + 1).Trim();
                            x = temp.IndexOf("-");
                            if(x > 0)
                            {
                                samdConnection = temp.Substring(0, x - 1).Trim();
                            }
                            edw.RecordSAMUsage(SAMNM, samdConnection);

                            this.tssSAMProcesses.Text = SAMNM;
                            Application.DoEvents();

                        }

                    }
                    
                }
            }

            this.tssSAMProcesses.Text = "";
            Application.DoEvents();
            this.Cursor = Cursors.Default;


        }

        private void tmrSAMUsage_Tick(object sender, EventArgs e)
        {
            //GetSAMProcesses();
            return;
            
        }

        private void tssUsageMinutes_Click(object sender, EventArgs e)
        {
            string temp = Properties.Settings.Default.UsageMinutes.ToString();
            
        }

        private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(edw.GetSAMUsage() > 0)
            {
                frmData m = new frmData();
                m.Text = "SAM Usage";
                m.MdiParent = this;
                m.SetData(edw.SAMUsageLog);
                m.Show();
            }
        }
    }
}
