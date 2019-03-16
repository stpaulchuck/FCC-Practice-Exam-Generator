using System;
using System.Collections.Generic;
//using Mysql.Data.Client;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace TestPoolParser
{
    class clsMySqlHandler
    {

        public ToolStripStatusLabel txtStatus = null;
        public List<string> QuestionsCommandList = null;
        public List<string> DescriptionsCommandList = null;
        public string DBname = "";
        public string Server = "";
        public int ElementNumber = 0;
        public bool Abort = false;

        private SqlConnection oConn = null;
        private string sUID = "", sPWD = "";

        public clsMySqlHandler(ToolStripStatusLabel StatusLabel)
        {
        }

        public void SaveData()
        {
            MakeMySQLconnection();
            SqlCommand oCmd = oConn.CreateCommand();
            oCmd.CommandType = CommandType.Text;
            //---- check to see if we are pointing to correct database
            if (oConn.Database != DBname)
            {
                oConn.ChangeDatabase(DBname);
            }
            //---- clear old data from tables
            string sElementNumber = ElementNumber.ToString("0");
            oCmd.CommandText = "delete from fcc_element_descriptions where ElementNumber = " + sElementNumber;
            oCmd.ExecuteNonQuery();
            oCmd.CommandText = "delete from fcc_exam_questions where ElementNumber = " + sElementNumber;
            oCmd.ExecuteNonQuery();
            //---- now save the stuff
            int iCounter = 0;
            int iQuestionCount = QuestionsCommandList.Count;
            int iDescriptionCount = DescriptionsCommandList.Count;
            try
            {
                foreach (string sCmd in QuestionsCommandList)
                {
                    Application.DoEvents();
                    if (Abort)
                    {
                        return;
                    }
                    iCounter++;
                    if (iCounter % 13 == 0)
                        txtStatus.Text = "Saving Data. Question #" + iCounter.ToString() + " of " + iQuestionCount.ToString() + " Total";
                    oCmd.CommandText = sCmd;
                    oCmd.ExecuteNonQuery();
                }
                iCounter = 0;
                foreach (string s2 in DescriptionsCommandList)
                {
                    Application.DoEvents();
                    if (Abort)
                    {
                        return;
                    }
                    iCounter++;
                    if (iCounter % 13 == 0)
                        txtStatus.Text = "Saving Data. Description #" + iCounter.ToString() + " of " + iDescriptionCount.ToString() + " Total";
                    oCmd.CommandText = s2;
                    oCmd.ExecuteNonQuery();
                }
            }
            catch (Exception e3)
            {
                throw e3;
            }
        }

        public DataTable GetDBnames(string ServerName)
        {
            Server = ServerName;
            DataTable retVal = new DataTable();
            if (oConn == null)
                if (!MakeMySQLconnection())
                    return retVal;
            if (oConn.State != ConnectionState.Open)
                oConn.Open();
            SqlCommand oCmd = oConn.CreateCommand();
            oCmd.CommandText = "select SCHEMA_NAME from information_schema.SCHEMATA";
            SqlDataAdapter oDA = new SqlDataAdapter(oCmd);
            oDA.Fill(retVal);
            return retVal;
        }

        public bool TestMySqlConnection(string ServerName, string Database)
        {
            Server = ServerName;
            DBname = Database;
            if (!MakeMySQLconnection())
                return false;

            try
            {
                if (DBname == "")
                    throw new Exception("Database Name is empty!!");
                oConn.ChangeDatabase(DBname);
            }
            catch (Exception e3)
            {
                txtStatus.Text = "Error connecting to database!!";
                MessageBox.Show("Error connecting to database: " + e3.Message, "ERROR");
                return false;
            }

            //---- validate tables exist
            SqlCommand oCmd = oConn.CreateCommand();
            oCmd.CommandType = CommandType.Text;
            try
            {
                SqlDataAdapter oDA = new SqlDataAdapter(oCmd);
                DataTable oTable = new DataTable();
                oCmd.CommandText = "select count(*) from fcc_element_descriptions";
                oDA.Fill(oTable);
                oTable.Clear();
                oCmd.CommandText = "select count(*) from fcc_exam_questions";
                oDA.Fill(oTable);
                oTable.Clear();
                oTable.Dispose();
                oDA.Dispose();
            }
            catch (Exception e4)
            {
                txtStatus.Text = "Error connecting to DB tables!!";
                MessageBox.Show("Error connecting to DB tables: " + e4.Message, "ERROR");
                return false;
            }
            return true;

        }

        private bool MakeMySQLconnection()
        {
            txtStatus.Text = "Attempting connection to MySQL server.";
            if (oConn != null)
            {
                if (oConn.State == ConnectionState.Open)
                {
                    oConn.Close();
                }
            }
            else
            {
                oConn = new SqlConnection();
            }
            string sCmd = "server=" + Server + ";UID=" + sUID + ";PWD=" + sPWD;
            try
            {
                oConn.ConnectionString = sCmd;
                oConn.Open();
            }
            catch (Exception e2)
            {
                txtStatus.Text = "Error making MySQL connection!!";
                MessageBox.Show("Error making MySQL connection: " + e2.Message, "ERROR");
                return false;
            }
            txtStatus.Text = "Successful connection to MySQL server.";
            return true;
        }
                

    }  // end classs

}  // end namespace
