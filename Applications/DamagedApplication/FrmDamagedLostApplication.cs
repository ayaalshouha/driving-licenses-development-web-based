using DVLD___Driving_Licenses_Managment.License;
using DVLD_Buissness;
using System;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Applications.DamagedApplication
{
    public partial class FrmDamagedLostApplication : Form
    {
        private clsLicenses PreviousLicense;
        private int PreviousLicenseID;
        private clsLicenses NewLicense;
        private int NewLicenseID;

        public FrmDamagedLostApplication()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        //{
        //    PreviousLicenseID = obj;
        //    PreviousLicense = cntrlLicenseInfoWithFilter1.SelectedLicenseInfo;
        //    lnkShowPersonHistory.Enabled = true;
        //    lblOldLicenseID.Text = PreviousLicenseID.ToString();
        //    lblCreatedByUser.Text = clsUser.Username(PreviousLicense.CreatedByUserID);

        //    if (!PreviousLicense.isActive) {
        //        MessageBox.Show("Selected license is NOT active!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return; 
        //    }

        //    btnIssueLicense.Enabled = true;
        //}

        private void lnkShowPersonHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory(PreviousLicense.DriverInfo.PersonID);
            form.ShowDialog();
        }

        private void lnkShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo form = new FrmShowLicenseInfo(NewLicenseID);
            form.ShowDialog();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            clsLicenses.enIssueReason reason =
                rbDamaged.Checked ? clsLicenses.enIssueReason.DamagedReplacement : clsLicenses.enIssueReason.LostReplacement;

            if (MessageBox.Show("are you sure you want to replace this license?", "Message Box",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NewLicense = PreviousLicense.Replace(reason, clsGlobal.CurrentUser.ID);

                if (NewLicense != null)
                {
                    MessageBox.Show($"License Renewd Successfully, New License ID = {NewLicense.ID}.", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewLicenseID = NewLicense.ID;
                    lblReplacementApplicationID.Text = NewLicense.ApplicationID.ToString();
                    lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                    lblReplacedLicenseID.Text = NewLicense.ID.ToString();
                    lblCreatedByUser.Text = clsUser.Username(NewLicense.CreatedByUserID);
                    lnkShowNewLicenseInfo.Enabled = true;
                    btnIssueLicense.Enabled = false;
                }
                else
                    MessageBox.Show("Error happened while saving a new license! check again later!", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }

        private void rdLost_CheckedChanged(object sender, EventArgs e)
        {
            lblHeader.Text = "Replacement for Lost License";
            decimal AppFees = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.LostReplacement);
            lblFees.Text = AppFees.ToString();
        }

        private void FrmDamagedLostApplication_Load(object sender, EventArgs e)
        {
            rbDamaged.Checked = true;
            lblHeader.Text = "Replacement for Damaged License";
            decimal AppFees = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.DamagedReplacement);
            lblFees.Text = AppFees.ToString();

        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblHeader.Text = "Replacement for Damaged License";
            decimal AppFees = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.DamagedReplacement);
            lblFees.Text = AppFees.ToString();

        }

        private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(object sender, Controls.cntrlLicenseInfoWithFilter.LicensesSelectedEventArgs e)
        {
            PreviousLicenseID = e.SelectedLicense.ID;
            PreviousLicense = e.SelectedLicense;
            lnkShowPersonHistory.Enabled = true;
            lblOldLicenseID.Text = PreviousLicenseID.ToString();
            lblCreatedByUser.Text = clsUser.Username(PreviousLicense.CreatedByUserID);

            if (!PreviousLicense.isActive)
            {
                MessageBox.Show("Selected license is NOT active!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIssueLicense.Enabled = true;
        }
    }
}
