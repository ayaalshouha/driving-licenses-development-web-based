using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Applications.Local_Application
{
    public partial class FrmShpwApplicationInfo : Form
    {
        private int _LocalApplicationID = -1; 
        public FrmShpwApplicationInfo(int LocalLicenseapplicationID)
        {
            _LocalApplicationID = LocalLicenseapplicationID;
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmShpwApplicationInfo_Load(object sender, EventArgs e)
        {
            cntrl1.LoadInformation(_LocalApplicationID); 
        }
    }
}
