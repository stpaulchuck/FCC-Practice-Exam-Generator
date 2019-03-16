using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ExamGenerator
{
	public class clsSQLiteHandler : IDisposable
	{
		/************************* properties ******************************/
		private string m_DBpath = "";
		public string DBpath {get{return m_DBpath; } set{ m_DBpath = value; }}

		private int m_ElementNumber = 0;
		public int ElementNumber {get{ return m_ElementNumber; }set{ m_ElementNumber = value; } }

		private bool m_Abort = false;
		public bool Abort {get{ return m_Abort; }set{ m_Abort = value; } }

		/************************ global vars *****************************/
		private SQLiteConnection oConn = null;
		private SQLiteCommand oCmd = null;
		private ToolStripStatusLabel txtStatus = null;

		/*********************** con/destructor ***************************/
		public clsSQLiteHandler(ToolStripStatusLabel StatusLabel)
		{
			txtStatus = StatusLabel;
		}

		/*********************** public methods ***************************/
		public bool TestSqlConnection(string DBpath)
		{
			if (!File.Exists(DBpath))
			{ return false; }

			// all good, so -
			m_DBpath = DBpath;
			return true;
		}

		public DataTable GetDescriptions()
		{
			if (oConn == null)
				MakeSqlConnection();
			if (oConn.State != ConnectionState.Open)
			{
				MakeSqlConnection();
			}
			//---- get all questions for the master table
			oCmd.CommandText = "select * from fcc_element_descriptions"; // where elementnumber = " + ElementNumber.ToString();
			SQLiteDataAdapter oDA = new SQLiteDataAdapter(oCmd);
			DataTable oTable = new DataTable();
			oDA.Fill(oTable);
			return oTable;
		}

		public DataTable GetQuestions()
		{
			if (oConn == null)
			{
				MakeSqlConnection();
			}
			if (oConn.State != ConnectionState.Open)
			{
				oConn.Open();
			}
			//---- get all questions for the master table
			if (oCmd == null)
				oCmd = oConn.CreateCommand();
			oCmd.CommandText = "select * from fcc_exam_questions"; // where elementnumber = " + ElementNumber.ToString();
			SQLiteDataAdapter oDA = new SQLiteDataAdapter(oCmd);
			DataTable oTable = new DataTable();
			oDA.Fill(oTable);
			return oTable;
		}


		/********************** private methods ***************************/
		private bool MakeSqlConnection()
		{
			oConn = new SQLiteConnection("Data Source=" + DBpath + ";Version=3;");
			if (oConn == null)
			{
				txtStatus.Text = "failed to open database";
				return false;
			}
			if (oConn.State != System.Data.ConnectionState.Open)
			{
				oConn.Open();
			}
			if (oConn.State != System.Data.ConnectionState.Open)
			{
				txtStatus.Text = "failed to open the database";
				return false;
			}
			return true;
		}

		// Public implementation of Dispose pattern callable by consumers.
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Protected implementation of Dispose pattern.
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (oConn != null)
					oConn.Dispose();
			}
		}

	}  //  end class


}  // end namespace
