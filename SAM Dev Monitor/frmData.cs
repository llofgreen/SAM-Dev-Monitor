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
    public partial class frmData : Form
    {
        public frmData()
        {
            InitializeComponent();
        }

        public void SetData(DataTable dt)
        {
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Refresh();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
