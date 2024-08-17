using DVLD___Driving_Licenses_Managment.Properties;
using DVLD_Buissness;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.IO;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class FrmAddEditPerson : Form
    {
        public delegate void FrmAddEditPersonEventHandler(object sender, int PersonID);

        public event FrmAddEditPersonEventHandler DataBack;

        private enum enMode { add, update }
        private enMode mode = enMode.add;
        private clsPerson _Person;
        private int _PersonID = -1;
        public FrmAddEditPerson(int ID = -1)
        {
            _PersonID = ID;
            InitializeComponent();
            mode = _PersonID == -1 ? enMode.add : enMode.update;
        }

        private void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person != null)
            {
                //upload persons data
                txtNationalNo.Text = _Person.NationalNumber;
                txtFirstName.Text = _Person.FirstName;
                txtLastName.Text = _Person.LastName;
                txtEmail.Text = _Person.Email;
                txtSecondName.Text = _Person.SecondName;
                txtThirdName.Text = _Person.ThirdName;
                txtPhone.Text = _Person.PhoneNumber;
                dateTimeBirthdate.Value = _Person.BirthDate;
                txtAddress.Text = _Person.Address;
                cbCountries.Text = _Person.Nationality;


                if (_Person.Gender == "Male")
                    rdMale.Checked = true;
                else
                    rdFemale.Checked = true;


                //upload image if not null
                if (_Person.PersonalPicture != "")
                {
                    pbDefaultPicture.ImageLocation = _Person.PersonalPicture;
                    llRemoveImage.Visible = true;
                }
            }
        }
        private void RadioButtonSelect(object sender, EventArgs e)
        {
            //if there is no picture in picture box , change the default picture 
            if (pbDefaultPicture.ImageLocation == null)
            {
                if (rdFemale.Checked)
                    pbDefaultPicture.Image = Resources.user_female__1_;
                else
                    pbDefaultPicture.Image = Resources.user__2_;
            }
        }

        private void _SetDefaultData()
        {
            //set default image 
            if (mode == enMode.add)
            {
                rdMale.Checked = true;
                pbDefaultPicture.Image = Resources.user__2_;
            }

            //load countries list 
            DataTable countries = clsCountries.GetAllCountries();
            foreach (DataRow row in countries.Rows)
            {
                cbCountries.Items.Add(row["nicename"]);
            }

            cbCountries.SelectedIndex = cbCountries.FindString("Jordan");

            //set the max date to 18 years from now 
            dateTimeBirthdate.MaxDate = DateTime.Now.AddYears(-18);
            dateTimeBirthdate.Value = dateTimeBirthdate.MaxDate;

            //should not allow adding age more than 100 years
            dateTimeBirthdate.MinDate = DateTime.Now.AddYears(-100);
        }

        private void AssignDataToPersonObject()
        {
            _Person.NationalNumber = txtNationalNo.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.PhoneNumber = txtPhone.Text.Trim();
            _Person.BirthDate = dateTimeBirthdate.Value;
            _Person.Address = txtAddress.Text.Trim();
            _Person.Nationality = cbCountries.Text.Trim();
            _Person.Gender = rdFemale.Checked ? "Female" : "Male";

            if (mode == enMode.add)
            {
                //creation mode 
                _Person.CreatedByUserID = clsGlobal.CurrentUser.ID;
                _Person.CreationDate = DateTime.Now;
            }
            else
            {
                //updating mode 
                _Person.UpdateByUserID = clsGlobal.CurrentUser.ID;
                _Person.UpdateDate = DateTime.Now;
            }



            if (pbDefaultPicture.ImageLocation != null)
                _Person.PersonalPicture = pbDefaultPicture.ImageLocation;
            else
                _Person.PersonalPicture = "";

            // ((openFileDialog1.FileName = pbDefaultPicture.ImageLocation))
        }

        private void FrmAddEditPerson_Load(object sender, EventArgs e)
        {
            _SetDefaultData();


            if (mode == enMode.update)
            {
                _Person = clsPerson.Find(_PersonID);

                if (_Person != null)
                {
                    lblHeader.Text = "Update Person";
                    lblID.Text = _PersonID.ToString();
                    LoadPersonInfo(_PersonID);
                }
            }
            else
            {
                _Person = new clsPerson();
                lblHeader.Text = "Add New Person";
            }
        }

        private bool _HandleImage()
        {
            
            //check if the current image in picture box is the same as person image
            //if not the same then delete the previous image 
            if (pbDefaultPicture.ImageLocation != _Person.PersonalPicture)
            {
                if (_Person.PersonalPicture != "")
                {
                    File.Delete(_Person.PersonalPicture);
                    _Person.PersonalPicture = "";
                }
            }

            //the copying image procedure 
            if (pbDefaultPicture.ImageLocation != null)
            {
                string SourceFile = pbDefaultPicture.ImageLocation.ToString();
                if (clsGlobal.CopyImageToProjectFolder(ref SourceFile))
                {
                    _Person.PersonalPicture = SourceFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are NOT valid, check errors", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleImage())
                return;


            AssignDataToPersonObject();

            if (_Person.Save())
            {
                _PersonID = _Person.ID;
                mode = enMode.update;
                lblHeader.Text = "Update Person";
                lblID.Text = _PersonID.ToString();
                MessageBox.Show("Person saved Successfully", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_PersonID != -1)
                {
                    // Trigger the event to send data back to the caller form.
                    DataBack?.Invoke(this, _Person.ID);
                }

            }
            else
                MessageBox.Show("Something went wrong! please try again!", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            int PersonID = _PersonID;
            DataBack?.Invoke(this, PersonID);
            this.Close();
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtNationalNo.Text.Length < 10)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National no. must be a 10-digits number!");
                return;

            }
            else
                errorProvider1.SetError(txtNationalNo, null);



            if (!clsGlobal.isNumber(txtNationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "Invalid National Number!");
                return;
            }
            else
                errorProvider1.SetError(txtNationalNo, null);

            if (mode == enMode.add)
            {
                if (clsPerson.isExist(txtNationalNo.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtNationalNo, "NationalNo already used!");
                    return;
                }
                else
                    errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!clsGlobal.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "NOT a valid E-mail!");
            }
            else
                errorProvider1.SetError(txtEmail, null);
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Set image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.ico;*.tiff;*.tif";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //to show selected picture in picture box 
                //Image image = Image.FromFile(openFileDialog1.FileName);
                //pbDefaultPicture.Image = image;

                string ImagePath = openFileDialog1.FileName;
                pbDefaultPicture.Load(ImagePath);
                llRemoveImage.Visible = true;
            }
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            //set autovalidate property
            TextBox Temp = (TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This is required");
            }
            else
                errorProvider1.SetError(Temp, null);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "This is required");
            }
            else
                errorProvider1.SetError(txtPhone, null);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "This is required");
            }
            else
                errorProvider1.SetError(txtAddress, null);
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbDefaultPicture.ImageLocation = null;

            if (rdFemale.Checked)
                pbDefaultPicture.Image = Resources.user_female__1_;
            else
                pbDefaultPicture.Image = Resources.user__2_;

            llRemoveImage.Visible = false;
        }

    }
}
