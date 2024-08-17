using DVLD_Buissness;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmAddEditUser : Form
    {
        private clsUser _User; 
        private int _UserID = 0;
        private enum enMode { Add, Update};
        private enMode Mode;

        public delegate void FrmAddEditUserEventHandler(object sender, int UserID);
        public event FrmAddEditUserEventHandler Databack;

        public FrmAddEditUser(int UserID = -1)
        {
            InitializeComponent();
            _UserID = UserID;
            Mode = _UserID == -1 ? enMode.Add : enMode.Update;
        }

        private void FillData()
        {
            cntrPersonCard1.LoadPersonInfo(_User.PersonID);
            txtUsername.Text = _User.username;
            txtPassword.Text = _User.password;
            txtPassCheck.Text = _User.password;
            chkIsActive.Checked = _User.isActive ? true: false;
            lblUserID.Text = _UserID.ToString();
        }

        private void AssignData()
        {
            _User.username = txtUsername.Text;
            _User.password = clsGlobal.ComputeHash(txtPassword.Text);
            _User.isActive = chkIsActive.Checked ? true : false;
            _User.PersonID = cntrPersonCard1.ID;
        }

        private void Update(object sender, int PersonID)
        {
            cntrPersonCard1.LoadPersonInfo(PersonID); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Select_Person_Button
            FrmFindPerson Form = new FrmFindPerson();
            Form.DataBack += Update;
            Form.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cntrPersonCard1.isNull())
            {
                MessageBox.Show("Please select a person first!", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (Mode==enMode.Add)
            {
                if (clsUser.isExist_ByPersonID(cntrPersonCard1.ID))
                {
                    MessageBox.Show("User already exist, choose another person", "Message Box",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            tabLogicInfo.Enabled = true;
            tabControl1.SelectedTab = tabLogicInfo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cntrPersonCard1.isNull() 
                || string.IsNullOrEmpty(txtUsername.Text) 
                || string.IsNullOrEmpty(txtPassword.Text) 
                || string.IsNullOrEmpty(txtPassCheck.Text))
                
            {
                MessageBox.Show("Please complete person/user information!", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Mode == enMode.Add)
            {
                AssignData();
                Mode = enMode.Update;
            }
            else 
                AssignData();



            if (_User.Save())
            {
                MessageBox.Show("User saved successfully", "Message Box",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                _UserID = _User.ID;
                lblHeader.Text = "Update User";
                lblUserID.Text = _UserID.ToString();
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if(Mode == enMode.Add)
            {
                if (clsUser.isExist(txtUsername.Text.Trim()))
                {
                    errorProvider1.SetError(txtUsername, "Username is already used by another user!");
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.Clear();
                }
            }
        }

        private void txtPassCheck_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() != txtPassCheck.Text.Trim())
            {
                errorProvider1.SetError(txtPassword, "Passwords NOT Matched!");
                errorProvider1.SetError(txtPassCheck, "Passwords NOT Matched!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int UserID = _UserID;
            Databack?.Invoke(this, UserID);
            this.Close();
        }

        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            if(Mode == enMode.Add)
            {
                _User = new clsUser();
                lblHeader.Text = "Add New User";
                tabLogicInfo.Enabled = false;
                return; 
            }
            
            _User = clsUser.Find(_UserID);
            lblHeader.Text = "Update User"; 
            btnSelectPerson.Enabled = false;
            btnUpdatePerson.Visible = true;
            btnUpdatePerson.Enabled = true;
            tabLogicInfo.Enabled = true; 
            FillData();
        }

        private void btnUpdatePerson_Click(object sender, EventArgs e)
        {
            FrmAddEditPerson Form = new FrmAddEditPerson(_User.PersonID);
            Form.DataBack += Update;
            Form.Show();
        }
    }
}
