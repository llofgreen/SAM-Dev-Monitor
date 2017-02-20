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
    public partial class SelectSAMs : Form
    {
        private string SAMWatchList = Properties.Settings.Default.SAMWatchList;

        
        public SelectSAMs()
        {
            InitializeComponent();

            using (EDWAdmin edw = new EDWAdmin())
            {
                edw.GetSAMs();
                bool InList;
                foreach (var a in edw.SAMs)
                {
                    if (SAMWatchList.Length == 0 || SAMWatchList.IndexOf("'" + a + "'") > -1)
                    {
                        InList = true;
                    }
                    else
                    {
                        InList = false;
                    }
                    this.lstSAMS.Items.Add(a, InList);
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < this.lstSAMS.Items.Count; i++)
            {
                this.lstSAMS.SetItemChecked(i, true);
            }
        }

        private void btSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lstSAMS.Items.Count; i++)
            {
                this.lstSAMS.SetItemChecked(i, false);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(this.lstSAMS.CheckedItems.Count <0)
            {
                MessageBox.Show("You must select at least one SAM.  Use the Disable menu item if you do not want to receive notifications");
                return;
            }

            SAMWatchList = "";
            if(this.lstSAMS.CheckedItems.Count != this.lstSAMS.Items.Count)
            {
                foreach (var s in this.lstSAMS.CheckedItems)
                {
                    if (SAMWatchList.Length > 0)
                    {
                        SAMWatchList += ",'" + s.ToString() + "'";
                    }
                    else
                    {
                        SAMWatchList += "'" + s.ToString() + "'";
                    }
                }
            }
            Properties.Settings.Default.SAMWatchList = SAMWatchList;
            Properties.Settings.Default.Save();
            this.Close();
        }

        
    }
}
