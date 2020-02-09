using System;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;


namespace FCC_Exam_Questions_text_cleaner
{
    public partial class frmQuestionsCleanerMain : Form
    {
        /*************************************************************************************************/
        /*  FCC Exam Question Text Cleaner, copyright © 2020 Charles H Fisher Jr., South St. Paul, MN    */
        /*************************************************************************************************/
        /*                   all rights reserved; you may use this code in your own                      */
        /*                   projects but a reference to my copyright is required                 c       */
        /*                   under the GNU General Public License Version 3 or later                     */
        /*************************************************************************************************/

        /*********************** constructor **********************/
        public frmQuestionsCleanerMain()
        {
            InitializeComponent();
        }

        /*********************** global vars **********************/
        const string sOutputFileName = "CleanedExamFile.txt";
        bool bIsStem = false, bIsQHeader = false;
        string sCurrentFileFullPath = "", sOutputDirectory = "";
        string[] QuestionFileAsStringArray = { };
        readonly Regex oRegxQheader = new Regex(@"^ ?[A-Z][0-9][0-9]?[A-Z][0-9].+\([ABCD]\)");
        readonly Regex oRegxQorphan = new Regex(@" [ABCD]\.");
        readonly Regex oRegxAnswer = new Regex(@"^ ?[ABCD]\.");

        /*********************** private methods **********************/
        void LoadFileIntoMemeory()
        {
            QuestionFileAsStringArray = File.ReadAllLines(sCurrentFileFullPath);
            if (txtOutputDirectory.Text == "")
            {
                txtOutputDirectory.Text = sCurrentFileFullPath.Substring(0, sCurrentFileFullPath.LastIndexOf(@"\"));
            }

            Properties.Settings.Default.lastOutputDirectory = txtOutputDirectory.Text;
            Properties.Settings.Default.lastOutputDirectory = txtOutputDirectory.Text;
            Properties.Settings.Default.lastInputFile = sCurrentFileFullPath;
            Properties.Settings.Default.Save();
        }

        bool ScanAndRepairFile()
        {
            string sQheader = "", sTemp = "";
            int iQuestionsCleaned = 0;
            int iIndexer = 0, iStop = QuestionFileAsStringArray.Length;
            for (iIndexer = 0; iIndexer < iStop; iIndexer++)
            {
                //---- update the rolling count label
                if (iIndexer % 13 == 0)
                {
                    lblLinesRead.Text = iIndexer.ToString();
                    Application.DoEvents();
                }
                sTemp = QuestionFileAsStringArray[iIndexer];
                //---- skip the "don't care" lines up front
                if (sTemp == "XXXXX" || sTemp == " ") continue; // it'll be a skip line
                //---- first look for question header line
                if (!bIsQHeader) // bypass if we've found it
                {
                    if (sTemp.Trim().ToUpper().StartsWith("SUBELEMENT"))
                    {
                        if (!sTemp.ToUpper().Contains("QUESTION") || !sTemp.ToUpper().Contains("GROUP"))
                        {
                            try
                            {
                                sTemp = QuestionFileAsStringArray[iIndexer + 1];
                                if (sTemp.ToUpper().Contains("QUESTION") || sTemp.ToUpper().Contains("GROUP"))
                                {
                                    sTemp = QuestionFileAsStringArray[iIndexer] + sTemp;
                                    QuestionFileAsStringArray[iIndexer] = sTemp;
                                    QuestionFileAsStringArray[iIndexer + 1] = "XXXXX";
                                    iQuestionsCleaned++;
                                    lblLinesCleaned.Text = iQuestionsCleaned.ToString();
                                    Application.DoEvents();
                                }
                            }
                            catch
                            {
                                MessageBox.Show(this, "Subelement error: " + QuestionFileAsStringArray[iIndexer], "Error!");
                                return false;
                            }
                        }
                        continue;
                    }
                    if ((oRegxQheader.Match(QuestionFileAsStringArray[iIndexer])).Success)
                    {
                        sQheader = QuestionFileAsStringArray[iIndexer];
                        bIsQHeader = true;
                        bIsStem = false;
                    }
                    continue; // keep looking and ignore other text line types
                }
                //---- if we have a Qheader but not 'stem' yet, check
                if (bIsStem == false)
                {
                    if (QuestionFileAsStringArray[iIndexer].Contains("?")) // question stem
                    {
                        bIsStem = true;
                        // line behind? hard CR?
                        if (!(oRegxQheader.Match(QuestionFileAsStringArray[iIndexer - 1])).Success) // orphan line
                        {
                            Debug.WriteLine(sQheader + ": " + QuestionFileAsStringArray[iIndexer]);
                            QuestionFileAsStringArray[iIndexer] = QuestionFileAsStringArray[iIndexer - 1] + QuestionFileAsStringArray[iIndexer];
                            QuestionFileAsStringArray[iIndexer - 1] = "XXXXX";
                            if (!(oRegxQheader.Match(QuestionFileAsStringArray[iIndexer - 2])).Success) // another orphan
                            {
                                QuestionFileAsStringArray[iIndexer] = QuestionFileAsStringArray[iIndexer - 2] + QuestionFileAsStringArray[iIndexer];
                                QuestionFileAsStringArray[iIndexer - 2] = "XXXXX";
                            }
                            iQuestionsCleaned++;
                            lblLinesCleaned.Text = iQuestionsCleaned.ToString();
                            Application.DoEvents();
                        }
                        // part of next line at the end? usually answer A tag "A."
                        sTemp = QuestionFileAsStringArray[iIndexer].Substring(QuestionFileAsStringArray[iIndexer].LastIndexOf("?")).Trim();
                        if (sTemp.Length > 2) // " A." etc.
                        {
                            if ((oRegxQorphan.Match(sTemp)).Success)
                            {
                                if (sTemp.Length > 4) // likely an entire answer
                                {
                                    Debug.WriteLine(QuestionFileAsStringArray[iIndexer]);
                                    sTemp = QuestionFileAsStringArray[iIndexer];
                                    for (int ix = sTemp.LastIndexOf("?"); ix < sTemp.Length; ix++)
                                    {
                                        if (sTemp[ix] == 'A')
                                        {
                                            if (sTemp[ix + 1] == '.')
                                            {
                                                sTemp = sTemp.Insert(ix, "\r\n");
                                                QuestionFileAsStringArray[iIndexer] = sTemp;
                                            }
                                        }
                                    }
                                }
                                else // it's an orphan answer letter tag like "A."
                                {
                                    Debug.WriteLine(QuestionFileAsStringArray[iIndexer]);
                                    sTemp = sTemp.Trim() + " ";
                                    QuestionFileAsStringArray[iIndexer + 1] = sTemp + QuestionFileAsStringArray[iIndexer + 1];
                                    QuestionFileAsStringArray[iIndexer] = QuestionFileAsStringArray[iIndexer].Substring(0, QuestionFileAsStringArray[iIndexer].LastIndexOf("?") + 1);
                                }

                            }
                            iQuestionsCleaned++;
                            lblLinesCleaned.Text = iQuestionsCleaned.ToString();
                            Application.DoEvents();
                        } // end - tail after ? > 2
                        continue; // question stem is found
                    } // end if question stem
                    else
                    {
                        continue; // skip over orphan lines in front of the line with the "?"
                    }
                } // if !bStem
                // if is answer, is all of it on one line? leftovers on following lines
                if (bIsStem) // what's left should be to be an answer
                {
                    if ((oRegxAnswer.Match(QuestionFileAsStringArray[iIndexer])).Success)
                    {
                        bool bFixedIt = false;
                        // check following string(s)
                        if (QuestionFileAsStringArray[iIndexer + 1].Trim() != "")
                        {
                            if (!(oRegxAnswer.Match(QuestionFileAsStringArray[iIndexer + 1])).Success)
                            {
                                QuestionFileAsStringArray[iIndexer] = QuestionFileAsStringArray[iIndexer] + QuestionFileAsStringArray[iIndexer + 1];
                                QuestionFileAsStringArray[iIndexer + 1] = "XXXXX";
                                bFixedIt = true;
                                /*  ---> */   // if (QuestionFileAsStringArray[iIndexer + 2].Trim() == "") continue;
                                if (!(oRegxAnswer.Match(QuestionFileAsStringArray[iIndexer + 2])).Success)
                                {
                                    QuestionFileAsStringArray[iIndexer] = QuestionFileAsStringArray[iIndexer] + QuestionFileAsStringArray[iIndexer + 2];
                                    QuestionFileAsStringArray[iIndexer + 2] = "XXXXX";
                                    bFixedIt = true;
                                }
                            }
                        }

                        if (bFixedIt)
                        {
                            Debug.WriteLine(sQheader + ": " + QuestionFileAsStringArray[iIndexer]);
                            iQuestionsCleaned++;
                            lblLinesCleaned.Text = iQuestionsCleaned.ToString();
                            Application.DoEvents();
                        }
                        //---- is answer is "D." then set everything to false
                        if (QuestionFileAsStringArray[iIndexer].Trim().StartsWith("D.")) // trim() in case there's a leading space char
                        {
                            bIsStem = false;
                            bIsQHeader = false;
                            sQheader = "";
                            continue;
                        }

                    } // if it's a question

                } // if bIsStem is true 

            }  // end for iIndexer...

            return true; // if all is well
        }

        bool SaveTheFile()
        {
            if (!Directory.Exists(txtOutputDirectory.Text))
            {
                MessageBox.Show(this, "Error: the output file directory path threw an exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            StreamWriter oWriter = new StreamWriter(txtOutputDirectory.Text + "\\" + sOutputFileName);
            foreach (string s in QuestionFileAsStringArray)
            {
                if (s == "XXXXX") continue;
                if (s == "") oWriter.WriteLine(" ");
                else oWriter.WriteLine(s);
            }
            oWriter.Flush();
            oWriter.Close();

            return true; // if all is well
        }

        /*********************** event handlers **********************/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReloadFile_Click(object sender, EventArgs e)
        {
            LoadFileIntoMemeory();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (QuestionFileAsStringArray.Length == 0)
            {
                SoundPlayer sp = new SoundPlayer(Properties.Resources._all_wrong);
                sp.Play();
                MessageBox.Show(this, "Hey stupid! There's no question file loaded!!", "Oooops!!");
                return;
            }
            if (ScanAndRepairFile()) SaveTheFile();

        } // end btn run_click()

        private void frmQuestionsCleanerMain_Shown(object sender, EventArgs e)
        {
            string sTemp = Properties.Settings.Default.lastInputFile;
            if (File.Exists(sTemp))
            {
                txtFileName.Text = sTemp;
                sCurrentFileFullPath = sTemp;
                LoadFileIntoMemeory();
            }
            else
            {
                Properties.Settings.Default.lastInputFile = "";
            }

            sTemp = Properties.Settings.Default.lastOutputDirectory;
            if (Directory.Exists(sTemp))
            {
                txtOutputDirectory.Text = sTemp;
            }
        }

        private void btnSetOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog oDlgDir = new FolderBrowserDialog();
            oDlgDir.SelectedPath = Application.StartupPath;
            if (oDlgDir.ShowDialog(this) == DialogResult.OK)
            {
                sOutputDirectory = oDlgDir.SelectedPath;
                txtOutputDirectory.Text = sOutputDirectory;
                Properties.Settings.Default.lastOutputDirectory = sOutputDirectory;
            }
        }

        void btnFindInputFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog oDlg = new OpenFileDialog();
            oDlg.Multiselect = false;
            if (txtFileName.Text != "")
            {
                string sTemp = txtFileName.Text.Substring(0, txtFileName.Text.LastIndexOf("\\"));
                if (Directory.Exists(sTemp))
                {
                    oDlg.InitialDirectory = sTemp;
                }
            }
            else
                oDlg.InitialDirectory = Application.StartupPath;

            if (oDlg.ShowDialog(this) == DialogResult.OK)
            {
                sCurrentFileFullPath = oDlg.FileName;
                txtFileName.Text = sCurrentFileFullPath;
                LoadFileIntoMemeory();
            }
        }

    }  // end class
}  // end namespace
