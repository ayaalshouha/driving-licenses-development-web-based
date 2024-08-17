using DVLD___Driving_Licenses_Managment.License;
using DVLD_Buissness;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Controls
{
    public partial class cntrlDrivingLicenseAndApplicationBasicInfo : UserControl
    {
        private clsLocalDrivingLicenses local_application;
        private clsApplication main_application;
        private int local_applicationID = -1;
        public cntrlDrivingLicenseAndApplicationBasicInfo()
        {
            InitializeComponent();
        }
        
        private void _Clear()
        {
            //reset local application info 
            lblLicenseID.Text = "[???]";
            lblLincenseClass.Text = "[???]";
            lblPassedTest.Text = "[???]";


            //reset basic application info
            lblApplicantName.Text = "[???]";
            lblID.Text = "[???]"; 
            lblStatus.Text = "[???]";
            lblType.Text  = "[???]";
            lblDate.Text  = "[???]";
            lblStatus.Text = "[???]";
            lblCreatedBy.Text = "[???]";
            lblFees.Text = "[???]";

            //enable links
            LinkShowLicenseInfo.Enabled = false;
            LinkViewPeronInfo.Enabled = false; 

        }
        public void LoadInformation(int ID)
        {
            local_applicationID = ID;
            local_application = clsLocalDrivingLicenses.Find(local_applicationID);


            if (local_application == null)
            {
                MessageBox.Show("Local Application NOT Found!", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Clear();
                return;
            }

            main_application = clsApplication.Find(local_application.ApplicationID);
            
            //local application info 
            lblLicenseID.Text = local_applicationID.ToString();
            lblLincenseClass.Text = local_application.LicenseClassesInfo.ClassName; 
            lblPassedTest.Text = clsLocalDrivingLicenses.PassedTest(local_application.ID).ToString() + "/3.";

            //basic application info
            
            lblID.Text = main_application.ID.ToString();
            lblStatus.Text = main_application.StatusText;
            lblType.Text = main_application.TypeInfo.TypeTitle; 
            lblFees.Text = main_application.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.Username(main_application.CreatedByUserID);
            lblFullName.Text = main_application.ApplicantFullName(); 
            lblDate.Text = main_application.Date.ToString();
            lblStatusDate.Text = main_application.lastStatusDate.ToString();

            //show license info link 
            LinkShowLicenseInfo.Enabled = local_application.isLicenseIssued();

            //show person info link
            LinkViewPeronInfo.Enabled = true;
        }

        private void lblViewPeronInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowPersonCard form = new FrmShowPersonCard(main_application.PersonID); 
            form.ShowDialog();
        }
        private void LinkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowLicenseInfo form = new FrmShowLicenseInfo(local_application.getLicenseID());
            form.ShowDialog();
        }
    }
}
