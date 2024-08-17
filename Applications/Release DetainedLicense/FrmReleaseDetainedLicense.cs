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

namespace DVLD___Driving_Licenses_Managment.Applications.Release_DetainedLicense
{
    public partial class FrmReleaseDetainedLicense : Form
    {
        private clsDetainedLicenses info;
        private clsLicenses CurrentLicense;
        private int CurrentLicenseID = -1; 

        public FrmReleaseDetainedLicense(int LicenseID = -1)
        {
            CurrentLicenseID = LicenseID;
            InitializeComponent();
        }

        //private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        //{
        //    CurrentLicenseID = obj;
        //    CurrentLicense = cntrlLicenseInfoWithFilter1.SelectedLicenseInfo;
           

        //    if (!CurrentLicense.isDetained)
        //    {
        //        MessageBox.Show("This license is NOT Detained, choose another one!", "Message Box",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    btnIReleaseLicense.Enabled = true; 
        //    lnkShowLicenseInfo.Enabled = true;
        //    lnkShowPersonHistory.Enabled = true; 

        //    info = clsDetainedLicenses.FindByLicenseID(CurrentLicenseID);
        //    decimal appFees = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.ReleaseDetainedDL); 

        //    lblLicenseID.Text = CurrentLicenseID.ToString();
        //    lblCreatedByUserID.Text = clsUser.Username(CurrentLicense.CreatedByUserID);
        //    lblReleaseByUserID.Text = clsGlobal.CurrentUser.username;
        //    lblFineFees.Text = info.FineFees.ToString();
        //    lblApplicaionFees.Text = appFees.ToString();
        //    lblTotalFees.Text = (info.FineFees + appFees).ToString();
        //}

        private void lnkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo form = new FrmShowLicenseInfo(CurrentLicenseID);
            form.ShowDialog();
        }

        private void lnkShowPersonHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory(CurrentLicense.DriverInfo.PersonID);
            form.ShowDialog();
        }

        private void btnIReleaseLicense_Click(object sender, EventArgs e)
        {
            if (CurrentLicense.ReleaseLicense(clsGlobal.CurrentUser.ID))
            {

                MessageBox.Show("License Released Successfully", "Message Box",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                info = clsDetainedLicenses.FindByLicenseID(CurrentLicenseID);
                btnIReleaseLicense.Enabled = false;
                lblReleaseID.Text = info.ReleaseApplicationID.ToString();
                lblReleaseDate.Text = info.ReleaseDate.ToShortDateString();
            }
        }

        private void FrmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            if(CurrentLicenseID != -1)
            {
                cntrlLicenseInfoWithFilter1.FilterEnabled = false;
                cntrlLicenseInfoWithFilter1.LoadLicenseInfo(CurrentLicenseID); 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(object sender, Controls.cntrlLicenseInfoWithFilter.LicensesSelectedEventArgs e)
        {
            CurrentLicenseID = e.SelectedLicense.ID;
            CurrentLicense = e.SelectedLicense;


            if (!CurrentLicense.isDetained)
            {
                MessageBox.Show("This license is NOT Detained, choose another one!", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIReleaseLicense.Enabled = true;
            lnkShowLicenseInfo.Enabled = true;
            lnkShowPersonHistory.Enabled = true;

            info = clsDetainedLicenses.FindByLicenseID(CurrentLicenseID);
            decimal appFees = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.ReleaseDetainedDL);

            lblLicenseID.Text = CurrentLicenseID.ToString();
            lblCreatedByUserID.Text = clsUser.Username(CurrentLicense.CreatedByUserID);
            lblReleaseByUserID.Text = clsGlobal.CurrentUser.username;
            lblFineFees.Text = info.FineFees.ToString();
            lblApplicaionFees.Text = appFees.ToString();
            lblTotalFees.Text = (info.FineFees + appFees).ToString();
        }
    }
}
