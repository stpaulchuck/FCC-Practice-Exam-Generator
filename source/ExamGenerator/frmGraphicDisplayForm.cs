using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
