using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExamGenerator
{
	public partial class ucTestQuestionHolder : UserControl
	{
		/********************** public vars ************************/
		public event ExamFormChoiceEvent ChoiceEvent;
		public bool IsPracticeExam;

		/********************** private vars*********************/
		private bool bIsLocked = false;
		private bool bIsLoading = false;
		private string QuestionNumber = "";
		private string CorrectAnswerChoice = "";

		/********************** public methods *********************/
		public ucTestQuestionHolder()
		{
			InitializeComponent();
		}

		public void SetQuestion(clsQuestionInfo QuestionInfo)
		{
			bIsLocked = false;
			ClearChoices();
			bIsLoading = false;

			//---- set values
			CorrectAnswerChoice = QuestionInfo.CorrectAnswerLetter[0];
			txtTestQuestion.Text = QuestionInfo.QuestionText;
			txtAnswerA.Text = QuestionInfo.AnswerA;
			txtAnswerB.Text = QuestionInfo.AnswerB;
			txtAnswerC.Text = QuestionInfo.AnswerC;
			txtAnswerD.Text = QuestionInfo.AnswerD;
			QuestionNumber = QuestionInfo.QuestionNumber;
			if (IsPracticeExam)
			{
				try
				{
					((Label)(this.Controls.Find("lblAnswer" + CorrectAnswerChoice, true)[0])).BackColor = Color.LightGreen;
				}
				catch
				{
					var x = 5;
				}
			}
			
			string sPreviousChoice = QuestionInfo.CorrectAnswerLetter[1];
			if (sPreviousChoice == "")
				return; // no previous choice made
			bIsLoading = true;
			switch (sPreviousChoice)
			{
				case "A":
					lblAnswerA_Click(null, EventArgs.Empty);
					break;
				case "B":
					lblAnswerB_Click(null, EventArgs.Empty);
					break;
				case "C":
					lblAnswerC_Click(null, EventArgs.Empty);
					break;
				case "D":
					lblAnswerD_Click(null, EventArgs.Empty);
					break;
			}
		}

		public void LetterPressed(char Letter)
		{
			switch (Letter)
			{
				case 'A':
					lblAnswerA_Click(null, EventArgs.Empty);
					break;
				case 'B':
					lblAnswerB_Click(null, EventArgs.Empty);
					break;
				case 'C':
					lblAnswerC_Click(null, EventArgs.Empty);
					break;
				case 'D':
					lblAnswerD_Click(null, EventArgs.Empty);
					break;
			}
		}

		/************************ internal housekeeping ******************************/
		private void lblAnswerA_Click(object sender, EventArgs e)
		{
			if (bIsLocked) return;
			lblAnswerA.Text = "X";
			MarkCorrectAnswer("A");
			SendEvent("A");
		}

		private void lblAnswerB_Click(object sender, EventArgs e)
		{
			if (bIsLocked) return;
			lblAnswerB.Text = "X";
			MarkCorrectAnswer("B");
			SendEvent("B");
		}

		private void lblAnswerC_Click(object sender, EventArgs e)
		{
			if (bIsLocked) return;
			SendEvent("C");
			MarkCorrectAnswer("C");
			lblAnswerC.Text = "X";
		}

		private void lblAnswerD_Click(object sender, EventArgs e)
		{
			if (bIsLocked) return;
			lblAnswerD.Text = "X";
			MarkCorrectAnswer("D");
			SendEvent("D");
		}

		private void SendEvent(string Choice)
		{
			if (bIsLoading) return; // loading previously made choice
			ChoiceEvent?.Invoke(new clsChoiceEventArgs(QuestionNumber, Choice));
		}

		private void MarkCorrectAnswer(string MyAnswer)
		{
			Color cBackColor = Color.LightGreen;
			if (MyAnswer != CorrectAnswerChoice)
			{
				cBackColor = Color.LightSalmon;
				this.Controls["panel1"].Controls["lblAnswer" + CorrectAnswerChoice].BackColor = Color.LightGreen;
				this.Controls["panel1"].Controls["lblAnswer" + CorrectAnswerChoice].Text = "*";
			}
			this.Controls["panel1"].Controls["lblAnswer" + MyAnswer].BackColor = cBackColor;
			// and then lock the choices
			bIsLocked = true;
		}

		private void ClearChoices()
		{
			//---- clear choices
			lblAnswerA.Text = "";
			lblAnswerB.Text = "";
			lblAnswerC.Text = "";
			lblAnswerD.Text = "";
			lblAnswerA.BackColor = Color.White;
			lblAnswerA.ForeColor = Color.Black;
			lblAnswerB.BackColor = Color.White;
			lblAnswerB.ForeColor = Color.Black;
			lblAnswerC.BackColor = Color.White;
			lblAnswerC.ForeColor = Color.Black;
			lblAnswerD.BackColor = Color.White;
			lblAnswerD.ForeColor = Color.Black;
		}

	}  // end control class

}  // end namespace
