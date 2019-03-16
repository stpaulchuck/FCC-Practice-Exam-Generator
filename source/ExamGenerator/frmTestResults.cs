using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExamGenerator
{
    public partial class frmTestResults : Form
    {

        private int CorrectNumber = 0;
        private int IncorrectNumber = 0;
        private int TotalNumber = 0;

        private double fPassCutoff = 74.0;

        private string FailText = "Sorry, you failed!";
        private string PassText = "Congratulations, you passed.";
        private string IncompleteText = "INCOMPLETE EXAM";
        private Color PassColor = Color.LightGreen;
        private Color FailColor = Color.Salmon;
        private Color IncompleteColor = Color.Yellow;


        public frmTestResults(int CorrectNum, int IncorrectNum, int TotalNum)
        {
            InitializeComponent();
            CorrectNumber = CorrectNum;
            IncorrectNumber = IncorrectNum;
            TotalNumber = TotalNum;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTestResults_Shown(object sender, EventArgs e)
        {
            ShowResults(CorrectNumber, IncorrectNumber, TotalNumber);
        }

        private void ShowResults(int CorrectQs, int IncorrectQs, int TotalQs)
        {
            double fPercent = 0.0;
            if (CorrectQs > 0)
            {
                fPercent = 100.0 * (double)CorrectQs / (double)(CorrectQs + IncorrectQs);
            }
            else
            {
                IncompleteText = "NO QUESTIONS ANSWERED!!";
            }
            bool PassOrFail = false;
            if (fPercent > fPassCutoff)
                PassOrFail = true;

            if ((CorrectQs + IncorrectQs) != TotalQs)
            {
                lblCongratulations.Text = IncompleteText;
                lblCongratulations.BackColor = IncompleteColor;
            }
            else
            {
                if (PassOrFail)
                {
                    lblCongratulations.Text = PassText;
                    lblCongratulations.BackColor = PassColor;
                }
                else
                {
                    lblCongratulations.Text = FailText;
                    lblCongratulations.BackColor = FailColor;
                }
            }
            lblCorrectQ.Text = CorrectQs.ToString("0");
            lblIncorrectQ.Text = IncorrectQs.ToString("0");
            lblTotalQ.Text = TotalNumber.ToString("0");
            lblPercentage.Text = fPercent.ToString("0.0");
        }

    }  // end form class
}  // end namespace
