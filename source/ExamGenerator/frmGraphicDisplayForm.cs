using System.Drawing;
using System.Windows.Forms;

namespace ExamGenerator
{
	public partial class frmGraphicDisplayForm : Form
	{

		private Image m_GraphicToShow = null;
		public Image GraphicToShow {get{ return m_GraphicToShow; }set{ pictureBox1.Image = value; m_GraphicToShow = value; } }

		public frmGraphicDisplayForm()
		{
			InitializeComponent();
		}

	}  //  end class
}  //  end namespace
