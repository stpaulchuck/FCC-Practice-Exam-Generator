

namespace ExamGenerator
{

    /***************************************** selection chhoice event *****************************************************/

    public class clsChoiceEventArgs
    {
        public string QuestionNumber;
        public string ChoiceLetter;

        public clsChoiceEventArgs() { }

        public clsChoiceEventArgs(string Qnum, string Choice)
        {
            QuestionNumber = Qnum;
            ChoiceLetter = Choice;
        }
    }

    public delegate void ExamFormChoiceEvent(clsChoiceEventArgs args);

} // end namespace
