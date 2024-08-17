using System;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmFindPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID); 

        public DataBackEventHandler DataBack;
        public FrmFindPerson()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!cntrlPersonCardWithFilter1.isNull()){
                DataBack?.Invoke(this, cntrlPersonCardWithFilter1.ID);
            }
            this.Close();
        }

        private void cntrlPersonCardWithFilter1_onPersonSelected(object sender, cntrlPersonCardWithFilter.PersonEventArgs e)
        {

        }
    }
}
