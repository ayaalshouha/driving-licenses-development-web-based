using DVLD_Buissness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Tests
{
    public partial class FrmTakeTest : Form
    {
        private clsTests _Test;
        private int _TestID = -1;

        private clsTestTypes.enTestType enTestType = clsTestTypes.enTestType.VisionTest;
        private int Appointment_ID = -1;

        public FrmTakeTest(clsTestTypes.enTestType TestTypeID, int AppointmentID)
        {
            InitializeComponent();
            enTestType=TestTypeID;
            Appointment_ID = AppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the result!.",
                     "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _Test.AppointmentID = Appointment_ID;

            if (rbPass.Checked)
                _Test.Result = true;
            else
                _Test.Result = false;

            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.ID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Message Box.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
             else
                MessageBox.Show("Error: Data does NOT saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmTakeTest_Load(object sender, EventArgs e)
        {

            cntrlScheduledTest1.TestTypeID = enTestType;
            cntrlScheduledTest1.LoadInformation(Appointment_ID); 

            if(cntrlScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled=true;
            


            _TestID = cntrlScheduledTest1.TestID;

            if(_TestID != -1)
            {
                _Test = clsTests.Find(_TestID);

                if (_Test.Result)
                {
                    rbPass.Checked = true;
                }
                else
                {
                    rbFail.Checked = false;
                }

                txtNotes.Text = _Test.Notes;
                btnSave.Enabled = false;
                rbFail.Enabled= false;
                rbPass.Enabled= false;
                lblUserMessage.Visible = true; 
                txtNotes.Enabled= false;    

            }
            else
            {
                _Test = new clsTests();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
