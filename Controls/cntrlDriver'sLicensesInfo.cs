using DVLD___Driving_Licenses_Managment.License;
using DVLD_Buissness;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Controls
{
    public partial class cntrlDriver_sLicensesInfo : UserControl
    {

        private int _DriverID; 
        private DataTable _LocalLicensesHistory; 
        private DataTable _InternationalLicensesHistory;
        public cntrlDriver_sLicensesInfo()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _LocalLicensesHistory.Clear();
            _InternationalLicensesHistory.Clear();
        }
        private void _LoadLocalinfo()
        {
            _LocalLicensesHistory = clsDrviers.getLocalLicenses(_DriverID);
            dgvLocalHistory.DataSource = _LocalLicensesHistory;
            lblLocalRecords.Text = dgvLocalHistory.RowCount.ToString();

            if (dgvLocalHistory.RowCount > 0)
            {
                dgvLocalHistory.Columns[0].HeaderText = "License ID";
                dgvLocalHistory.Columns[1].HeaderText = "Application ID";
                dgvLocalHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalHistory.Columns[5].HeaderText = "Is Active";
            }
        }

        private void _LoadInternationalinfo()
        {
            _InternationalLicensesHistory = clsDrviers.getInternationalLicenses(_DriverID);
            dgvInternationalHistory.DataSource = _InternationalLicensesHistory;
            lblInternationalRecords.Text = dgvInternationalHistory.RowCount.ToString();

            if (dgvInternationalHistory.RowCount > 0)
            {
                dgvInternationalHistory.Columns[0].HeaderText = "Int.Lic ID";
                dgvInternationalHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalHistory.Columns[2].HeaderText = "L.LicenseID";
                dgvInternationalHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalHistory.Columns[5].HeaderText = "Is Active";
            }
        }

        public void LoadInfo(int DriverID)
        {
             _DriverID = DriverID;
            clsDrviers Driver = clsDrviers.Find(_DriverID); 

            if(Driver == null)
            {
                MessageBox.Show($"No Driver Found with ID = {_DriverID} !!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadInternationalinfo();
            _LoadLocalinfo();
        }

        public void LoadInfo_ByPersonID(int PersonID)
        {
            clsDrviers Driver = clsDrviers.Find_ByPersonID(PersonID);

            if (Driver != null)
            {
                _DriverID = Driver.ID;
                _LoadInternationalinfo();
                _LoadLocalinfo(); 
            }
            else
                MessageBox.Show($"There is No Driver associated with PersonID {PersonID} !!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show local license form
            int licenseID = (int)dgvLocalHistory.CurrentRow.Cells[0].Value;
            FrmShowLicenseInfo form = new FrmShowLicenseInfo(licenseID); 
            form.ShowDialog();

        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //show international license info form 
            int licenseID = (int)dgvInternationalHistory.CurrentRow.Cells[0].Value;
            FrmShowInternationalLicenseInfo form = new FrmShowInternationalLicenseInfo(licenseID);
            form.ShowDialog();
        }
    }
}
