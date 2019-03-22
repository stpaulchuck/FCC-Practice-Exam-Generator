using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace ExamGenerator
{
    class clsTextHandler
    {

        public string QuestionFileName = "";
        public string DescriptionsFileName = "";

        ToolStripStatusLabel sStatusDisplay = null;
        string[] saSplitter = { "|" };
        string[] splitArray = { };
        string sTextLine = "";

        public clsTextHandler(ToolStripStatusLabel StatusLabel)
        {
            sStatusDisplay = StatusLabel;
        }

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

        public DataTable GetQuestions()
        {
            DataTable retVal = new DataTable();

            try
            {
                StreamReader oReader = new StreamReader(QuestionFileName);
                if (oReader.Peek() >= 0)
                {
                    sTextLine = oReader.ReadLine();
                    splitArray = sTextLine.Split(saSplitter, StringSplitOptions.None);
                    if (!sTextLine.Contains("AnswerA"))
                    {
                        MessageBox.Show("Incorrect column names. Try another questions input file.", "Data Error");
                        return retVal;
                    }
                    foreach (string s in splitArray)
                    {
                        DataColumn dc = new DataColumn(s.Trim());
                        if (s.ToLower() == "elementnumber")
                            dc.DataType = typeof(int);
                        else
                            dc.DataType = typeof(string);
                        retVal.Columns.Add(dc);
                    }
                }
                else
                {
                    throw new Exception("No column names in file.");
                }
                while (oReader.Peek() > 0)
                {
                    sTextLine = oReader.ReadLine();
                    object[] objectArray = (object[])sTextLine.Split(saSplitter, StringSplitOptions.None);
                    if (objectArray.Length > retVal.Columns.Count)
                    {
                        Debug.WriteLine("data longer than column list: " + sTextLine);
                    }
                    DataRow oRow = retVal.NewRow();
                    oRow.ItemArray = objectArray;
                    retVal.Rows.Add(oRow);
                }
            }
            catch (Exception e5)
            {
                sStatusDisplay.Text = "Error reading questions.";
                MessageBox.Show("Error fetching questions: " + e5, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return retVal;
            }
            return retVal;
        }

        public DataTable GetDescriptions()
        {
            DataTable retVal = new DataTable();

            try
            {
                StreamReader oReader = new StreamReader(DescriptionsFileName);
                if (oReader.Peek() >= 0)
                {
                    sTextLine = oReader.ReadLine();
                    splitArray = sTextLine.Split(saSplitter, StringSplitOptions.None);
                    if (!sTextLine.Contains("SubElementName"))
                    {
                        MessageBox.Show("Incorrect column names. Try another descriptions input file.", "Data Error");
                        return retVal;
                    }
                    foreach (string s in splitArray)
                    {
                        DataColumn dc = new DataColumn(s.Trim());
                        if (s.ToLower() == "elementnumber")
                            dc.DataType = typeof(int);
                        else
                            dc.DataType = typeof(string);
                        retVal.Columns.Add(dc);
                    }
                }
                else
                {
                    throw new Exception("No column names in descriptions file.");
                }
                while (oReader.Peek() > 0)
                {
                    sTextLine = oReader.ReadLine();
                    object[] objectArray = (object[])sTextLine.Split(saSplitter, StringSplitOptions.None);
                    if (objectArray.Length > retVal.Columns.Count)
                    {
                        Debug.WriteLine("data longer than column list: " + sTextLine);
                    }
                    DataRow oRow = retVal.NewRow();
                    oRow.ItemArray = objectArray;
                    retVal.Rows.Add(oRow);
                }
            }
            catch (Exception e5)
            {
                sStatusDisplay.Text = "Error reading descriptions.";
                MessageBox.Show("Error fetching descriptions: " + e5, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return retVal;
            }
            return retVal;
        }

    }  // end class def

}  // end namespace
