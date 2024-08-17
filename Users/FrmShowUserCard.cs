using DVLD_Buissness;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment.Forms
{
    public partial class FrmShowUserCard : Form
    {
        private int UserID = -1;
        private bool _EditUserCard = false; 

        public bool EditUserCard
        {
            get { return _EditUserCard; }
            set 
            { 
                _EditUserCard = value;
                linkLabel1.Enabled = _EditUserCard; 
            }
        }
        public FrmShowUserCard(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        private void FrmShowUserCard_Load(object sender, EventArgs e)
        {
            cntrUserCard1.LoadUserInfo(UserID); 
        }
        public void Update(object sender, int UserID)
        {
            cntrUserCard1.LoadUserInfo(UserID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddEditUser Form = new FrmAddEditUser(cntrUserCard1.ID());
            Form.Databack += Update;
            Form.Show();
        }
    }
}
