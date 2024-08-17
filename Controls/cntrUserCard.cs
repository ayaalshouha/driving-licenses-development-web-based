using DVLD_Buissness;
using System.Windows.Forms;

namespace DVLD___Driving_Licenses_Managment
{
    public partial class cntrUserCard : UserControl
    {
        private clsUser _User;
        public cntrUserCard()
        {
            InitializeComponent();
        }
       
       public int ID()
        {
            return _User != null ? _User.ID : -1;
        }
        private void Clear()
        {
            lblUserID.Text = "[????]";
            lblUserName.Text = "[????]";
            lblisActive.Text = "[????]";
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.Find(UserID);

            if (_User != null)
            {
                cntrPersonCard1.LoadPersonInfo(_User.PersonID);
                lblUserID.Text = _User.ID.ToString();
                lblUserName.Text = _User.username;
                lblisActive.Text = (_User.isActive) ? "YES" : "NO";
            }
            else
            {
                cntrPersonCard1.Clear();
                Clear();
            }
        }

        private void LoadUserInfo(string username)
        {
            _User = clsUser.Find(username);

            if (_User != null)
            {
                cntrPersonCard1.LoadPersonInfo(_User.PersonID);
                lblUserID.Text = _User.ID.ToString();
                lblUserName.Text = _User.username;
                lblisActive.Text = (_User.isActive) ? "YES" : "NO";
            }
            else
            {
                cntrPersonCard1.Clear();
                Clear();
            }
        }
    }
}
