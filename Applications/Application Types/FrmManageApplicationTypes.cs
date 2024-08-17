using DVLD___Driving_Licenses_Managment.Applications.Types;
using DVLD_Buissness;
using System;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Applications
{
    public partial class FrmManageApplicationTypes : Form
    {
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _UpdateList()
        {
            dgvApplicationTypes.DataSource = clsApplicationTypes.getAllTypes();
        }

        private void FrmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvApplicationTypes.DataSource = clsApplicationTypes.getAllTypes();
            lblRecordNumber.Text = dgvApplicationTypes.RowCount.ToString();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //edit application types form 
            FrmEditApplicationType form = new FrmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _UpdateList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
