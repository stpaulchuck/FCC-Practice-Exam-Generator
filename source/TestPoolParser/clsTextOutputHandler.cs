using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TestPoolParser
{
	class clsTextOutputHandler
	{

		public string QuestionFileName = "";
		public string DescriptionsFileName = "";


		public bool ValidateTextFileReady(string QuestionFile, string DescriptionFile) // these are the full pathnames
		{
			if (QuestionFile == "" || DescriptionFile == "")
				return false;
			// check given file name and see if it exists
			// if exist, overwrite?
			if (!File.Exists(QuestionFile))
			{
				if (MessageBox.Show("This Questions file does not exist. Do you want to create it? [all questions need to be in "
					 + "a single file]", "Data Warning"
					 , MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.No)
				{
					return false;
				}
			}
			if (!File.Exists(DescriptionFile))
			{
				if (MessageBox.Show("This Descriptions file does not exist. Do you want to create it? [all descriptions need to be "
					 + "in a single file]", "Data Warning"
					 , MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.No)
				{
					return false;
				}
			}
			DescriptionsFileName = DescriptionFile;
			QuestionFileName = QuestionFile;
			return true;
		}

		public void SaveQuestionsToFile(int ElementNumber, List<string> QuestionsCommandList, List<string> DescriptionsCommandList)
		{
			List<string> QuestionStrings = new List<string>();
			List<string> DescriptionStrings = new List<string>();
			StreamReader oReader = null;
			StreamWriter oWriter = null;
			string sElementNumber = ElementNumber.ToString("0");
			string sInput = "";

			//---- read in all text from original file, dumping any from the current element number
			if (File.Exists(QuestionFileName))
			{
				oReader = new StreamReader(QuestionFileName);
				sInput = oReader.ReadLine();
				QuestionStrings.Add(sInput); // header line
				while (oReader.Peek() >= 0)
				{
					sInput = oReader.ReadLine();
					if (sInput.Substring(0, 1) == sElementNumber)
						continue;
					QuestionStrings.Add(sInput);
				}
				oReader.Close();
			}
			else
			{
				QuestionStrings.Add("ElementNumber|QuestionNumber|TestQuestion|AnswerA|AnswerB|AnswerC|AnswerD|"
					 + "CorrectAnswer|GrahpicName|QuestionReference");
			}
			if (File.Exists(DescriptionsFileName))
			{
				oReader = new StreamReader(DescriptionsFileName);
				sInput = oReader.ReadLine();
				DescriptionStrings.Add(sInput);  //  header
				while (oReader.Peek() >= 0)
				{
					sInput = oReader.ReadLine();
					if (sInput.Substring(0, 1) == sElementNumber)
						continue;
					DescriptionStrings.Add(sInput);
				}
				oReader.Close();
			}
			else
			{
				DescriptionStrings.Add("ElementNumber|SubElementName|GroupName|DescriptiveText");
			}

			//---- now write it all back without the old element data
			oWriter = new StreamWriter(QuestionFileName, false);
			foreach (string s in QuestionStrings)
			{
				oWriter.WriteLine(s);
			}
			oWriter.Flush();
			//---- now write the new data as appended text
			foreach (string s2 in QuestionsCommandList)
			{
				oWriter.WriteLine(s2);
			}
			oWriter.Flush();
			oWriter.Close();

			//------------------------------------
			oWriter = new StreamWriter(DescriptionsFileName, false);
			foreach (string s3 in DescriptionStrings)
			{
				oWriter.WriteLine(s3);
			}
			oWriter.Flush();
			foreach (string s4 in DescriptionsCommandList)
			{
				oWriter.WriteLine(s4);
			}
			oWriter.Flush();
			oWriter.Close();
			oWriter.Dispose();
		}

	}  // end class def

}  // end namespace
