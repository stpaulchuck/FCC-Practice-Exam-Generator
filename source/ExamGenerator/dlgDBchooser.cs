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
    public partial class dlgDBchooser : Form
    {

        private DataTable m_Table = null;

        public dlgDBchooser(DataTable oTable)
        {
            InitializeComponent();
            m_Table = oTable;
        }

        private void dlgDBchooser_Shown(object sender, EventArgs e)
        {
            cmbDBnames.Items.Clear();
            foreach (DataRow oRow in m_Table.Rows)
            {
                if (!oRow.Field<string>(0).ToUpper().Contains("SCHEMA"))
                {
                    cmbDBnames.Items.Add(oRow.Field<string>(0));
                }
            }
            cmbDBnames.Text = cmbDBnames.Items[0].ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }  // end class
} // end namespace
