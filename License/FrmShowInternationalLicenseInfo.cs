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
    public partial class FrmShowInternationalLicenseInfo : Form
    {
        private int _LicenseID =-1;
        public FrmShowInternationalLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            InitializeComponent();
        }

        private void FrmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            cntrlInternationalLicenseInfo1.LoadLicenseInfo(_LicenseID); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
