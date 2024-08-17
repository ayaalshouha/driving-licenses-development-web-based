using DVLD_Buissness;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmAddEditLocalLicenseApplication : Form
    {

        private clsApplication MainApplication;
        private clsLocalDrivingLicenses LocalDL_Application;
        private int locallicenseID = -1;
        private int personID = -1;
        private enum enMode { Add, Update };
        enMode Mode;

        public FrmAddEditLocalLicenseApplication(int ID = -1)
        {
            locallicenseID = ID;
            InitializeComponent();
            Mode = locallicenseID == -1 ? enMode.Add : enMode.Update;
        }
        private void UpdateScreen()
        {
            
            lblHeader.Text = "Update Local Driving License Application";
            lblApplicationID.Text = MainApplication.ID.ToString();
            lblApplicationDate.Text = MainApplication.Date.ToString();
            lblCreatedByUsername.Text = clsUser.Username(MainApplication.CreatedByUserID);
            cbLicenseClasses.SelectedItem = LocalDL_Application.LicenseClassID;
            Mode = enMode.Update;
        }
        public void LoadApplicationInfoByID()
        {
            LocalDL_Application = clsLocalDrivingLicenses.Find(locallicenseID);
            MainApplication = clsApplication.Find(LocalDL_Application.ApplicationID);

            cntrlPersonCardWithFilter1.LoadPersonInfo(MainApplication.PersonID);
            cntrlPersonCardWithFilter1.FilterEnabeled = false;

            lblApplicationDate.Text = MainApplication.Date.ToString();
            lblApplicationFees.Text = MainApplication.PaidFees.ToString();
            lblCreatedByUsername.Text = clsUser.Username(MainApplication.CreatedByUserID);
            lblApplicationID.Text = MainApplication.ID.ToString();
            cbLicenseClasses.SelectedIndex = LocalDL_Application.LicenseClassID - 1;
        }

        public void FillTheLabels()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUsername.Text = clsGlobal.CurrentUser.username;
            lblApplicationFees.Text = clsApplicationTypes.Fee((int)clsApplication.enApplicationTypes.NewLocalDL).ToString();
        }

        public void FillLicenseClassesComboBox()
        {
            List<string> Classes = clsLicenseClasses.ClassesNames();
            cbLicenseClasses.DataSource = Classes;
            cbLicenseClasses.SelectedIndex = 0;
        }

        public void FillApplicationInfo()
        {
            if(Mode == enMode.Add)
            {
                MainApplication = new clsApplication();
                LocalDL_Application = new clsLocalDrivingLicenses();

                MainApplication.TypeID = (int)clsApplication.enApplicationTypes.NewLocalDL;
                MainApplication.Status = clsApplication.enApplicationSatatus.New;
                MainApplication.TypeInfo = clsApplicationTypes.Find(MainApplication.TypeID); 
                MainApplication.PaidFees = MainApplication.TypeInfo.Fees;
                MainApplication.Date = DateTime.Now;
                MainApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;
                MainApplication.lastStatusDate = DateTime.Now;
                MainApplication.PersonID = cntrlPersonCardWithFilter1.ID;

                LocalDL_Application.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;
            }
            else
            {
                MainApplication.lastStatusDate = DateTime.Now;
                LocalDL_Application.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;
                MainApplication.PaidFees = clsApplicationTypes.Fee((int)MainApplication.TypeID);
            }
        }

        private void FrmAddEditLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            FillLicenseClassesComboBox();

            if (Mode == enMode.Add)
            {
                btnSave.Enabled = false;
                tabPageApplicationInfo.Enabled = false;
                lblHeader.Text = "New Local Driving License Application";
                FillTheLabels();
            }
            else
            {
                lblHeader.Text = "Update Local Driving License Application";
                LoadApplicationInfoByID();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cntrlPersonCardWithFilter1.isNull())
            {
                MessageBox.Show("Please select a person first!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            tabPageApplicationInfo.Enabled = true; 
            tabControl1.SelectedTab = tabPageApplicationInfo;  
        }

        private void FinishingProcess()
        {
            FillApplicationInfo();

            if (MainApplication.Save())
            {
                LocalDL_Application.ApplicationID = MainApplication.ID;
                if (LocalDL_Application.Save())
                {
                    MessageBox.Show("Applciation Completed Successfully", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateScreen();
                    btnSave.Enabled = false;
                }
            }
            else
                MessageBox.Show("Something went wrong while saving,check again!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int PersonBirthYear = clsPerson.Find(personID).BirthDate.Year;
            int PersonAge = DateTime.Now.Year - PersonBirthYear;
            int MinimumAge = clsLicenseClasses.Find(cbLicenseClasses.SelectedIndex + 1).MinimumAllowedAge; // 18
            
            if(clsApplication.isClassExist(cntrlPersonCardWithFilter1.ID, cbLicenseClasses.SelectedIndex + 1))
            {
                MessageBox.Show("another application with the same class is already exist!", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (MinimumAge < PersonAge)
            {
                MessageBox.Show("Age does NOT meet the minimum requirement for applying to this class", "Message Box",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            FinishingProcess();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cntrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            personID = obj;
            tabPageApplicationInfo.Enabled = true;
            btnSave.Enabled = true; 
        }

        private void FrmAddEditLocalLicenseApplication_Activated(object sender, EventArgs e)
        {
            cntrlPersonCardWithFilter1.FilterFocused(); 
        }
    }
}
