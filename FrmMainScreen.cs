using DVLD___Driving_Licenses_Managment.Applications;
using DVLD___Driving_Licenses_Managment.Applications.DamagedApplication;
using DVLD___Driving_Licenses_Managment.Applications.Detain_License;
using DVLD___Driving_Licenses_Managment.Applications.International_Application;
using DVLD___Driving_Licenses_Managment.Applications.Release_DetainedLicense;
using DVLD___Driving_Licenses_Managment.Applications.Renew_Application;
using DVLD___Driving_Licenses_Managment.Drivers;
using DVLD___Driving_Licenses_Managment.Forms;
using DVLD___Driving_Licenses_Managment.License.Detain_License;
using DVLD___Driving_Licenses_Managment.Tests;
using DVLD_Buissness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmMainScreen : Form
    {
        private FrmLogin _LoginForm; 
        public FrmMainScreen(FrmLogin loginform)
        {
            _LoginForm = loginform;  
            InitializeComponent();
            lblLoggedInUser.Text += clsGlobal.CurrentUser.username;

            //form closing handler
            this.FormClosing += FrmMainScreen_FormClosing;
        }

        private void FrmMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _LoginForm.Show();
            //this.Close();
        }
        private void managePeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManagePeople Form = new FrmManagePeople();
            //Form.MdiParent = this;
            Form.ShowDialog();
        }

        private void FrmMainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close(); 
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageUsers Form = new FrmManageUsers();
            //Form.MdiParent = this;
            Form.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShowUserCard Form = new FrmShowUserCard(clsGlobal.CurrentUser.ID);
            //Form.MdiParent = this;
            Form.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangePassword Form = new FrmChangePassword(clsGlobal.CurrentUser.ID); 
            //Form.MdiParent = this;
            Form.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null; 
            _LoginForm.Show(); 
            this.Close();
        }

        private void manageApplicationsTypesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageApplicationTypes form = new FrmManageApplicationTypes();
            //form.MdiParent = this;
            form.ShowDialog();
        }

        private void manageTeststoolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FrmManageTestTypes form = new FrmManageTestTypes();
            //form.MdiParent = this;
            form.ShowDialog();

        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new local application section
            //add edit 
            FrmAddEditLocalLicenseApplication form = new FrmAddEditLocalLicenseApplication();
            //form.MdiParent = this;
            form.ShowDialog(); 
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //manage section
            FrmManageLocalDrivingLicenseApplications form = new FrmManageLocalDrivingLicenseApplications();
            //form.MdiParent = this;
            form.ShowDialog();

        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //manage drivers
            FrmManageDrivers form = new FrmManageDrivers();
            form.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //manage international licenses form 
            FrmManageInternationalLicenses form = new FrmManageInternationalLicenses();
            //form.MdiParent = this;
            form.ShowDialog();
        }

        private void internationalDrivingLisenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //form adding new international license applicatoin 
            FrmInternationalApplication form = new FrmInternationalApplication();
            //form.MdiParent = this;
            form.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //renew driving license 
            FrmRenewLicenseApplication form = new FrmRenewLicenseApplication();
            //form.MdiParent = this;  
            form.ShowDialog();
        }

        private void lostDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //replacement for lost or damaged license 
            FrmDamagedLostApplication form = new FrmDamagedLostApplication();
            //form.MdiParent = this;
            form.ShowDialog();
        }
        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //detain license form 
            FrmDetainLicenseApplication form = new FrmDetainLicenseApplication();
            form.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Release license From 
            FrmReleaseDetainedLicense form = new FrmReleaseDetainedLicense(); 
            form.ShowDialog();    

        }
        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //manage detained licenses
            FrmManageDetainedlicenses form = new FrmManageDetainedlicenses(); 
            form.ShowDialog();
        }

        private void lblLoggedInUser_Click(object sender, EventArgs e)
        {
            FrmShowUserCard Form = new FrmShowUserCard(clsGlobal.CurrentUser.ID);
            //Form.MdiParent = this;
            Form.EditUserCard = false;
            Form.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageLocalDrivingLicenseApplications form = new FrmManageLocalDrivingLicenseApplications();
            form.ShowDialog();
        }

        private void lblLoggedInUser_MouseHover(object sender, EventArgs e)
        {
            lblLoggedInUser.BorderStyle = BorderStyle.FixedSingle; 
        }

        private void lblLoggedInUser_MouseLeave(object sender, EventArgs e)
        {
            lblLoggedInUser.BorderStyle = BorderStyle.None;
        }

        private void FrmMainScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
