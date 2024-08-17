using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.License
{
    public partial class FrmShowLicenseInfo : Form
    {
        private int LicenseID = -1; 
        public FrmShowLicenseInfo(int License_ID)
        {
            LicenseID = License_ID;
            InitializeComponent();
        }

        private void FrmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            cntrlLicenseInfo1.LoadLicenseInfo(LicenseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
