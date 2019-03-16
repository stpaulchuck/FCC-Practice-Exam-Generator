using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TestPoolParser
{
	public class clsFcclDocParser
	{
		/******************* properties **********************/
		private List<string> m_DescriptionsCommands = null;
		public List<string> DescriptionsCommands {get{ return m_DescriptionsCommands; }set{ m_DescriptionsCommands = value; } }

		private List<string> m_QuestionsCommands = null;
		public List<string> QuestionsCommands {get{ return m_QuestionsCommands; }set{ m_QuestionsCommands = value; } }

		private string m_ElementNumber = "0";
		public int ElementNumber {get{ return int.Parse(m_ElementNumber);  }set{ m_ElementNumber = value.ToString("0"); } }

		/********************* global vars ********************/
		ToolStripStatusLabel txtStatus = null;
	//	bool bDBout = true;


		/********************* con/destructors ********************/
		public clsFcclDocParser(ToolStripStatusLabel StatusLabel)
		{
			txtStatus = StatusLabel;
		}

		
		/********************* public methods ********************/
		public void ParseTextFile(string DocumentText)
		{
			if (DocumentText.Length <= 0)
			{
				txtStatus.Text = "ERROR: no document text loaded!";
				return;
			}
			m_DescriptionsCommands.Clear();
			m_QuestionsCommands.Clear();

			string sGroup = "", sSubelement = "", sGraphicFileName = "";
			string[] splitArray = null;
			//---- parse and send text to proper subroutine
			StringReader sReader = new StringReader(DocumentText);
			string aLine = sReader.ReadLine();
			Match oMatch = null;

			try
			{
				while (aLine != null)
				{
					Application.DoEvents();
					aLine = aLine.Trim();
					if (aLine != "")
					{
						//---- determine if entry is desc. or question
						if (aLine.Length >= 9) //---> test questions?
						{
							if (aLine.IndexOf(' ') == 5 && aLine.IndexOf('(') > -1 && aLine.IndexOf(')') > -1) // question header line
							{
								sGraphicFileName = "";
								if (aLine.Substring(0, 3) == sGroup) // it's a question number for this subgroup
								{
									List<string> qList = new List<string>
									{
										aLine
									};
									aLine = sReader.ReadLine();
									oMatch = Regex.Match(aLine, @"[Ff]igure [EGT]-?\d+-?\d*", RegexOptions.None);
									if (oMatch.Success)
									{ sGraphicFileName = oMatch.Value; }
									qList.Add(aLine);
									aLine = sReader.ReadLine();
									while (aLine.Substring(1, 1) == ".")
									{
										oMatch = Regex.Match(aLine, @"[Ff]igure [EGT]-?\d+-?\d*", RegexOptions.None);
										if (oMatch.Success)
										{ sGraphicFileName = oMatch.Value; }
										qList.Add(aLine);
										aLine = sReader.ReadLine();
										if (aLine == null)
											break;
										if (aLine.Length < 2)
											break;
									}
									qList.Add(sGraphicFileName);
									if (qList.Count < 7)
									{
										Debug.WriteLine("ERROR: question " + qList[0] + " did not parse correctly. \rn" + qList[0]);
										throw new Exception("Error: question " + qList[0] + " did not parse correctly. Run again in Debug mode for data.");
									}
									CreateTestQuestionCommands(qList);
									continue;
								}  // if 0,3 == sGroup
							}  // if index of " " == 5
								//---- so then, not a question, is it a description?
							if (aLine.Length > 10) //----> description?
							{
								if (aLine.Substring(0, 10).ToUpper() == "SUBELEMENT")
								{
									splitArray = aLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
									if (splitArray.Length < 3)
									{
										txtStatus.Text = "ERROR in input file - subelement";
										MessageBox.Show("Error in input file - subelement", "ERROR");
										return;
									}
									sSubelement = splitArray[1];
									CreateDescriptionsCommands(aLine);
								}
								if (aLine.Substring(3, 1) == " " && aLine.Substring(0, 2) == sSubelement) // group description
								{
									sGroup = aLine.Substring(0, 3);
									CreateDescriptionsCommands(aLine);
								}
							}  // if len > 10
						}  // if len > 9
					}  // end if aline != ""
					aLine = sReader.ReadLine();
				} // end while()
			}
			catch (Exception e5)
			{
				Debug.WriteLine("error in ParseTextFile" + e5.Message + "... " + e5.StackTrace);
				throw;
			}
			txtStatus.Text = "Text Question commands parsed.";
		}

		/********************** private methods *******************/

		/// <summary>
		/// creates a batch file of insert commands for the questions to be saved
		/// </summary>
		/// <param name="InputText"></param>
		private void CreateTestQuestionCommands(List<string> InputText)
		{
			// ElementNumber int(11),QuestionNumber varchar(8),TestQuestion, AnswerA,AnswerB,AnswerC,AnswerD,CorrectAnswer char(1),
			// GraphicName varchar(128),QuestionReference varchar(64)

			string[] splitArray = null;
			string sSQLFormatString = "Insert into fcc_exam_questions Values ( " + m_ElementNumber + ", '{0}', '{1}', "
				 + "'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')";
			string sTextFormatString = m_ElementNumber + "|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}";
			int iIndexer = 0;

			try
			{
				// question header: qNum, corrAns, references
				splitArray = InputText[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string QuestionNumber = splitArray[0];
				string sCorrectAnswer = splitArray[1].Substring(1, 1); // skip '('
				string Reference = "";
				if (splitArray.Length >= 3)
					Reference = splitArray[2];
				if (splitArray.Length == 4)
					Reference += " " + splitArray[3];
				Reference = Reference.Replace("[", "");
				Reference = Reference.Replace("]", "");
				if (Reference.Contains(","))
				{
					Reference = Reference.Replace(",", ";");
				}

				string QuestionText = "";
				QuestionText = EscapeStringNew(InputText[1]);

				string[] Answers = new string[4];
				for (iIndexer = 2; iIndexer < (InputText.Count-1); iIndexer++)
				{
					Answers[iIndexer - 2] = EscapeStringNew(InputText[iIndexer].Substring(3));
				}
				string GraphicName = InputText[6];  // find references to graphic name in TQ's
				GraphicName = EscapeStringNew(GraphicName);
				object[] Params = new object[9];
				Params[0] = QuestionNumber;
				Params[1] = QuestionText;
				Params[2] = Answers[0];
				Params[3] = Answers[1];
				Params[4] = Answers[2];
				Params[5] = Answers[3];
				Params[6] = sCorrectAnswer;
				Params[7] = GraphicName;
				Params[8] = EscapeStringNew(Reference);
				string sOutput = "";
				sOutput = String.Format(sSQLFormatString, Params);
				m_QuestionsCommands.Add(sOutput);
			}
			catch (Exception e8)
			{
				Debug.WriteLine("error in createtestquestioncommands " + e8.Message + "  stacktrace: " + e8.StackTrace);
				throw;
			}
		}

		/// <summary>
		/// creates a batch file of commands for descriptions to be saved
		/// </summary>
		/// <param name="InputText"></param>
		private void CreateDescriptionsCommands(string InputText)
		{
			string[] splitArray = null;
			string sDataFormatString = "Insert into fcc_element_descriptions (ElementNumber, SubElementName, GroupName, DescriptiveText) "
				 + "Values (" + m_ElementNumber + ", '{0}', '{1}', '{2}')";
			string sTextFormatString = m_ElementNumber + "|{0}|{1}|{2}";
			string SubelementName = "", GroupName = "", CommentText = "", sFinder = "";

			InputText = InputText.Replace("--", "-");
			splitArray = InputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (splitArray[0] == "SUBELEMENT")
			{
				SubelementName = splitArray[1];
				GroupName = "0";

				if (splitArray[2] == "-")
				{
					sFinder = splitArray[3];
				}
				else
				{
					sFinder = splitArray[2];
				}
				CommentText = InputText.Substring(InputText.IndexOf(sFinder));
			}
			else // it's a group def.
			{
				SubelementName = splitArray[0].Substring(0, 2);
				GroupName = splitArray[0];
				CommentText = InputText.Trim();
				if (splitArray[1] == "-")
				{
					sFinder = splitArray[2];
				}
				else
				{
					sFinder = splitArray[1];
				}
				CommentText = InputText.Substring(InputText.IndexOf(sFinder));
			}
			CommentText = EscapeStringNew(CommentText);
			string sOutput = "";
			sOutput = String.Format(sDataFormatString, SubelementName, GroupName, CommentText);
			m_DescriptionsCommands.Add(sOutput);
		}

		private static string EscapeStringNew(string value)
		{
			/*
			if (value.Contains("’"))
			{ value = value.Replace("’", "’’"); }

			if (value.Contains("‘"))
			{ value = value.Replace("‘", "‘‘"); }
			*/
			if (value.Contains("'"))
			{ value = value.Replace("'", "''"); }
			return value;
			/*
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i] == '\\'
					|| value[i] == '\''
					|| value[i] == '\"'
				)
					sb.Append("\\");
				sb.Append(value[i]);
			}
			return sb.ToString();
			*/
		}


	}  //   end class

}  //  end namespace
