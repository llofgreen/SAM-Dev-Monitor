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
    public partial class RTB : Form
    {
        public RTB()
        {
            InitializeComponent();
        }

        private void Parse1()
        {
            string[] temp = this.richTextBox1.Text.Split(';');

            List<string> addresses = new List<string>();

            string email = "";

            foreach (string s in temp)
            {
                int x = s.IndexOf('<');
                if (x > -1)
                {
                    string a = s.Substring(x + 1);
                    x = a.IndexOf('>');
                    if (x > 0)
                    {
                        a = a.Substring(0, x).Trim().ToLower();
                        if (a.Length > 2 && a.IndexOf('@') > 0)
                        {
                            bool bFound = false;
                            for (int i = 0; i < addresses.Count; i++)
                            {
                                if (addresses[i] == a)
                                {
                                    bFound = true;
                                    i = addresses.Count;
                                }
                            }
                            if (!bFound)
                            {
                                addresses.Add(a);
                                email += a + "\n";
                            }

                        }
                    }
                }
            }

            Clipboard.SetText(email);

            MessageBox.Show("Parse Complete: " + addresses.Count.ToString());
        }

        private void Parse2()
        {
            string[] temp = this.richTextBox1.Text.Split(';');

            List<string> addresses = new List<string>();

            string email = "";

            foreach (string s in temp)
            {
                string a = s.Trim().ToLower();
                if (a.Length > 2 && a.IndexOf('@') > 0)
                {
                    bool bFound = false;
                    for (int i = 0; i < addresses.Count; i++)
                    {
                        if (addresses[i] == a)
                        {
                            bFound = true;
                            i = addresses.Count;
                        }
                    }
                    if (!bFound)
                    {
                        addresses.Add(a);
                        email += a + "\n";
                    }

                }
            }

            Clipboard.SetText(email);

            MessageBox.Show("Parse Complete: " + addresses.Count.ToString());
        }

        private void btRun_Click(object sender, EventArgs e)
        {
            if (this.rbParse1.Checked)
            {
                Parse1();
                return;
            }

            if (this.rbParse2.Checked)
            {
                Parse2();
                return;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
