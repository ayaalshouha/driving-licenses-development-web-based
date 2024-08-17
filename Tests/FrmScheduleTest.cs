using DVLD___Driving_Licenses_Managment.Properties;
using DVLD_Buissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Buissness.clsTestTypes;

namespace DVLD___Driving_Licenses_Managment.Tests
{
    
    public partial class FrmScheduleTest : Form
    {
        private int _LocalApplicationID = -1; 
        private clsTestTypes.enTestType enTestType;
        private int _AppointmentID = -1; 
        public FrmScheduleTest(int LocalID, clsTestTypes.enTestType TestType, int AppointmetnID = -1)
        {
            enTestType = TestType;
            _LocalApplicationID = LocalID;
            _AppointmentID= AppointmetnID;
            InitializeComponent();
        }


        private void FrmScheduleTest_Load(object sender, EventArgs e)
        {
            cntrlScheduleTest1.TestTypeID = enTestType;
            cntrlScheduleTest1.LoadInfo(_LocalApplicationID, _AppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cntrlScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
