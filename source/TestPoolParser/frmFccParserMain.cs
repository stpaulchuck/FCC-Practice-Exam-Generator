using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TestPoolParser
{
	/*************************************************************************************************/
	/*    FCC Exam Pool Parser, copyright © 2015, 2019 Charles H Fisher Jr., South St. Paul, MN      */
	/*************************************************************************************************/
	/*                   all rights reserved; you may use this code in your own                      */
	/*                   projects but a reference to my copyright is required                 c       */
	/*                   under the GNU General Public License Version 3 or later                     */
	/*************************************************************************************************/

	public partial class frmFccParserMain : Form
	{
		//******************* global vars **************************
		List<string> QuestionsCommandList = new List<string>(); // for MySQL commands
		List<string> DescriptionsCommandList = new List<string>(); // element descriptions
		string sDocumentText = "", sCurrentInputFilePath = "", sDBfilepath = "";
		//clsTextOutputHandler oTextHandler = null;
		clsSQLiteHandler oSQLiteHandler = null;
		clsFcclDocParser oDocParser = null;
		bool bInitializing = true;
		int iElementNumber = 0;
		
		
		//**************** contstructor ***************************
		public frmFccParserMain()
		{
			InitializeComponent();
			//oTextHandler = new clsTextOutputHandler();
			oSQLiteHandler = new clsSQLiteHandler(txtStatus);
			oDocParser = new clsFcclDocParser(txtStatus);
			bInitializing = false;
		}


		//******************** event handlers **********************
		private void frmParserMain_Shown(object sender, EventArgs e)
		{
			int iPtr = -1;
			//------- load any saved values
			sDBfilepath = Properties.Settings.Default.DataFilePath;
			oSQLiteHandler.DBpath = sDBfilepath;
			if (sDBfilepath != "")
			{
				iPtr = sDBfilepath.LastIndexOf("\\") + 1;
				if (!File.Exists(sDBfilepath))
				{
					iPtr = -99;
				}
				if (iPtr > 0)
				{
					txtDBname.Text = sDBfilepath.Substring(iPtr);
				}
				else
				{
					txtDBname.Text = "{ data file location not set! }";
				}
			}
			else
			{
				txtDBname.Text = "{ data file location not set! }";
			}
			sCurrentInputFilePath = Properties.Settings.Default.LastInputFile;
			if (sCurrentInputFilePath != "")
			{
				if (!sCurrentInputFilePath.Contains("\\"))
				{
					sCurrentInputFilePath = "";
					Properties.Settings.Default.LastInputFile = "";
					Properties.Settings.Default.Save();
					txtStatus.Text = "Stored input file path bad.";
					MessageBox.Show(this, "Stored input file path bad. Reselect file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtFileName.Text = " { no file selected } ";
				}
				else
				{
					txtFileName.Text = sCurrentInputFilePath.Substring(sCurrentInputFilePath.LastIndexOf("\\") + 1);
				}
			}
			if (File.Exists(sCurrentInputFilePath))
			{
				bInitializing = true;
				if (LoadSourceFile(sCurrentInputFilePath))
				{
					txtStatus.Text = "Input file loaded. Idle...";
				}
				else
				{
					txtFileName.Text = "{ no file loaded }";
				}
				bInitializing = false;
			}
			else
			{
				txtFileName.Text = "{no file name}";
				Properties.Settings.Default.DataFilePath = "";
				Properties.Settings.Default.Save();
				txtStatus.Text = "Failed to load input file!";
			}

		}

		private void frmParserMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			QuestionsCommandList.Clear();
			DescriptionsCommandList.Clear();
		}

		private void btnFindInputFile_Click(object sender, EventArgs e)
		{
			FindInputFile();
		}

		private void btnSelectDB_Click(object sender, EventArgs e)
		{
			txtStatus.Text = "Attempting to locate SQLite db file.";
			string sTemp = sDBfilepath;
			if (sTemp.Length > 3) // try to load the folder name
			{
				int iIndexer = sTemp.LastIndexOf('\\');
				sTemp = sTemp.Substring(0, iIndexer);
			}
			else
				sTemp = "\\";
			OpenFileDialog oDlg = new OpenFileDialog();
			if (!Directory.Exists(sTemp))
			{ sTemp = Application.StartupPath; }
			oDlg.InitialDirectory = sTemp;
			oDlg.Multiselect = false;
			oDlg.Filter = "fcc_exam_data.db|fcc_exam_data.db"; // only fcc_exam_data.db
			if (oDlg.ShowDialog(this) == DialogResult.OK)
			{
				sDBfilepath = oDlg.FileName;
				txtDBname.Text = sDBfilepath.Substring(sDBfilepath.LastIndexOf("\\") + 1);
				Properties.Settings.Default.DataFilePath = oDlg.FileName;
				Properties.Settings.Default.Save();
				txtStatus.Text = "File Found";
				oSQLiteHandler.DBpath = sDBfilepath;
			}
			else
			{
				sDBfilepath = "";
				txtDBname.Text = "{ no file identfied }";
				Properties.Settings.Default.DataFilePath = "";
				Properties.Settings.Default.Save();
				txtStatus.Text = "SQLite db file not identified.";
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnAbort_Click(object sender, EventArgs e)
		{
			txtStatus.Text = "User aborted!";
			throw new Exception("abort function not written!");
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			if (iElementNumber == 0)
			{
				MessageBox.Show(this, "You must set the Element Number value first!", "Missing Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtStatus.Text = "Set the Element Number";
				return;
			}
			txtStatus.Text = "Starting parser run...";
			btnRun.Enabled = false;
			if (iElementNumber < 2 || iElementNumber > 4)
			{
				txtStatus.Text = "Unusable element number!!";
				MessageBox.Show(this, "Error with element number: out of range of 1 to 4", "ERROR");
				btnRun.Enabled = true;
				return;
			}
			//---- validate MySql connection works
			if (!ValidateMySqlReady())
			{
				txtStatus.Text = "Parse Cancelled";
				MessageBox.Show(this, "Parse is cancelled.", "SQL Server Error");
				return;
			}

			//---- parse the file and save the info to the tables
			try
			{
				oDocParser.ElementNumber = (int)iElementNumber;
				oDocParser.DescriptionsCommands = DescriptionsCommandList;
				oDocParser.QuestionsCommands = QuestionsCommandList;
				oDocParser.ParseTextFile(sDocumentText);  //, rbOutput2DB.Checked);
				SaveQuestionsToMySQL();
			}
			catch (Exception e5)
			{
				txtStatus.Text = "Error creating or saving questions!!";
				MessageBox.Show(this, "Error creating or saving questions: " + e5.Message, "ERROR");
				btnRun.Enabled = true;
				return;
			}

			//-------- if successful, save input property values
			if (sCurrentInputFilePath != "")
				Properties.Settings.Default.LastInputFile = sCurrentInputFilePath;
			Properties.Settings.Default.LastExamElement = (int)iElementNumber;
			Properties.Settings.Default.Save();
			btnRun.Enabled = true;
			txtStatus.Text = "Completed parsing run successfully.";
		}

		//********************** private methods ***********************

		private void SaveQuestionsToMySQL()
		{
			txtStatus.Text = "Saving Data.";
			//-------- set working values
			oSQLiteHandler.QuestionsCommandList = QuestionsCommandList;
			oSQLiteHandler.DescriptionsCommandList = DescriptionsCommandList;
			oSQLiteHandler.ElementNumber = (int)iElementNumber;
			oSQLiteHandler.DBpath = sDBfilepath;
			//-------- now do it
			oSQLiteHandler.SaveData();
		}

		private bool LoadSourceFile(string FullPath)
		{
			Application.DoEvents();
			sDocumentText = "";
			StreamReader oReader = null;
			try
			{
				oReader = new StreamReader(FullPath, System.Text.Encoding.UTF8, false);
				sDocumentText = oReader.ReadToEnd();
			}
			catch (Exception d)
			{
				MessageBox.Show(this, "Failed to load input file! - " + d.Message);
				txtStatus.Text = "ERROR: Failed to load input file.";
				return false;
			}
			finally
			{
				if (oReader != null)
				{
					oReader.Close();
					oReader.Dispose();
				}
			}
			//------- clean up odd characters if any in text file
			char cRightSingleQuote = Convert.ToChar(146);
			char cLeftSingleQuote = Convert.ToChar(145);
			char cEnDash = Convert.ToChar(150);
			char cEmDash = Convert.ToChar(151);
			char LQuote = Convert.ToChar(147);
			char RQuote = Convert.ToChar(148);
			string cOddness = Convert.ToChar(65533).ToString();
			sDocumentText = sDocumentText.Replace(cRightSingleQuote, '\'');
			sDocumentText = sDocumentText.Replace(cLeftSingleQuote, '\'');
			sDocumentText = sDocumentText.Replace(cEnDash, '-');
			sDocumentText = sDocumentText.Replace(cEmDash, '-');
			sDocumentText = sDocumentText.Replace(LQuote, '"');
			sDocumentText = sDocumentText.Replace(RQuote, '"');
			sDocumentText = sDocumentText.Replace(cOddness, "-");
			Application.DoEvents();
			//----- done
			if (bInitializing)
			{
				int iTestVal = Properties.Settings.Default.LastExamElement;
				if (iTestVal > 1 && iTestVal < 5)
				{
					iElementNumber = iTestVal;
					cmbElementNumber.Text = iElementNumber.ToString();
					Application.DoEvents();
				}
			}
			else
			{
				iElementNumber = 0;
				Application.DoEvents();
				StringReader oStringReader = new StringReader(sDocumentText);
				string sTemp = "";
				Match oMatch = null;
				for (int iIndexer = 0; iIndexer < 10; iIndexer++)
				{
					sTemp = oStringReader.ReadLine().Trim();
					if (sTemp.Length < 2) continue;
					sTemp = sTemp.Substring(0, 2);
					oMatch = Regex.Match(sTemp, @"[ETG]\d");
					if (oMatch.Success)
					{
						sTemp = oMatch.ToString()[0].ToString();
						switch (sTemp)
						{
							case "T":
								iElementNumber = 2;
								break;
							case "G":
								iElementNumber = 3;
								break;
							case "E":
								iElementNumber = 4;
								break;
						}
						cmbElementNumber.Text = iElementNumber.ToString();
						break;
					}
				}
				if (iElementNumber == 0)
				{
					MessageBox.Show(this, "Malformed document. Unable to find Element type (T,G,E).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtStatus.Text = "Error! Malformed Document.";
					return false;
				}
				Properties.Settings.Default.LastExamElement = iElementNumber;
				Properties.Settings.Default.Save();
				Application.DoEvents();
			}
			txtStatus.Text = "File to parse loaded. Idle...";
			return true;
		}

		private void cmbElementNumber_TextChanged(object sender, EventArgs e)
		{
			iElementNumber = int.Parse(cmbElementNumber.Text);
			Properties.Settings.Default.LastExamElement = iElementNumber;
			Properties.Settings.Default.Save();
		}

		private void FindInputFile()
		{
			txtStatus.Text = "Attempting to locate file to parse.";
			string sTemp = sCurrentInputFilePath;
			if (sTemp.Length > 3) // try to load the folder name
			{
				int iIndexer = sTemp.LastIndexOf('\\');
				sTemp = sTemp.Substring(0, iIndexer);
			}
			else
				sTemp = "\\";
			OpenFileDialog oDlg = new OpenFileDialog();
			if (!Directory.Exists(sTemp))
			{ sTemp = Application.StartupPath; }
			oDlg.InitialDirectory = sTemp;
			oDlg.Multiselect = false;
			oDlg.Filter = "*.txt|*.txt"; // only plain text files (for now)
			if (oDlg.ShowDialog(this) == DialogResult.OK)
			{
				sCurrentInputFilePath = oDlg.FileName;
				txtFileName.Text = sCurrentInputFilePath.Substring(sCurrentInputFilePath.LastIndexOf("\\") + 1);
				if (!LoadSourceFile(oDlg.FileName))
				{
					txtFileName.Text = "{ no file loaded }";
					cmbElementNumber.Text = "0";
					return;
				}
				Properties.Settings.Default.LastInputFile = oDlg.FileName;
				Properties.Settings.Default.Save();
			}
			txtStatus.Text = "File Found";
		}

/*
 
		private bool SelectOutputFolder()
		{
			bool retVal = true;

			txtStatus.Text = "Attempting to select a folder.";
			string sTemp = sCurrentInputFilePath;
			if (sTemp.Length > 3) // try to load the folder name
			{
				int iIndexer = sTemp.LastIndexOf('\\');
				sTemp = sTemp.Substring(0, iIndexer);
			}
			else
				sTemp = "\\";
			FolderBrowserDialog oDlg = new FolderBrowserDialog();
			if (!Directory.Exists(sTemp))
			{ sTemp = Application.StartupPath; }
			oDlg.SelectedPath = sTemp;
			if (oDlg.ShowDialog(this) == DialogResult.OK)
			{
				txtOutputFolder.Text = oDlg.SelectedPath;
				Properties.Settings.Default.OutputFolder = oDlg.SelectedPath;
				Properties.Settings.Default.Save();
			}
			else
			{
				txtStatus.Text = "Folder Selection Aborted";
			}
			txtStatus.Text = "Output Folder Selected";
			return retVal;
		}


*/

		private bool ValidateMySqlReady()
		{
			bool bResults = oSQLiteHandler.TestSQLiteConnection();
			if (!bResults) btnRun.Enabled = true;
			return bResults;
		}


		/*
		private bool ValidateTextFileReady()
		{
			string sQfile = txtOutputFolder.Text + "\\" + txtQuestionFileName.Text + ".csv";
			string sDfile = txtOutputFolder.Text + "\\" + txtDescriptionFileName.Text + ".csv";
			return oTextHandler.ValidateTextFileReady(sQfile, sDfile);
		}

		*/

/*

		private void SaveQuestionsToFile()
		{
			oTextHandler.SaveQuestionsToFile((int)iElementNumber, QuestionsCommandList, DescriptionsCommandList);
		}

		private void FindQuestionFile()
		{
			OpenFileDialog oDlg = new OpenFileDialog();
			if (txtOutputFolder.Text != "")
			{
				if (Directory.Exists(txtOutputFolder.Text))
				{
					oDlg.InitialDirectory = txtOutputFolder.Text;
				}
			}
			oDlg.Filter = "*.csv|*.csv";
			oDlg.Multiselect = false;
			if (oDlg.ShowDialog(this) == DialogResult.OK)
			{
				txtQuestionFileName.Text = oDlg.SafeFileName.Replace(".csv", "");
				Properties.Settings.Default.OutputQFileName = txtQuestionFileName.Text;
				Properties.Settings.Default.Save();
			}
		}

		private void FindDescriptionFile()
		{
			OpenFileDialog oDlg = new OpenFileDialog();
			if (txtOutputFolder.Text != "")
			{
				if (Directory.Exists(txtOutputFolder.Text))
				{
					oDlg.InitialDirectory = txtOutputFolder.Text;
				}
			}
			oDlg.Filter = "*.csv|*.csv";
			oDlg.Multiselect = false;
			if (oDlg.ShowDialog(this) == DialogResult.OK)
			{
				txtDescriptionFileName.Text = oDlg.SafeFileName.Replace(".csv", "");
				Properties.Settings.Default.OutputDFileName = txtDescriptionFileName.Text;
				Properties.Settings.Default.Save();
			}
		}

*/
	}  // end class
} // end namespace
