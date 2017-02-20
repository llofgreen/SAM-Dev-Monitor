using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace SAM_Dev_Monitor
{
    class EDWAdmin : IDisposable
    {
        private string _devConnectionString;
        private bool disposed;
        
        public List<string> SAMs;

        public string slackUserName;
        public string slackURI;

        public DataTable AuditLog;
        public DataTable ExecutionLog;

        public EDWAdmin()
        {
            SAMs = new List<string>();
            _devConnectionString = "Data Source=" + Properties.Settings.Default.EDWInstance + "; Initial Catalog=EDWAdmin; Integrated Security=SSPI;";
            disposed = false;
            this.SlackInit();
            this.ExecutionLog = new DataTable();
            this.AuditLog = new DataTable();
        }

        public void SlackInit()
        {
            // Get integration URI
            string SQL = "SELECT ValueTXT FROM EDWAdmin.JobCop.ConfigurationBASE AS d WHERE d.KeyCD = 'SLACK_URI'";
            using (SqlConnection con = new SqlConnection(_devConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SQL, con))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            this.slackURI = rdr.GetString(0);
                        }
                    }
                    SQL = "SELECT SlackUserNM FROM EDWAdmin.JobCop.SlackUserBASE AS a WHERE a.UserNM = '" + Environment.UserName + "'";
                    cmd.CommandText = SQL;
                    using(SqlDataReader rd2 = cmd.ExecuteReader())
                    {
                        if (rd2.Read())
                        {
                            this.slackUserName = rd2.GetString(0);
                        }
                    }
                }
            }
        }
        
        public void GetSAMs()
        {
            this.SAMs.Clear();
            string SQL = "SELECT d.DataMartNM FROM EDWAdmin.CatalystAdmin.DataMartBASE AS d WHERE d.DataMartTypeDSC = 'Subject Area' ORDER BY d.DataMartNM";
            using (SqlConnection con = new SqlConnection(_devConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SQL, con))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            SAMs.Add(rdr.GetString(0));
                        }
                    }
                }
            }
        }

        public int GetExecutions(DateTime MinTime, int OverrideRowCount, string OverrideSAMNM)
        {
            if (disposed)
                return -1;

            this.ExecutionLog.Dispose();
            this.ExecutionLog = new DataTable();

            string sqlTop = "";
            string sqlMiddle = " SAMNM, ExecutionTypeCD," +
                "COALESCE(LogicTypeCD,'') AS LogicTypeCD,COALESCE(LogicNM,'') AS LogicNM" +
                ",StartDTS,StatusCD " +
                " FROM EDWAdmin.JobCop.vwSAMExecution AS s ";
            string sqlWhere = "";
            string sqlSort = "";
            if (OverrideRowCount > 0)
            {
                sqlTop = "SELECT DISTINCT TOP " + OverrideRowCount.ToString() + " ";
                if (Properties.Settings.Default.SAMWatchList.Length > 0 || OverrideSAMNM.Length > 0)
                {
                    if(OverrideSAMNM.Length > 0)
                    {
                        sqlWhere = " WHERE COALESCE(s.SAMNM,'') = '" + OverrideSAMNM + "' ";
                    }
                    else
                    {
                        sqlWhere = " WHERE COALESCE(s.SAMNM,'') IN (" + Properties.Settings.Default.SAMWatchList + ") ";
                    }
                    
                }
                sqlSort = " ORDER BY s.StartDTS DESC";
            }
            else
            {
                sqlTop = "SELECT DISTINCT ";
                sqlWhere += " WHERE s.StartDTS > '" + MinTime.ToString("yyyy-MM-dd") + " " + MinTime.ToString("HH:mm") + "' ";
                if (Properties.Settings.Default.SAMWatchList.Length > 0 || OverrideSAMNM.Length > 0)
                {
                    if(OverrideSAMNM.Length> 0)
                    {
                        sqlWhere += " AND COALESCE(s.SAMNM,'') = '" + OverrideSAMNM + "' ";
                    }
                    else
                    {
                        sqlWhere += " AND COALESCE(s.SAMNM,'') IN (" + Properties.Settings.Default.SAMWatchList + ") ";
                    }
                    
                }
                sqlSort = " ORDER BY StartDTS DESC";
            }

            string SQL = sqlTop + sqlMiddle + sqlWhere + sqlSort;

            using (SqlConnection con = new SqlConnection(_devConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SQL, con))
                {
                    using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(this.ExecutionLog);
                    }
                }
            }

            return this.ExecutionLog.Rows.Count;
        }

        public int GetUpdates(DateTime MinTime, int OverrideRowCount, string OverrideSAMNM)
        {
            if (disposed)
                return -1;

            this.AuditLog.Dispose();
            this.AuditLog = new DataTable();

            
            string sqlTop = "";
            string sqlMiddle = " COALESCE(s.DataMartNM,'') AS DataMartNM ,s.ObjectNM ,s.UpdatedByNM , CONVERT(varchar,s.ChangedDTS,100) AS ChangedDSC, ChangedDTS " +
                " FROM EDWAdmin.JobCop.vwSAMChanges AS s ";
            string sqlWhere = "";
            string sqlSort = "";
            if (OverrideRowCount > 0)
            {
                sqlTop = "SELECT DISTINCT TOP " + OverrideRowCount.ToString() + " ";
                if (Properties.Settings.Default.SAMWatchList.Length > 0 || OverrideSAMNM.Length > 0)
                {
                    if(OverrideSAMNM.Length > 0)
                    {
                        sqlWhere = " WHERE COALESCE(DataMartNM,'') = '" + OverrideSAMNM + "' ";
                    }
                    else
                    {
                        sqlWhere = " WHERE COALESCE(DataMartNM,'') IN (" + Properties.Settings.Default.SAMWatchList + ") ";
                    }
                    
                }
                sqlSort = " ORDER BY ChangedDTS DESC";
            }
            else
            {
                sqlTop = "SELECT DISTINCT ";
                sqlWhere += " WHERE s.ChangedDTS > '" + MinTime.ToString("yyyy-MM-dd") + " " + MinTime.ToString("HH:mm") + "' ";
                if(Properties.Settings.Default.SAMWatchList.Length > 0 || OverrideSAMNM.Length > 0)
                {
                    if (OverrideSAMNM.Length > 0)
                    {
                        sqlWhere += " AND COALESCE(DataMartNM,'') = '" + OverrideSAMNM + "'";
                    }
                    else
                    {
                        sqlWhere += " AND COALESCE(DataMartNM,'') IN (" + Properties.Settings.Default.SAMWatchList + ")";
                    }
                        
                }
                sqlSort = " ORDER BY ChangedDTS DESC";
            }

            string SQL = sqlTop + sqlMiddle + sqlWhere +sqlSort;

            using (SqlConnection con = new SqlConnection(_devConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(SQL, con))
                {
                    using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(AuditLog);
                    }
                }
            }
      
            return AuditLog.Rows.Count;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                AuditLog.Dispose();
                ExecutionLog.Dispose();
            }

            disposed = true;
        }
           
    }
}
