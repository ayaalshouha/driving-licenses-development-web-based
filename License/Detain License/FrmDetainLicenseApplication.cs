using DVLD___Driving_Licenses_Managment.License;
using DVLD_Buissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Applications.Detain_License
{
    public partial class FrmDetainLicenseApplication : Form
    {
        private clsLicenses License;
        private int LicenseID;
        private int DetainID;

        public FrmDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        //{
        //    LicenseID = obj;
        //    License = cntrlLicenseInfoWithFilter1.SelectedLicenseInfo;

        //    if( License.isDetained) {
        //        MessageBox.Show("Selected license is already detained, Choose another one", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (!License.isActive){
        //        MessageBox.Show("Selected license is NOT active!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }


        //    lblDetainDate.Text = DateTime.Now.ToShortDateString();
        //    lblLicenseID.Text = LicenseID.ToString();
        //    lblCreatedByUser.Text = clsGlobal.CurrentUser.username;
        //    btnIDetainLicense.Enabled = true;
        //    lnkShowPersonHistory.Enabled = true; 
        //    lnkShowLicenseInfo.Enabled = true;
        //    return;
        //}

        private void btnIDetainLicense_Click(object sender, EventArgs e)
        {
            decimal finefee = -1;


            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                MessageBox.Show("Please enter fine fees first!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return; 
            }


            finefee = decimal.Parse(txtFineFees.Text);

            DetainID = License.Detain(finefee, clsGlobal.CurrentUser.ID); 


            if (DetainID != -1)
            {
                MessageBox.Show("License Detained Successfully!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblDetainID.Text = DetainID.ToString();
                txtFineFees.Enabled = false;
                btnIDetainLicense.Enabled = false; 
            }


        }

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo form = new FrmShowLicenseInfo(LicenseID);
            form.ShowDialog();
        }

        private void lnkShowPersonHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory(License.DriverInfo.PersonID);
            form.ShowDialog();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (!clsGlobal.isNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number!");
            }
            else
                errorProvider1.SetError(txtFineFees, null);
        }

        private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(object sender, Controls.cntrlLicenseInfoWithFilter.LicensesSelectedEventArgs e)
        {
            LicenseID = e.SelectedLicense.ID;
            License = e.SelectedLicense;

            if (License.isDetained)
            {
                MessageBox.Show("Selected license is already detained, Choose another one", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!License.isActive)
            {
                MessageBox.Show("Selected license is NOT active!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblLicenseID.Text = LicenseID.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.username;
            btnIDetainLicense.Enabled = true;
            lnkShowPersonHistory.Enabled = true;
            lnkShowLicenseInfo.Enabled = true;
            return;
        }
    }
}
