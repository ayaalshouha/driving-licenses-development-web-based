using DVLD_Buissness;
using System;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Tests
{
    public partial class FrmManageTestTypes : Form
    {
        public FrmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _UpdateList()
        {
            dgvTestTypes.DataSource = clsTestTypes.getAllTypes();
        }
        private void FrmManageTestTypes_Load(object sender, EventArgs e)
        {
            dgvTestTypes.DataSource = clsTestTypes.getAllTypes();
            lblRecordNumber.Text= dgvTestTypes.RowCount.ToString();

            if(dgvTestTypes.RowCount > 0)
            {
                dgvTestTypes.Columns[0].Width = 50;
                dgvTestTypes.Columns[3].Width = 300;
            }
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateTestType form = new FrmUpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _UpdateList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
