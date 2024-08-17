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

namespace DVLD___Driving_Licenses_Managment.Applications.International_Application
{
    public partial class FrmInternationalApplication : Form
    {
        private clsApplication MainApplication;
        private clsInternational_DL InternationLicense; 
        private int InternationalLicenseID = -1; 
        private int LocalLicenseID = -1;

        public FrmInternationalApplication()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInternationalApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString(); 
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.NewInternationalDL).ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.username;
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
        }

        private void _AddingInternationalLicnseProcess()
        {
            if (MessageBox.Show("are you sure you want to issue a license?", "Message Box",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                MainApplication = new clsApplication();
                MainApplication.PersonID = cntrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
                MainApplication.Date = DateTime.Now;
                MainApplication.lastStatusDate = DateTime.Now;
                MainApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;
                MainApplication.Status = clsApplication.enApplicationSatatus.New;
                MainApplication.TypeID = (int)clsApplication.enApplicationTypes.NewInternationalDL;
                MainApplication.PaidFees = clsApplicationTypes.Fee(MainApplication.TypeID);

                if (MainApplication.Save())
                {
                    InternationLicense = new clsInternational_DL();
                    InternationLicense.ApplicationID = MainApplication.ID;
                    InternationLicense.DriverID = cntrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
                    InternationLicense.IssuedByLocalLicenseID = LocalLicenseID;
                    InternationLicense.IssueDate = DateTime.Now;
                    InternationLicense.ExpDate = DateTime.Now.AddYears(1);
                    InternationLicense.isActive = true;
                    InternationLicense.CreatedByUserID = clsGlobal.CurrentUser.ID;
                    

                    if (InternationLicense.Save())
                    {
                        MainApplication.setCompleted();
                        InternationalLicenseID = InternationLicense.ID;

                        MessageBox.Show("License issued successfully", "Message Box", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        btnIssueLicense.Enabled = false;
                        lnkShowInternationalLicenseInfo.Enabled = true;
                        lblApplicationID.Text = InternationLicense.ApplicationID.ToString();
                        lblInternationalLicenseID.Text = InternationalLicenseID.ToString();
                        return;
                    }
                }
            }
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (LocalLicenseID != -1)
            {
                if (cntrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass == 3 && cntrlLicenseInfoWithFilter1.SelectedLicenseInfo.isActive)
                    _AddingInternationalLicnseProcess();
                else
                {
                    MessageBox.Show("Selected license is NOT Allowed!", "Message Box", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    btnIssueLicense.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error with finding a local license! enter another License ID", "Message Box", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                btnIssueLicense.Enabled = false;
            }
        }


        //private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        //{
            //LocalLicenseID = obj;
            //lblLocalLicenseID.Text = LocalLicenseID.ToString();

            //if(cntrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClass == 3)
            //{
            //    int ActiveInternationalLicenseID = clsInternational_DL.getActiveLicenseID(cntrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            //    if (ActiveInternationalLicenseID == -1)
            //    {
            //        btnIssueLicense.Enabled = true;
            //        lnkShowInternationalLicenseInfo.Enabled = false;
            //    }
            //    else
            //    {
            //        MessageBox.Show("NOT ALLOWED! The selected license is already associated with an international license!", "Message Box",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);

            //        InternationalLicenseID = ActiveInternationalLicenseID;
            //        lnkShowInternationalLicenseInfo.Enabled = true;
            //        btnIssueLicense.Enabled = false;

            //        clsInternational_DL InternationaLicense = clsInternational_DL.Find(ActiveInternationalLicenseID);
                    
            //        lblInternationalLicenseID.Text = ActiveInternationalLicenseID.ToString();
            //        lblApplicationID.Text = InternationaLicense.ApplicationID.ToString();
            //        lblApplicationDate.Text = InternationaLicense.MainApplicationInfo.Date.ToShortDateString();
            //        lblCreatedByUser.Text = clsUser.Username(InternationaLicense.CreatedByUserID);
            //        lblIssueDate.Text = InternationaLicense.IssueDate.ToShortDateString();
            //        lblExpirationDate.Text = InternationaLicense.ExpDate.ToShortDateString();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Selected license is NOT Allowed, License class should be 3!", "Message Box", MessageBoxButtons.OK,
            //           MessageBoxIcon.Error);

            //    lblInternationalLicenseID.Text = "[???]";
            //    lblApplicationID.Text = "[???]";
            //    lblApplicationDate.Text = "[???]";
            //    btnIssueLicense.Enabled = false;
            //}

        //}

        private void lnkShowInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //form show international license details
            FrmShowInternationalLicenseInfo form = new FrmShowInternationalLicenseInfo(InternationalLicenseID); 
            form.ShowDialog();
        }

        private void cntrlLicenseInfoWithFilter1_OnLicenseSelected(object sender, Controls.cntrlLicenseInfoWithFilter.LicensesSelectedEventArgs e)
        {
            LocalLicenseID = e.SelectedLicense.ID;
            lblLocalLicenseID.Text = LocalLicenseID.ToString();

            if (e.SelectedLicense.LicenseClass == 3)
            {
                int ActiveInternationalLicenseID = clsInternational_DL.getActiveLicenseID(e.SelectedLicense.DriverID);

                if (ActiveInternationalLicenseID == -1)
                {
                    btnIssueLicense.Enabled = true;
                    lnkShowInternationalLicenseInfo.Enabled = false;
                }
                else
                {
                    MessageBox.Show("NOT ALLOWED! The selected license is already associated with an international license!", "Message Box",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    InternationalLicenseID = ActiveInternationalLicenseID;
                    lnkShowInternationalLicenseInfo.Enabled = true;
                    btnIssueLicense.Enabled = false;

                    clsInternational_DL InternationaLicense = clsInternational_DL.Find(ActiveInternationalLicenseID);

                    lblInternationalLicenseID.Text = ActiveInternationalLicenseID.ToString();
                    lblApplicationID.Text = InternationaLicense.ApplicationID.ToString();
                    lblApplicationDate.Text = InternationaLicense.MainApplicationInfo.Date.ToShortDateString();
                    lblCreatedByUser.Text = clsUser.Username(InternationaLicense.CreatedByUserID);
                    lblIssueDate.Text = InternationaLicense.IssueDate.ToShortDateString();
                    lblExpirationDate.Text = InternationaLicense.ExpDate.ToShortDateString();
                }
            }
            else
            {
                MessageBox.Show("Selected license is NOT Allowed, License class should be 3!", "Message Box", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);

                lblInternationalLicenseID.Text = "[???]";
                lblApplicationID.Text = "[???]";
                lblApplicationDate.Text = "[???]";
                btnIssueLicense.Enabled = false;
            }
        }
    }
}
