using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExamGenerator
{
	public enum OutputTypeEnum { Desktop, TxtFile, Paper };

	class clsExamPrinter : IDisposable
	{
		DataRow[] m_QuestionsPool = new DataRow[0];
		public int HowMany = 0;
		public bool RandomSpread = false;
		public string OutputFolderName = "";
		public string OutputFileName = "";
		public DataRow[] GroupInfo = new DataRow[0];
		public OutputTypeEnum OutputType = OutputTypeEnum.Desktop;
		public bool RandomizeAnswers = true;

		int iPoolSize = 0, iHowMany = 0;
		const int iTechGenTestSize = 35; // in case it changes, just one item to update
		const int iAmExtraTestSize = 50;
		frmElectronicExam ElectronicExamForm = new frmElectronicExam();

		public clsExamPrinter(DataRow[] QuestionsPool)
		{
			m_QuestionsPool = QuestionsPool;
			if (RandomizeAnswers)
				RandomizeTheAnswers();
		}

		public bool PrintExam()
		{
			iPoolSize = m_QuestionsPool.Length;
			iHowMany = HowMany;
			if (HowMany == -1)
				iHowMany = iPoolSize; // "all"
			DataRow oDRtemp = GroupInfo[0];
			try
			{
				if (RandomSpread)
					return PrintTheFile(RandomSelection());
				else
					return PrintTheFile(EvenSelection());
			}
			catch (Exception e)
			{
				MessageBox.Show("Error generating output file! " + e.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}

		private List<DataRow> RandomSelection()
		{
			Random oRnd = new Random();
			List<int> PickedList = new List<int>();
			int iPtr = -1; // random pointer into m_QuestionsPool
			PickedList.Add(-1);

			oRnd.Next(HowMany); // just a dummy to light it up

			DataRow[] retVal = new DataRow[HowMany];

			for (int iIndexer = 0; iIndexer < iHowMany; iIndexer++)
			{
				while (PickedList.Contains(iPtr))
				{
					iPtr = oRnd.Next(iPoolSize);
				}
				PickedList.Add(iPtr);
				retVal[iIndexer] = m_QuestionsPool[iPtr];
			}

			return retVal.ToList<DataRow>();
		}

		private List<DataRow> EvenSelection()
		{
			int iStandardTestSize = 0;
			string sChoice = m_QuestionsPool[0]["ElementNumber"].ToString();
			switch (sChoice)
			{
				case "2":
				case "3":
					iStandardTestSize = iTechGenTestSize;
					break;
				case "4":
					iStandardTestSize = iAmExtraTestSize;
					break;
				default:
					throw new Exception("No such element number: " + sChoice);
			}
			List<DataRow> retVal = new List<DataRow>(iHowMany);
			double fRatio = (double)iHowMany / (double)iStandardTestSize; // usually 35 questions
			Dictionary<string, int> SubElementQuantity = new Dictionary<string, int>(); // standard number of q's per subelement
			Dictionary<string, int> ElementGroupCount = new Dictionary<string, int>();
			int iRunningTotal = 0, iAdjustmentValue = 0;
			string[] splitArray = {};

			char cEnDash = Convert.ToChar(150);
			char cEmDash = Convert.ToChar(151);
			char cOddness = Convert.ToChar(65533);
			char[] caSplitter = new char[] { '-' };
			//char[] caSplitter = new char[] { cEmDash, cEnDash, cOddness };

			string sName = "", sTemp = "";
			DataRow oRow2 = null;
			try
			{
				foreach (DataRow oRow in GroupInfo)
				{
					oRow2 = oRow;
					sName = oRow.Field<string>("SubElementName");
					sTemp = oRow.Field<string>("DescriptiveText");
					sTemp = sTemp.Substring(sTemp.LastIndexOf('[') + 1);
					splitArray = sTemp.Split(caSplitter);
					if (splitArray.Length == 1)
					{
						splitArray = splitArray[0].ToString().Split(caSplitter);
					}
					sTemp = splitArray[0].Trim();
					sTemp = sTemp.Substring(0, sTemp.IndexOf(' '));
					int iHowManyQ = int.Parse(sTemp);
					sTemp = splitArray[1].Trim();
					sTemp = sTemp.Substring(0, sTemp.IndexOf(' '));
					int iHowManyG = int.Parse(sTemp);
					if (iHowManyQ != iHowManyG) // code will have to be changed if this ever turns true
						throw new Exception("number of questions not equal to number of subgroups - subelement " + sName);
					int iQcount = (int)Math.Round(fRatio * (double)iHowManyQ);
					SubElementQuantity.Add(sName, iQcount);
					ElementGroupCount.Add(sName, iHowManyG);
					iRunningTotal += iQcount;
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("SubElement: " + sName + " " + e);
				throw new Exception("SubElement: " + sName + " " + oRow2.Field<string>("DescriptiveText") + " Throws Error: " + e.Message);
			}
			if (iRunningTotal == 0)
				throw new Exception("no question count generated - ExamGenerator::EvenSelection()");
			if (iRunningTotal != iHowMany) // adjust up or down as needed
			{
				Random oRnd = new Random();
				iAdjustmentValue = (iRunningTotal < iHowMany ? 1 : -1); // add some or remove some?
				int iTemp = Math.Abs(iRunningTotal - iHowMany);
				int iDicLength = SubElementQuantity.Count - 1;
				Dictionary<string, int>.KeyCollection oKeys = SubElementQuantity.Keys;
				for (int iIndexer = 0; iIndexer < iTemp; iIndexer++)
				{
					string sKey = oKeys.ElementAt(oRnd.Next(0, SubElementQuantity.Count - 1));
					int iNum = SubElementQuantity[sKey];
					iNum += iAdjustmentValue;
					if (iNum < 0)
					{
						iNum = 0;
						iIndexer--;
						continue;
					}
					SubElementQuantity[sKey] = iNum;
				}
			}  // if irunningtotal != ihowmany
				//--------- now get the question rows to return
			List<string> QnumList = new List<string>();

			try
			{
				foreach (KeyValuePair<string, int> oEntry in SubElementQuantity)
				{
					QnumList.Clear();
					QnumList = (from DataRow oRow in m_QuestionsPool
									where oRow.Field<string>("QuestionNumber").Substring(0, 2) == oEntry.Key
									select oRow.Field<string>("QuestionNumber")).ToList<string>();
					int iGroupCount = ElementGroupCount[oEntry.Key]; // the normal number of q's in each group [G1=5]
					int iQCount = SubElementQuantity[oEntry.Key]; // then actual number of q's needed for each group (70 q's, G1=12)
					if (iQCount - iGroupCount == 0) // simplest
					{

						List<DataRow> qList = GetIntegral(1, QnumList);
						foreach (DataRow dr in qList)
						{
							retVal.Add(dr);
						}
						qList.Clear();
					}
					else if (iQCount < iGroupCount)
					{
						List<DataRow> qList = GetRemainder(iQCount, QnumList);
						foreach (DataRow dr in qList)
						{
							retVal.Add(dr);
						}
						qList.Clear();
					}
					else if (iQCount > iGroupCount)
					{
						int iTemp = iQCount / iGroupCount;
						List<DataRow> qList = GetIntegral(iTemp, QnumList);
						foreach (DataRow dr in qList)
						{
							retVal.Add(dr);
						}
						iTemp = iQCount - qList.Count; // this balances for subgroups with less than the average q's
						qList.Clear();
						//iTemp = iQCount % iGroupCount;
						qList = GetRemainder(iTemp, QnumList);
						foreach (DataRow dr in qList)
						{
							retVal.Add(dr);
						}
						qList.Clear();
					}
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				throw;
			}
			//---------
			return retVal;
		}

		private List<DataRow> GetIntegral(int QperGroup, List<string> QuestionNumList)
		{
			List<DataRow> retVal = new List<DataRow>(); // question pick list

			//------ first get the names of the Groups
			List<string> GroupList = (from string sNext in QuestionNumList
											  select sNext.Substring(0, 3)).Distinct<string>().ToList<string>();
			Random oRnd = new Random();

			int iQcount = 0;
			string qName = "", sSubKey = "";
			List<string> groupQnumList = null;
			try
			{
				foreach (string s in GroupList)
				{
					sSubKey = s;
					//------ now get the questions for each group
					groupQnumList = (from string sAnyPick in QuestionNumList
										  where sAnyPick.Substring(0, 3) == sSubKey
										  select sAnyPick).ToList<string>();
					//------ then randomly pick the QperGroup number of question numbers
					iQcount = groupQnumList.Count;
					for (int jdex = 0; jdex < QperGroup; jdex++)
					{
						qName = groupQnumList[oRnd.Next(0, iQcount)];
						// linq query on m_questionspool where quest. number = random select from numlist
						List<DataRow> oSelectedRow = (from DataRow oRow in m_QuestionsPool
																where oRow.Field<string>("QuestionNumber") == qName
																select oRow).ToList<DataRow>();
						foreach (DataRow r in oSelectedRow)
						{
							retVal.Add(r);
						}
						// now bleep out the num list item we chose
						groupQnumList.Remove(qName);
						groupQnumList.TrimExcess();
						QuestionNumList.Remove(qName);
						QuestionNumList.TrimExcess();
						iQcount = groupQnumList.Count;
						if (groupQnumList.Count <= 0) // underflow test
							break;
					}
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				throw;
			}
			//------ finally return the pick list

			return retVal;
		}

		private List<DataRow> GetRemainder(int Qcount, List<string> QuestionNumList)
		{
			Random oRnd = new Random();

			List<DataRow> retVal = new List<DataRow>();
			for (int iIndexer = 0; iIndexer < Qcount; iIndexer++)
			{
				string qName = QuestionNumList[oRnd.Next(0, QuestionNumList.Count - 1)];
				// linq query on m_questionspool where quest. number = random select from numlist
				List<DataRow> oSelectedRow = (from DataRow oRow in m_QuestionsPool
														where oRow.Field<string>("QuestionNumber") == qName
														select oRow).ToList<DataRow>();
				foreach (DataRow r in oSelectedRow)
				{
					retVal.Add(r);
				}
				// now bleep out the num list item we chose
				QuestionNumList.Remove(qName);
			}

			return retVal;
		}

		private bool PrintTheFile(List<DataRow> OutputPool)
		{
			switch (OutputType)
			{
				case OutputTypeEnum.Desktop:
					return UseElectronicForm(OutputPool);
				case OutputTypeEnum.TxtFile:
					return SaveToTxtFile(OutputPool);
				case OutputTypeEnum.Paper:
				default:
					MessageBox.Show("Output type " + OutputType.ToString() + " not impletmented yet!", "Error");
					break;
			}
			return false;
		}

		private bool SaveToTxtFile(List<DataRow> Questions)
		{
			string sKeyFileName = OutputFileName;
			sKeyFileName = sKeyFileName.ToLower().Replace(".txt", "");
			sKeyFileName = sKeyFileName + " - answer key.txt";
			if (OutputFileName.Length < 5 || OutputFileName.Substring(OutputFileName.Length - 4) != ".txt")
			{
				OutputFileName = OutputFileName + ".txt";
			}
			StreamWriter oWriter = new StreamWriter(OutputFolderName + "\\" + OutputFileName, false);
			string sOutputText = "";
			switch (Questions[0].Field<int>("ElementNumber").ToString())
			{
				case "2":
					sOutputText = "FCC Technician License Eam";
					break;
				case "3":
					sOutputText = "FCC General License Exam";
					break;
				case "4":
					sOutputText = "FCC Amateur Extra Exam";
					break;
				default:
					sOutputText = "Unknown Test Element";
					break;
			}
			oWriter.WriteLine(sOutputText); // write the title
			oWriter.WriteLine(""); // add a line space
			oWriter.WriteLine("[Circle the correct answer.]");
			oWriter.WriteLine("");
			int iQuestionNumber = 1; // for numbering and answer key
			List<string> AnswerKey = new List<string>();
			foreach (DataRow oRow in Questions)
			{
				sOutputText = iQuestionNumber.ToString() + ". " + oRow.Field<string>("TestQuestion")
					 + " [" + oRow.Field<string>("QuestionNumber") + "]";
				oWriter.WriteLine(sOutputText);
				sOutputText = "\tA. " + oRow.Field<string>("AnswerA");
				oWriter.WriteLine(sOutputText);
				sOutputText = "\tB. " + oRow.Field<string>("AnswerB");
				oWriter.WriteLine(sOutputText);
				sOutputText = "\tC. " + oRow.Field<string>("AnswerC");
				oWriter.WriteLine(sOutputText);
				sOutputText = "\tD. " + oRow.Field<string>("AnswerD");
				oWriter.WriteLine(sOutputText);
				oWriter.WriteLine("");
				AnswerKey.Add(iQuestionNumber.ToString("0") + ". " + oRow.Field<string>("CorrectAnswer"));
				iQuestionNumber++;
			}
			oWriter.Flush();
			oWriter.Close();
			//---- now the answer key
			oWriter = new StreamWriter(OutputFolderName + "\\" + sKeyFileName, false);
			oWriter.WriteLine("Exam Answer Key for - " + OutputFileName);
			oWriter.WriteLine("");
			foreach (string s in AnswerKey)
			{
				oWriter.WriteLine(s);
			}
			oWriter.Flush();
			oWriter.Close();
			return true;
		}

		private bool UseElectronicForm(List<DataRow> Questions)
		{
			try
			{
				ElectronicExamForm.QuestionPool = Questions;
				if (ElectronicExamForm.ShowDialog() == DialogResult.OK)
					return true;
				else
					return false;
			}
			catch (Exception e)
			{
				MessageBox.Show("Publishing the exam failed!! Error: " + e.Message);
				return false;
			}
		}

		private void RandomizeTheAnswers()
		{
			Random rnd = new Random();
			string[] cAnsList = { "A", "B", "C", "D" };
			for (int iIndexer = 0; iIndexer < m_QuestionsPool.Length; iIndexer++)
			{
				DataRow dr = m_QuestionsPool[iIndexer];
				string cAns = dr.Field<string>("CorrectAnswer");
				string sCorrAns = dr.Field<string>("Answer" + cAns);
				string cSwapAns = cAnsList[rnd.Next(0, 3)];
				if (cSwapAns == cAns) continue;
				dr.SetField<string>("Answer" + cAns, dr.Field<string>("Answer" + cSwapAns));
				dr.SetField<string>("Answer" + cSwapAns, sCorrAns);
				dr.SetField<string>("CorrectAnswer", cSwapAns);
			}
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
				if (ElectronicExamForm != null)
					ElectronicExamForm.Dispose();
			}
		}

	}  // end class
}  // end namespace
