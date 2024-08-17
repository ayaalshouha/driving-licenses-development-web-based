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

namespace DVLD___Driving_Licenses_Managment.Applications.Renew_Application
{
    public partial class FrmRenewLicenseApplication : Form
    {
        private clsLicenses PreviousLicense; 
        private int PreviousLicenseID;
        private clsLicenses NewLicense;
        private int NewLicenseID;

        public FrmRenewLicenseApplication()
        {
            InitializeComponent();
        }

        //private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        //{
        //    PreviousLicenseID = obj;
        //    PreviousLicense = cntrlLicenseInfoWithFilter1.SelectedLicenseInfo;


        //    if (!PreviousLicense.isActive)
        //    {
        //        MessageBox.Show("Selected license is NOT active!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (PreviousLicense.ExpDate > DateTime.Now)
        //    {
        //        MessageBox.Show($"Selected License is NOT Expired yet, will be expired in {PreviousLicense.ExpDate.ToShortDateString()}", "Message Box",
        //          MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    btnIssueLicense.Enabled = true;
        //    lnkShowPersonHistory.Enabled = true;
        //    lblOldLicenseID.Text = PreviousLicenseID.ToString();
        //    lblIssueDate.Text = PreviousLicense.IssueDate.ToShortDateString();
        //    lblExpirationDate.Text = PreviousLicense.ExpDate.ToShortDateString();
        //    lblLicenseFees.Text = PreviousLicense.PaidFees.ToString();
        //    txtNotes.Text = PreviousLicense.Notes;
        //    lblCreatedByUser.Text = clsUser.Username(PreviousLicense.CreatedByUserID);
        //}
        private void lnkShowInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo form = new FrmShowLicenseInfo(NewLicenseID); 
            form.ShowDialog();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to renew this license?", "Message Box",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NewLicense = PreviousLicense.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.ID);

                if (NewLicense != null)
                {
                    MessageBox.Show($"License Renewd Successfully, New License ID = {NewLicense.ID}.", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    NewLicenseID = NewLicense.ID;

                    decimal AppFees = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.RenewDL);
                    lblRenewApplicationID.Text = NewLicense.ApplicationID.ToString();
                    lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                    lblIssueDate.Text = NewLicense.IssueDate.ToShortDateString();
                    lblExpirationDate.Text = NewLicense.ExpDate.ToShortDateString();
                    lblApplicationFees.Text = AppFees.ToString();
                    lblLicenseFees.Text = NewLicense.PaidFees.ToString();
                    txtNotes.Text = NewLicense.Notes.ToString();
                    lblRenewlLicenseID.Text = NewLicense.ID.ToString();
                    lblCreatedByUser.Text = NewLicense.CreatedByUserID.ToString();
                    lblTotalFees.Text = $"{NewLicense.PaidFees + AppFees}";
                    cntrlLicenseInfoWithFilter1.FilterEnabled = false;
                    lnkShowNewLicenseInfo.Enabled = true;
                    btnIssueLicense.Enabled = false;
                }
                else
                    MessageBox.Show("Error happened while saving new license, check again later", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            cntrlLicenseInfoWithFilter1.FilterFocus();
        }

        private void ShowPersonHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonLicensesHistory form = new FrmPersonLicensesHistory(PreviousLicense.DriverInfo.PersonID);
            form.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(object sender, Controls.cntrlLicenseInfoWithFilter.LicensesSelectedEventArgs e)
        {
            PreviousLicenseID = e.SelectedLicense.ID;
            PreviousLicense = e.SelectedLicense;


            if (!PreviousLicense.isActive)
            {
                MessageBox.Show("Selected license is NOT active!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PreviousLicense.ExpDate > DateTime.Now)
            {
                MessageBox.Show($"Selected License is NOT Expired yet, will be expired in {PreviousLicense.ExpDate.ToShortDateString()}", "Message Box",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnIssueLicense.Enabled = true;
            lnkShowPersonHistory.Enabled = true;
            lblOldLicenseID.Text = PreviousLicenseID.ToString();
            lblIssueDate.Text = PreviousLicense.IssueDate.ToShortDateString();
            lblExpirationDate.Text = PreviousLicense.ExpDate.ToShortDateString();
            lblLicenseFees.Text = PreviousLicense.PaidFees.ToString();
            txtNotes.Text = PreviousLicense.Notes;
            lblCreatedByUser.Text = clsUser.Username(PreviousLicense.CreatedByUserID);
        }
    }
}
