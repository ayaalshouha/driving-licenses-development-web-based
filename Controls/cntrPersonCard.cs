using DVLD___Driving_Licenses_Managment.Properties;
using DVLD_Buissness;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO; 

namespace DVLD___Driving_Licenses_Managment
{
    public partial class cntrPersonCard : UserControl
    {
        private clsPerson Person;
        private int Person_id = -1;
        public cntrPersonCard()
        {
            InitializeComponent();
        }
        public int ID { get { return Person_id; } }

        public clsPerson SelectedPersonInfo { get { return Person; } }
        public bool isNull()
        {
            return Person_id <= 0; 
        }
        public void Clear()
        {
            linkLabel1.Enabled = false;
            lblAddress.Text = "[????]";
            lblBirthdate.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblNationalID.Text = "[????]";
            lblName.Text = "[????]";
            lblGender.Text = "[????]";
            lblPhone.Text = "[????]";
            lblEmail.Text = "[????]";
            lblCountry.Text = "[????]";
            pbProfilePicture.Image = Resources.user_male;
        }

       public void LoadPersonInfo(int PersonID)
       {
            Person = clsPerson.Find(PersonID); 
            if(Person != null )
            {
                linkLabel1.Enabled = true; 
                lblNotes.Visible = false;
                Person_id = Person.ID;
                lblAddress.Text = Person.Address;
                lblBirthdate.Text = Person.BirthDate.ToShortDateString(); 
                lblPersonID.Text = Person.ID.ToString();
                lblNationalID.Text = Person.NationalNumber.ToString();
                lblName.Text = Person.FullName(); 
                lblGender.Text = Person.Gender;
                lblPhone.Text = Person.PhoneNumber;
                lblEmail.Text = Person.Email;
                lblCountry.Text = Person.Nationality;

                string ImagePath = Person.PersonalPicture;

                if (ImagePath != "")
                {
                    try
                    {
                        //Image image = Image.FromFile(ImagePath);
                        //pbProfilePicture.Image = image;

                        if (File.Exists(ImagePath))
                            pbProfilePicture.ImageLocation = ImagePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading the image: " + ex.Message);
                    }
                }
            }
            else
            {
                lblNotes.Visible = true;
                lblNotes.Text = "NOT FOUND";
                Clear();
            }
       }
        public void LoadPersonInfo(string NationalNo)
        {
            Person = clsPerson.Find(NationalNo);

            if (Person != null)
            {
                linkLabel1.Enabled = true;
                lblNotes.Visible = false;
                Person_id = Person.ID;
                lblAddress.Text = Person.Address;
                lblBirthdate.Text = Person.BirthDate.Date.ToShortDateString();
                lblPersonID.Text = Person.ID.ToString();
                lblNationalID.Text = Person.NationalNumber.ToString();
                lblName.Text = Person.FullName();
                lblGender.Text = Person.Gender;
                lblPhone.Text = Person.PhoneNumber;
                lblEmail.Text = Person.Email;
                lblCountry.Text = Person.Nationality;

                string ImagePath = Person.PersonalPicture;
                if (ImagePath != "")
                {
                    try
                    {
                        //Image image = Image.FromFile(ImagePath);
                        //pbProfilePicture.Image = image;

                        if (File.Exists(ImagePath))
                            pbProfilePicture.ImageLocation = ImagePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading the image: " + ex.Message);
                    }
                }
            }
            else
            {
                lblNotes.Visible = true;
                lblNotes.Text = "NOT FOUND";
                Clear();
            }
        }
        private void cntrPersonCard_Load(object sender, EventArgs e)
        {
            Person = new clsPerson();
            Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditPerson Form = new FrmAddEditPerson(Person.ID);
            Form.ShowDialog();
            //refresh
            LoadPersonInfo(Person.ID);
        }
    }
}
