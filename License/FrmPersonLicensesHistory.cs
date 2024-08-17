using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.License
{
    public partial class FrmPersonLicensesHistory : Form
    {
        private int _PersonID = -1;
        public FrmPersonLicensesHistory(int PersonID = -1)
        {
            _PersonID = PersonID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPersonLicensesHistory_Load(object sender, EventArgs e)
        {
            if(_PersonID != -1)
            {
                cntrlPersonCardWithFilter1.FilterEnabeled = false;
                cntrlPersonCardWithFilter1.LoadPersonInfo(_PersonID); 
                cntrlDriver_sLicensesInfo1.LoadInfo_ByPersonID(_PersonID);
                return;
            }
            else
            {
                cntrlPersonCardWithFilter1.FilterEnabeled = true;
                cntrlPersonCardWithFilter1.FilterFocused(); 
            }

            MessageBox.Show("No ID Found", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }

        //private void cntrlPersonCardWithFilter1_OnPersonSelected(int obj)
        //{
        //    _PersonID = obj;
        //    cntrlPersonCardWithFilter1.FilterEnabeled = false; 
        //    cntrlDriver_sLicensesInfo1.LoadInfo_ByPersonID(_PersonID); 
        //}

        private void cntrlPersonCardWithFilter1_onPersonSelected(object sender, cntrlPersonCardWithFilter.PersonEventArgs e)
        {
            _PersonID = e.SelectedPerson.ID;
            cntrlPersonCardWithFilter1.FilterEnabeled = false;
            cntrlDriver_sLicensesInfo1.LoadInfo_ByPersonID(_PersonID);
        }
    }
}
