using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ExamGenerator
{
	public partial class frmElectronicExam : Form
	{

		/**************************** properties ***********************************/
		private List<DataRow> m_QuestionPool;
		public List<DataRow> QuestionPool
		{
			set
			{
				m_QuestionPool = value;
				iTotalQuestions = m_QuestionPool.Count;
			}
		}

		private bool m_bIsPractice = false;
		public bool IsPracticeExam
		{
			set { m_bIsPractice = value; }
			get { return m_bIsPractice; }
		}


		/**************************** global vars ***********************************/
		Dictionary<string, string[]> CorrectAnswersDic = new Dictionary<string, string[]>(); // (qnum, [correct ans., student ans.])
		int iTotalQuestions = 0, iCorrectAnswers = 0, iWrongAnswers = 0;
		List<DataRow> QuestionListRandomized = new List<DataRow>(); // random shuffle of QuestionPool
		string sCurrentTQnumber = "";
		int iTQptr = 0;
		frmGraphicDisplayForm GraphicDisplayForm = null;

		/**************************** public methods ***********************************/

		public frmElectronicExam()
		{
			InitializeComponent();
			TQholder.ChoiceEvent += TQholder_ChoiceEvent;
		}

		/**************************** private methods ***********************************/

		private void TQholder_ChoiceEvent(clsChoiceEventArgs args)
		{
			// record the choice, verify correct, adjust header numbers
			string sQnum = args.QuestionNumber;
			string sQans = args.ChoiceLetter;
			string[] sCorrectAns = CorrectAnswersDic[sQnum];
			if (sCorrectAns[1] != "")
				return; // already scored
			sCorrectAns[1] = sQans;
			CorrectAnswersDic[sQnum] = sCorrectAns;
			if (sCorrectAns[0] == sCorrectAns[1])
			{
				int iTemp = int.Parse(lblCorrectQ.Text);
				iTemp++;
				lblCorrectQ.Text = iTemp.ToString("0");
				iCorrectAnswers = iTemp;
			}
			else
			{
				int iTemp = int.Parse(lblIncorrectQ.Text);
				iTemp++;
				lblIncorrectQ.Text = iTemp.ToString("0");
				iWrongAnswers = iTemp;
			}
		}

		private void frmElectronicExam_Shown(object sender, EventArgs e)
		{
			lblTotalQ.Text = m_QuestionPool.Count.ToString();
			if (m_QuestionPool.Count < 1)
				throw new Exception("you didn't load any questions!!");
			RandomizeQuestionList();
			TQholder.IsPracticeExam = m_bIsPractice;
			LoadQuestion(iTQptr);
		}

		private void frmElectronicExam_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void frmElectronicExam_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == false)
			{
				UnFreezeBoxes();
			}
		}

		private void FreezeBoxes()
		{
			// disable all the text boxes
			TQholder.txtAnswerA.ReadOnly = true;
			TQholder.txtAnswerA.BackColor = Color.White;
			TQholder.txtAnswerB.ReadOnly = true;
			TQholder.txtAnswerB.BackColor = Color.White;
			TQholder.txtAnswerC.ReadOnly = true;
			TQholder.txtAnswerC.BackColor = Color.White;
			TQholder.txtAnswerD.ReadOnly = true;
			TQholder.txtAnswerD.BackColor = Color.White;
			TQholder.txtTestQuestion.ReadOnly = true;
			TQholder.txtTestQuestion.BackColor = Color.White;
		}

		private void UnFreezeBoxes()
		{
			// enable all the text boxes
			TQholder.txtAnswerA.ReadOnly = false;
			TQholder.txtAnswerB.ReadOnly = false;
			TQholder.txtAnswerC.ReadOnly = false;
			TQholder.txtAnswerD.ReadOnly = false;
			TQholder.txtTestQuestion.ReadOnly = false;
		}

		private void RandomizeQuestionList()
		{
			int iStop = m_QuestionPool.Count - 1;
			QuestionListRandomized = m_QuestionPool;

			Random oRnd = new Random();
			int i = 0, j = 0;
			DataRow drTemp;
			for (int iIndexer = 0; iIndexer < iStop; iIndexer++)
			{
				i = oRnd.Next(0, iStop);
				j = oRnd.Next(0, iStop);
				drTemp = QuestionListRandomized[i];
				QuestionListRandomized[i] = QuestionListRandomized[j];
				QuestionListRandomized[j] = drTemp;
			}
		}

		private void LoadQuestion(int Qnumber)
		{
			if (GraphicDisplayForm != null)
				GraphicDisplayForm.Close();
			//---- send question info class with data
			clsQuestionInfo oTQ = new clsQuestionInfo();
			DataRow oRow = QuestionListRandomized[Qnumber];
			oTQ.AnswerA = oRow.Field<string>("AnswerA");
			oTQ.AnswerB = oRow.Field<string>("AnswerB");
			oTQ.AnswerC = oRow.Field<string>("AnswerC");
			oTQ.AnswerD = oRow.Field<string>("AnswerD");
			oTQ.QuestionNumber = oRow.Field<string>("QuestionNumber");
			oTQ.QuestionText = oRow.Field<string>("TestQuestion") + " - " + oTQ.QuestionNumber;
			sCurrentTQnumber = oTQ.QuestionNumber;
			if (!CorrectAnswersDic.ContainsKey(sCurrentTQnumber))
			{
				string[] oTemp = new string[] { oRow.Field<string>("CorrectAnswer"), "" };
				CorrectAnswersDic.Add(sCurrentTQnumber, oTemp);
				oTQ.CorrectAnswerLetter = oTemp;
			}
			else
			{
				oTQ.CorrectAnswerLetter = CorrectAnswersDic[sCurrentTQnumber];
			}
			TQholder.SetQuestion(oTQ);
			FreezeBoxes();
			if (oRow.Field<string>(8) != "")  //  graphic name
			{
				string sFileName = oRow.Field<string>(8);
				if (sFileName.Contains("."))
				{
					sFileName = sFileName.Substring(0, sFileName.IndexOf("."));
				}
				sFileName = sFileName.Replace(" ", "_");
				//sFileName = sFileName.Replace("-", "_");
				if (oTQ.QuestionNumber[0] == 'E') sFileName = "Extra_Pool_graphic" + sFileName.Substring(sFileName.LastIndexOf("_"));
				if (oTQ.QuestionNumber[0] == 'G') sFileName = "General_Pool_graphic" + sFileName.Substring(sFileName.LastIndexOf("_"));
				if (oTQ.QuestionNumber[0] == 'T') sFileName = "Tech_Pool_graphic" + sFileName.Substring(sFileName.LastIndexOf("_"));
				GraphicDisplayForm = new frmGraphicDisplayForm();
				//GraphicDisplayForm.GraphicToShow = (Image)Properties.Resources.ResourceManager.GetObject(sFileName);
				GraphicDisplayForm.GraphicToShow = Image.FromFile(Application.StartupPath + "\\QuestionGraphics\\" + sFileName + ".jpg");
				GraphicDisplayForm.Show();
			}
		}

		private void btnNextQ_Click(object sender, EventArgs e)
		{
			iTQptr++;
			if (iTQptr >= m_QuestionPool.Count)
				iTQptr = 0;
			LoadQuestion(iTQptr);
			lblCurrentQnum.Text = (iTQptr + 1).ToString("0");
		}

		private void btnPreviousQ_Click(object sender, EventArgs e)
		{
			iTQptr--;
			if (iTQptr < 0)
				iTQptr = m_QuestionPool.Count - 1;
			LoadQuestion(iTQptr);
			lblCurrentQnum.Text = (iTQptr + 1).ToString("0");
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			int iAnswered = iCorrectAnswers + iWrongAnswers;
			if (iAnswered < iTotalQuestions)
			{
				if (MessageBox.Show(this, "You only answered " + iAnswered.ToString("0") + " questions "
					 + "out of " + iTotalQuestions.ToString("0") + " total questions. Do you really want "
					 + "to exit the test?", "Incomplete Exam", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
					 == System.Windows.Forms.DialogResult.No)
				{
					return;
				}
			}
			if ((iCorrectAnswers + iWrongAnswers) != 0)
			{
				frmTestResults oResults = new frmTestResults(iCorrectAnswers, iWrongAnswers, iTotalQuestions);
				oResults.Show();
			}
			this.Close();
		}

		private void frmElectronicExam_KeyDown(object sender, KeyEventArgs e)
		{
			if (Control.ModifierKeys == Keys.Alt || Control.ModifierKeys == Keys.Control)
			{
				e.Handled = false;
				return;
			}
			if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Left)
			{
				e.Handled = true;
				btnPreviousQ_Click(null, EventArgs.Empty);
				return;
			}
			if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Right || e.KeyCode == Keys.Return)
			{
				e.Handled = true;
				btnNextQ_Click(null, EventArgs.Empty);
				return;
			}
			if (e.KeyCode != Keys.A && e.KeyCode != Keys.B && e.KeyCode != Keys.C && e.KeyCode != Keys.D)
			{
				e.Handled = false;
				return;
			}
			e.Handled = true;
			KeysConverter kvc = new KeysConverter();
			char c = ' ';
			c = kvc.ConvertToString(e.KeyCode).ToUpper()[0];
			TQholder.LetterPressed(c);
		}

	}  // end class
}  // end namespace
