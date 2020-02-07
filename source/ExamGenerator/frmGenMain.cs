using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace ExamGenerator
{
	/*************************************************************************************************/
	/*  FCC Exam Generator, copyright © 2015, 2019, 2020 Charles H Fisher Jr., South St. Paul, MN    */
	/*************************************************************************************************/
	/*                   all rights reserved; you may use this code in your own                      */
	/*                   projects but a reference to my copyright is required                        */
	/*                   under the GNU General Public License Version 3 or later                     */
	/*************************************************************************************************/

	public partial class frmGenMain : Form
	{
		/**************************** vars ***************************************/
		enum TestType { Regular, SubelementTest };
		bool bInitializing = true;
		DataTable oDescTable = new DataTable(), oQTable = new DataTable(); // holds selected element data
		DataTable oDescMasterTable = new DataTable(), oQMasterTable = new DataTable(); // holds all data
		Timer oTimeDelay = new Timer();
		frmOutputFileName OutputFileForm = new frmOutputFileName();
		Dictionary<int, int> dicElementQamt = new Dictionary<int, int>();
		string sDBfilepath = "";
		clsSQLiteHandler SqlHandler = null;

		/**************************** constructor ********************************/
		public frmGenMain()
		{
			InitializeComponent();
			OutputFileForm.Hide();
			SqlHandler = new clsSQLiteHandler(this.txtStatus);
		}


		/****************************** events ************************************/
		private void btnSelectDB_Click(object sender, EventArgs e)
		{
			txtStatus.Text = "Attempting to locate data file.";
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
				FetchMasterData(); // new file so load it
			}
		}

		private void frmGenMain_Shown(object sender, EventArgs e)
		{
			bInitializing = true;

			//------- load any saved values
			LoadSettings();

			//------ input intial data
			btnRun.Enabled = FetchMasterData();

			/*timer is used to prevent racing conditions loading UI objects with data*/
			//----- timer setups
			oTimeDelay.Enabled = true;
			oTimeDelay.Stop();
			oTimeDelay.Interval = 1500;
			oTimeDelay.Tick += oTimeDelay_Tick;
			txtNumberOfQuestions.Text = dicElementQamt[(int)udElementNumber.Value].ToString("0");
			//------ done
			bInitializing = false;
		}

		private void frmGenMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.DoEvents();
			/*
			Properties.Settings.Default.DescriptionsFileName = "";
			Properties.Settings.Default.QuestionsFileName = "";
			Properties.Settings.Default.Save();
			*/
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			btnRun.Enabled = false;
			if (udElementNumber.Value <= 1)
			{
				txtStatus.Text = "Need Element Number!";
				MessageBox.Show(this, "Please set the Element number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				btnRun.Enabled = true;
				return;
			}
			if (oQTable.Rows.Count == 0)
			{
				txtStatus.Text = "No questions available for this Element";
				MessageBox.Show(this, "There are no questions in the file for Element " + udElementNumber.Value.ToString("0"));
				return;
			}
			if (rbElectronicExam.Checked)
			{
				this.WindowState = FormWindowState.Minimized;
			}
			bool retVal = CreateExam();
			if (rbElectronicExam.Checked)
			{
				this.WindowState = FormWindowState.Normal;
			}
			this.BringToFront();
			this.Focus();
			btnRun.Enabled = true;
			if (!retVal)
				return;
			SaveSettings();
		}

		private void rbRegularTest_CheckedChanged(object sender, EventArgs e)
		{
			if (rbRegularTest.Checked)
			{
				Properties.Settings.Default.LastTestType = TestType.Regular.ToString();
			}
			else
			{
				Properties.Settings.Default.LastTestType = TestType.SubelementTest.ToString();
			}
			Properties.Settings.Default.Save();
			if (chkAllQuestions.Checked)
			{
				chkAllQuestions_CheckedChanged(null, EventArgs.Empty);
			}
		}

		private void chkAllQuestions_CheckedChanged(object sender, EventArgs e)
		{
			if (bInitializing) return;

			if (chkAllQuestions.Checked)
			{
				string sWhereClause = "";
				if (rbSubelementTest.Checked)
				{
					sWhereClause = "questionnumber like '" + cmbSubelements.Text + "*'";
				}
				var iCount = oQTable.Select(sWhereClause).Length;

				if (MessageBox.Show(this, "Are you sure you want all " + iCount.ToString() + " questions?", "Warning!", MessageBoxButtons.OKCancel
					 , MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
				{
					chkAllQuestions.Checked = false;
				}
				else
				{
					txtNumberOfQuestions.Text = iCount.ToString("0");
				}
			}
		}

		private void udElementNumber_ValueChanged(object sender, EventArgs e)
		{
			if (bInitializing) return;
			oTimeDelay.Stop();
			if (udElementNumber.Value > 1)
			{
				btnRun.Enabled = false;
				Application.DoEvents();
				oTimeDelay.Start();
			}
			else
			{
				btnRun.Enabled = true;
			}
			Application.DoEvents();
		}

		private void cmbSubelements_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bInitializing) return;
			DisplaySubelementDescription();
		}

		void oTimeDelay_Tick(object sender, EventArgs e)
		{
			bInitializing = true;
			oTimeDelay.Stop();
			FetchElementQuestions();
			FetchSubElementDescriptions();
			if (oQTable.Rows.Count > 0 && oDescTable.Rows.Count > 0)
			{
				txtNumberOfQuestions.Text = dicElementQamt[(int)udElementNumber.Value].ToString("0");
				btnRun.Enabled = true;
			}
			else
			{
				txtNumberOfQuestions.Text = "0";
				btnRun.Enabled = false;
				txtStatus.Text = "Insufficient data for Element " + udElementNumber.Value.ToString("0");
			}
			bInitializing = false;
			Application.DoEvents();
		}

		private void cmbSubelements_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			DisplaySubelementDescription();
			if (chkAllQuestions.Checked)
			{
				chkAllQuestions_CheckedChanged(null, EventArgs.Empty);
			}
		}

		//********************** private methods ***********************

		private bool FetchElementQuestions()
		{
			if (udElementNumber.Value < 2)
			{
				MessageBox.Show(this, "Not a valid element number.", "Input Error");
				return false;
			}
			string sElementNumber = udElementNumber.Value.ToString();
			txtStatus.Text = "fetching questions for element " + sElementNumber;
			Application.DoEvents();
			oQTable.Clear();
			try
			{
				if (oQMasterTable.Rows.Count > 0)
				{
					DataRow[] oResults = oQMasterTable.Select("ElementNumber = " + sElementNumber);
					if (oResults.Length > 0)
					{
						oQTable = oResults.CopyToDataTable();
					}
				}
				if (oQTable.Rows.Count == 0)
				{
					MessageBox.Show(this, "No questions found for Element Number " + sElementNumber);
					return false;
				}
			}
			catch (Exception e7)
			{
				txtStatus.Text = "Error reading questions.";
				MessageBox.Show(this, "Error fetching questions: " + e7, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			txtStatus.Text = "completed fetching questions for element " + udElementNumber.Value.ToString();
			return true; // default for good fetch
		}

		private void FetchSubElementDescriptions()
		{
			bInitializing = true;
			cmbSubelements.Items.Clear();
			cmbSubelements.Text = "";
			txtSubelementDesc.Text = "";
			Application.DoEvents();
			oDescTable.Clear();

			DataRow[] oResults = oDescMasterTable.Select("ElementNumber = " + udElementNumber.Value.ToString("0"));
			if (oResults.Length > 0)
			{
				oDescTable = oResults.CopyToDataTable();
			}
			else
			{
				MessageBox.Show(this, "No Element Descriptions were found!", "Data Error");
				return;
			}
			foreach (DataRow oRow in oDescTable.Rows)
			{
				if (oRow.Field<string>("GroupName") == "0")
					cmbSubelements.Items.Add(oRow.Field<string>("SubElementName"));
			}
			cmbSubelements.Text = cmbSubelements.Items[0].ToString();
			if (Properties.Settings.Default.LastExamElement == udElementNumber.Value)
			{
				if (Properties.Settings.Default.LastSubElement != "")
					cmbSubelements.Text = Properties.Settings.Default.LastSubElement;
			}
			bInitializing = false;
			if (!cmbSubelements.Items.Contains(Properties.Settings.Default.LastSubElement))
			{
				cmbSubelements.Text = cmbSubelements.Items[0].ToString();
				Properties.Settings.Default.LastSubElement = cmbSubelements.Text;
				Properties.Settings.Default.Save();
			}
			DisplaySubelementDescription();
			txtStatus.Text = "completed fetching element " + udElementNumber.Value.ToString("0") + " descriptions";
		}

		private void DisplaySubelementDescription()
		{
			DataRow[] oRows = oDescTable.Select("SubElementName = '" + cmbSubelements.Text + "' and GroupName = '0'");
			txtSubelementDesc.Text = oRows[0].Field<string>("DescriptiveText");
		}

		private void LoadSettings()
		{
			try
			{
				dicElementQamt.Clear();
				char[] splitVal = new char[] { ',' };
				foreach (string s in Properties.Settings.Default.NumberOfQuestionsRequested)
				{
					string[] splitArray = s.Split(splitVal);
					dicElementQamt.Add(int.Parse(splitArray[0]), int.Parse(splitArray[1]));
				}
				if (!dicElementQamt.ContainsKey(0))
					dicElementQamt.Add(0, 0);
				if (!dicElementQamt.ContainsKey(1))
					dicElementQamt.Add(1, 0);
				if (Properties.Settings.Default.LastTestType == TestType.Regular.ToString())
					rbRegularTest.Checked = true;
				else
					rbSubelementTest.Checked = true;
				if (Properties.Settings.Default.LastOutputFolder != "")
					OutputFileForm.txtOutputFolder.Text = Properties.Settings.Default.LastOutputFolder;
				if (Properties.Settings.Default.LastOutputFile != "")
					OutputFileForm.txtOutputFileName.Text = Properties.Settings.Default.LastOutputFile;
				if (Properties.Settings.Default.RandomDistrubtion)
					rbRandomDist.Checked = true;
				else
					rbEvenDist.Checked = true;
				chkAllQuestions.Checked = Properties.Settings.Default.AllQuestions;
				int iTemp = Properties.Settings.Default.LastExamElement;
				if (iTemp > 1)
				{
					udElementNumber.Value = iTemp;
					txtNumberOfQuestions.Text = dicElementQamt[iTemp].ToString("0");
				}
				else
					txtNumberOfQuestions.Text = "0";
				sDBfilepath = Properties.Settings.Default.DataFilePath;
				if (sDBfilepath.Contains("\\"))
				{
					txtDBname.Text = sDBfilepath.Substring(sDBfilepath.LastIndexOf("\\") + 1);
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("Error in LoadSettings(): " + e.Message + "   stacktrace = " + e.StackTrace);
				throw;
			}
		}

		private void SaveSettings()
		{
			dicElementQamt[(int)udElementNumber.Value] = int.Parse(txtNumberOfQuestions.Text);
			StringCollection oColl = new StringCollection();
			foreach (KeyValuePair<int, int> kvp in dicElementQamt)
			{
				oColl.Add(kvp.Key.ToString("0") + "," + kvp.Value.ToString("0"));
			}
			Properties.Settings.Default.NumberOfQuestionsRequested = oColl;
			Properties.Settings.Default.LastExamElement = (int)udElementNumber.Value;
			Properties.Settings.Default.LastOutputFile = OutputFileForm.txtOutputFileName.Text;
			Properties.Settings.Default.LastOutputFolder = OutputFileForm.txtOutputFolder.Text;
			Properties.Settings.Default.LastSubElement = cmbSubelements.Text;
			Properties.Settings.Default.LastTestType = (rbRegularTest.Checked ? TestType.Regular.ToString() : TestType.SubelementTest.ToString());
			Properties.Settings.Default.RandomDistrubtion = rbRandomDist.Checked;
			Properties.Settings.Default.AllQuestions = chkAllQuestions.Checked;
			Properties.Settings.Default.DataFilePath = sDBfilepath;
			Properties.Settings.Default.Save();
		}

		private bool CreateExam()
		{
			DataRow[] oSubnames = { };
			int iHowMany = -1;
			if (chkAllQuestions.Checked == false)
			{
				if (!int.TryParse(txtNumberOfQuestions.Text, out iHowMany))
				{
					MessageBox.Show(this, "Improper value for number of questions!", "Input Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}

			string sFilter = "";
			//---- first filter
			if (rbSubelementTest.Checked)
			{
				sFilter = "QuestionNumber like '" + cmbSubelements.Text + "*'";
			}
			DataRow[] oQRows = oQTable.Select(sFilter);
			if (iHowMany > oQRows.Length)
			{
				if (MessageBox.Show(this, "You have asked for more questions than I can generate. If you want me to truncate "
					 + "the number to " + oQRows.Length.ToString() + " then click OK, or Cancel to stop.", "Size Error",
					 MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
				{
					iHowMany = oQRows.Length;
					txtNumberOfQuestions.Text = iHowMany.ToString();
				}
				else
				{
					return false;
				}
			}
			//---- second filter set up
			sFilter = "";
			if (rbSubelementTest.Checked)
			{
				sFilter = "SubelementName = '" + cmbSubelements.Text + "' and ";
			}
			sFilter += "GroupName = '0'";
			if (oDescTable.Rows.Count > 0)
			{
				oSubnames = oDescTable.Select(sFilter);
			}
			else
			{
				oSubnames = new DataRow[] { };
			}
			//---- set up the printer
			if (rbTextFileExam.Checked)
			{
				if (Properties.Settings.Default.LastOutputFolder != "")
					OutputFileForm.txtOutputFolder.Text = Properties.Settings.Default.LastOutputFolder;
				if (Properties.Settings.Default.LastOutputFile != "")
					OutputFileForm.txtOutputFileName.Text = Properties.Settings.Default.LastOutputFile;
				if (OutputFileForm.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel)
				{
					MessageBox.Show(this, "User cancelled. Unable to save to file. Aborting.", "File path error.");
					return false;
				}
			}
			clsExamPrinter oPrinter = new clsExamPrinter(oQRows);
			oPrinter.HowMany = iHowMany;
			oPrinter.GroupInfo = oSubnames;
			oPrinter.OutputFileName = OutputFileForm.txtOutputFileName.Text;
			oPrinter.OutputFolderName = OutputFileForm.txtOutputFolder.Text;
			oPrinter.RandomSpread = rbRandomDist.Checked;
			oPrinter.RandomizeAnswers = Properties.Settings.Default.RandomizeAnswers;
			if (rbElectronicExam.Checked) oPrinter.OutputType = OutputTypeEnum.Desktop;
			else if (rbTextFileExam.Checked) oPrinter.OutputType = OutputTypeEnum.TxtFile;

			//---- do it!
			return oPrinter.PrintExam();
		}

		private bool FetchMasterData()
		{
			if (txtDBname.Text == "")
			{
				MessageBox.Show(this, "No database file selected. Please select one.", "DB error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}

			oQMasterTable.Clear();
			oDescMasterTable.Clear();
			if (SqlHandler.TestSqlConnection(sDBfilepath))
			{
				oQMasterTable = SqlHandler.GetQuestions();
				if (oQMasterTable.Rows.Count > 0)
				{
					oDescMasterTable = SqlHandler.GetDescriptions();
				}
			}

			if (oQMasterTable.Rows.Count <= 0)
			{
				MessageBox.Show(this, "No questions found in the database!!", "Data Error");
				txtStatus.Text = "No Questions Found!";
				return false;
			}
			else
			{
				oDescMasterTable = SqlHandler.GetDescriptions();
				if (oDescMasterTable.Rows.Count <= 0)
				{
					MessageBox.Show(this, "No descriptions found in the data source!!", "Data Error");
					txtStatus.Text = "No Descriptions Found!";
					return false;
				}
				if (udElementNumber.Value >= 2)
				{
					if (FetchElementQuestions())
					{
						FetchSubElementDescriptions();
					}
					txtNumberOfQuestions.Text = dicElementQamt[(int)udElementNumber.Value].ToString("0");
				}
			}
			return true;
		}

	}  // end class
}  // end namespace
