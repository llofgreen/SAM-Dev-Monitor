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
    
    public partial class SingleSAMHistory : Form
    {
        public Main myParent;

        public SingleSAMHistory()
        {
            InitializeComponent();
            using (EDWAdmin edw = new EDWAdmin())
            {
                edw.GetSAMs();
                foreach (var a in edw.SAMs)
                {
                    this.lstSAMS.Items.Add(a);
                }
            }
            this.txtMaxRows.Text = Properties.Settings.Default.SAMHistoryRows.ToString();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btHistory_Click(object sender, EventArgs e)
        {

            if(this.lstSAMS.SelectedItems.Count != 1)
            {
                MessageBox.Show("You must select a SAM from the list");
                return;
            }

            if(this.txtMaxRows.Text.Length == 0)
            {
                MessageBox.Show("You must specify the maximum number of rows");
                return;
            }

            int maxRows = 0;
            if(!Int32.TryParse(this.txtMaxRows.Text,out maxRows))
            {
                MessageBox.Show("Maximum number of rows must be numeric");
                return;
            }

            if(maxRows < 1 || maxRows > 5000)
            {
                MessageBox.Show("Maximum number of rows must be between 1 and 5000");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            Properties.Settings.Default.SAMHistoryRows = maxRows;
            Properties.Settings.Default.Save();

            string SAMNM = this.lstSAMS.SelectedItem.ToString();

            using(EDWAdmin edw = new EDWAdmin())
            {
                if (edw.GetUpdates(DateTime.Now, maxRows, SAMNM)>0)
                {
                    frmData m = new frmData();
                    m.Text = "SAM History - Audit Log";
                    m.MdiParent = myParent;
                    m.SetData(edw.AuditLog);
                    m.Show();
                }

                if (edw.GetExecutions(DateTime.Now, maxRows, SAMNM) > 0)
                {
                    frmData m = new frmData();
                    m.Text = "SAM History - Execution Log";
                    m.MdiParent = myParent;
                    m.SetData(edw.ExecutionLog);
                    m.Show();
                }

            }
            this.Cursor = Cursors.Default;
            this.Close();
        }
    }
}
