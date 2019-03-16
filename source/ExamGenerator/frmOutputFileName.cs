using System;
using System.IO;
using System.Windows.Forms;

namespace ExamGenerator
{
	public partial class frmOutputFileName : Form
    {
        public frmOutputFileName()
        {
            InitializeComponent();
        }

        private void btnFindOutputFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog oDlg = new FolderBrowserDialog();
            oDlg.Description = "Choose Output Folder";
            oDlg.SelectedPath = txtOutputFolder.Text;
            if (!Directory.Exists(txtOutputFolder.Text))
            {
                oDlg.SelectedPath = Application.StartupPath;
            }
            if (oDlg.ShowDialog(this) == DialogResult.OK)
            {
                txtOutputFolder.Text = oDlg.SelectedPath;
                Properties.Settings.Default.LastOutputFolder = txtOutputFolder.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (txtOutputFileName.Text.Length < 1 || txtOutputFolder.Text.Length < 1)
            {
                MessageBox.Show(this, "You have an empty entry value. Please enter or browse the missing value. or click <Cancel>.", "Data Error");
            }
            else
            {
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    } // end class
} // end namespace
