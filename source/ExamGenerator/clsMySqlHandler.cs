using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;



namespace ExamGenerator
{
    class clsMySqlHandler
    {

        public ToolStripStatusLabel txtStatus = null;
        public string DBname = "";
        public string Server = "";
        public int ElementNumber = 0;
        public bool Abort = false;

        private MySqlConnection oConn = null;
        private MySqlCommand oCmd = null;
        private string sUID = "", sPWD = "";

        public clsMySqlHandler(ToolStripStatusLabel StatusLabel)
        {
            sUID = Properties.Settings.Default.MySqlUID;
            sPWD = Properties.Settings.Default.MySqlPWD;
#if DEBUG
            sUID = "FCCuser";
            sPWD = "MakeAtest";
#endif
            txtStatus = StatusLabel;
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
            MySqlCommand oCmd = oConn.CreateCommand();
            oCmd.CommandText = "select SCHEMA_NAME from information_schema.SCHEMATA";
            MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd);
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
            MySqlCommand oCmd = oConn.CreateCommand();
            oCmd.CommandType = CommandType.Text;
            try
            {
                MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd);
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
                oConn = new MySqlConnection();
            }
            string sCmd = "server=" + Server + ";UID=" + sUID + ";PWD=" + sPWD;
            try
            {
                oConn.ConnectionString = sCmd;
                oConn.Open();
                oCmd = oConn.CreateCommand();
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

        public DataTable GetDescriptions()
        {
            if (oConn == null)
            {
                MakeMySQLconnection();
            }
            if (oConn.State != ConnectionState.Open)
            {
                oConn.Open();
            }
            if (oConn.Database != DBname)
            {
                oConn.ChangeDatabase(DBname);
            }
            oCmd.CommandText = "select * from fcc_element_descriptions"; // where elementnumber = " + ElementNumber.ToString();
            MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd);
            DataTable oTable = new DataTable();
            oDA.Fill(oTable);
            return oTable;
        }

        public DataTable GetQuestions() // int ElementNumber)
        {
            if (oConn.State != ConnectionState.Open)
            {
                MakeMySQLconnection();
            }
            if (oConn.Database != DBname)
            {
                oConn.ChangeDatabase(DBname);
            }
            //---- get all questions for the master table
            oCmd.CommandText = "select * from fcc_exam_questions"; // where elementnumber = " + ElementNumber.ToString();
            MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd);
            DataTable oTable = new DataTable();
            oDA.Fill(oTable);
            return oTable;
        }

    }  // end classs

}  // end namespace
