using DVLD___Driving_Licenses_Managment.Properties;
using DVLD_Buissness;
using System.IO;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Controls
{
    public partial class cntrlInternationalLicenseInfo : UserControl
    {
        private clsInternational_DL license;
        private int _LicenseID = -1;
        public cntrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public clsInternational_DL SelectedLicenseInfo
        { get { return license; } }

        public int ID
        {
            get
            {
                return _LicenseID;
            }
        }

        private void _LoadProfilePicture()
        {
            string imagePath = license.DriverInfo.PersonInfo.PersonalPicture;

            if (license.DriverInfo.PersonInfo.Gender == "Male")
                pbProfilePicture.Image = Resources.user_male;
            else
                pbProfilePicture.Image = Resources.user_female__1_;



            if (imagePath != "" && imagePath != string.Empty)
            {
                if (File.Exists(imagePath))
                    pbProfilePicture.Load(imagePath);
                return;
            }

            MessageBox.Show("Could not find this image: = " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Clear()
        {
            lblLicenseID.Text = "[????]";
            lblActive.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblBirthdate.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblExpDate.Text = "[????]";
            pbProfilePicture.Image = Resources.user_male;
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            license = clsInternational_DL.Find(_LicenseID);

            if (license != null)
            {
                lblLicenseID.Text = license.ID.ToString();
                lblActive.Text = license.isActive ? "Yes" : "No";
                lblName.Text = license.DriverInfo.PersonInfo.FullName();
                lblNationalNo.Text = license.DriverInfo.PersonInfo.NationalNumber;
                lblGender.Text = license.DriverInfo.PersonInfo.Gender;
                lblBirthdate.Text = license.DriverInfo.PersonInfo.BirthDate.ToShortDateString();
                lblDriverID.Text = license.DriverID.ToString();
                lblIssueDate.Text = license.IssueDate.ToShortDateString();
                lblExpDate.Text = license.ExpDate.ToShortDateString();
                _LoadProfilePicture();
                return;
            }

            MessageBox.Show("Could not find this license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
