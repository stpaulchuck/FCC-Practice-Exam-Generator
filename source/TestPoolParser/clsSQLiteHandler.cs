using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace TestPoolParser
{
	public class clsSQLiteHandler
	{
		/******************** properties *******************/
		public ToolStripStatusLabel txtStatus = null;

		private List<string> m_QuestionsCommandList = null;
		public List<string> QuestionsCommandList { get { return m_QuestionsCommandList; } set { m_QuestionsCommandList = value; } }

		private List<string> m_DescriptionsCommandList = null;
		public List<string> DescriptionsCommandList { get { return m_DescriptionsCommandList; } set { m_DescriptionsCommandList = value; } }

		private int m_ElementNumber = 0;
		public int ElementNumber {get{ return m_ElementNumber; } set{ m_ElementNumber = value; }}

		private bool m_Abort = false;
		public bool Abort { get { return m_Abort; } set { m_Abort = value; } }

		private string m_DBpath = "";
		public string DBpath { get { return m_DBpath; } set { m_DBpath = value; } }

		/******************* global vars *******************/
		private SQLiteConnection oConn = null;
		private readonly string sQtableName = "fcc_exam_questions";
		private readonly string sDtableName = "fcc_element_descriptions";

		public clsSQLiteHandler(ToolStripStatusLabel StatusLabel)
		{
			txtStatus = StatusLabel;
		}

		public bool SaveData()
		{
			if (!MakeConnection()) return false;
			//--------------
			string sCmd = "";

			SQLiteCommand oCmd = new SQLiteCommand(oConn);

			//---- clear old data from tables
			string sElementNumber = m_ElementNumber.ToString("0");
			oCmd.CommandText = "delete from " + sDtableName + " where ElementNumber = " + sElementNumber;
			oCmd.ExecuteNonQuery();
			oCmd.CommandText = "delete from " + sQtableName + " where ElementNumber = " + sElementNumber;
			oCmd.ExecuteNonQuery();

			//---- now save the stuff
			int iCounter = 0;
			int iQuestionCount = m_QuestionsCommandList.Count;
			int iDescriptionCount = m_DescriptionsCommandList.Count;
			try
			{
				
				for (int iIndexer = 0; iIndexer < iQuestionCount;iIndexer++)
				{
					sCmd = m_QuestionsCommandList[iIndexer];
					Application.DoEvents();
					if (m_Abort)
					{
						return false;
					}
					iCounter++;
					if (iCounter % 13 == 0)
						txtStatus.Text = "Saving Data. Question #" + iCounter.ToString() + " of " + iQuestionCount.ToString() + " Total";
					oCmd.CommandText = sCmd;
					oCmd.ExecuteNonQuery();
				}
				iCounter = 0;
				for (int iIndexer = 0; iIndexer < iDescriptionCount; iIndexer++)
				{
					sCmd = m_DescriptionsCommandList[iIndexer];
					Application.DoEvents();
					if (m_Abort)
					{
						return false;
					}
					iCounter++;
					if (iCounter % 13 == 0)
						txtStatus.Text = "Saving Data. Description #" + iCounter.ToString() + " of " + iDescriptionCount.ToString() + " Total";
					oCmd.CommandText = sCmd;
					oCmd.ExecuteNonQuery();
				}
			}
			catch (Exception e3)
			{
				if (oConn != null)
					if (oConn.State == System.Data.ConnectionState.Open)
						oConn.Close();
				throw e3;
			}
			if (oConn != null)
				if (oConn.State == System.Data.ConnectionState.Open)
					oConn.Close();

			return true;
		}

		public bool TestSQLiteConnection()
		{
			if (!File.Exists(m_DBpath))
			{
				txtStatus.Text = "ERROR! database file not found";
				MessageBox.Show("ERROR! database file [" + m_DBpath + "] not found. Either it does not exist or it has been moved.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private bool MakeConnection()
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

	}  // end class

}  // end namespace

