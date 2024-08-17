using DVLD_Buissness;
using System;
using System.Windows.Forms;
using static DVLD___Driving_Licenses_Managment.Controls.cntrlLicenseInfoWithFilter;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class cntrlPersonCardWithFilter : UserControl
    {
        ////Define a custom event handler delegate with parameters
        //public event Action<int> OnPersonSelected;

        ////Create a protected method to raise the event with a parameter
        //protected virtual void PersonSelected(int PersonID)
        //{
        //    Action<int> handler = OnPersonSelected;
        //    if (handler != null)
        //    {
        //        //Raise the event with the parameter
        //        handler(PersonID);
        //    }
        //}

        public class PersonEventArgs : EventArgs
        {
            public clsPerson SelectedPerson { get; }
            public PersonEventArgs(clsPerson person)
            {
                this.SelectedPerson = person;
            }
        }

        public event EventHandler<PersonEventArgs> onPersonSelected;

        public void RaiseOnPersonSelected( clsPerson perosn)
        {
            RaiseOnPersonSelected(new PersonEventArgs(perosn));
        }
        protected virtual void RaiseOnPersonSelected(PersonEventArgs e)
        {
            onPersonSelected?.Invoke(this, e);
        }

        public cntrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabeled = true;
        public bool FilterEnabeled
        {
            get { return _FilterEnabeled;}
                
            set{
                _FilterEnabeled = value;
                gbFilterBox.Enabled = _FilterEnabeled;
            }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return cntrPersonCard1.SelectedPersonInfo; }
        }
        public void UpdateData(object sender, int PersonID)
        {
            // Handle the data received
            if (PersonID != -1)
            {
                cntrPersonCard1.LoadPersonInfo(PersonID);
                FilterEnabeled = false;
                txtInput.Text = PersonID.ToString();
                cbFindby.Text = "PersonID";
            }
        }
        public int ID
        {
            get { return cntrPersonCard1.ID; }
        }

        public void FilterFocused()
        {
            txtInput.Focus();
        }
        private void cntrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFindby.SelectedIndex = 1;
            txtInput.Focus();
        }

        public void LoadPersonInfo(int personID)
        {
            if (clsPerson.isExist(personID))
            {
                cntrPersonCard1.LoadPersonInfo(personID);
                txtInput.Text = personID.ToString();
                cbFindby.Text = "PersonID";

                if (onPersonSelected != null)
                {
                    //PersonSelected(personID);
                    RaiseOnPersonSelected(SelectedPersonInfo);
                }
            }
            else
                MessageBox.Show("Person NOT Found", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error); 
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                return; 
            }

            if(cbFindby.SelectedItem.ToString() == "PersonID")
            {
                if(int.TryParse(txtInput.Text, out int PeronID)){

                    cntrPersonCard1.LoadPersonInfo(PeronID);
                    if (onPersonSelected != null)
                    {
                        //PersonSelected(personID);
                        RaiseOnPersonSelected(SelectedPersonInfo);
                    }
                }
            }
            else
            {
                cntrPersonCard1.LoadPersonInfo(txtInput.Text);
            }
        }

        public bool isNull()
        {
            return cntrPersonCard1.ID <= 0;  
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            //person ID back form adding person form to the control and control be filled with its info
            FrmAddEditPerson Form = new FrmAddEditPerson();
            Form.DataBack += UpdateData;
            Form.ShowDialog();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if user press enter then perform find event
            if (e.KeyChar == (char)13)
                btnFind.PerformClick(); 


            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
