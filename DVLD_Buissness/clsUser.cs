using DVLD_Data;
using System.Data;

namespace DVLD_Buissness
{
    public class clsUser
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public enum enMode { Add, Update };
        public enMode _Mode { get; set; }

        public clsUser()
        {
            ID = -1;
            PersonID = -1; 
            username = "";
            password = "";
            isActive = false; 
            _Mode = enMode.Add;
        }

        private clsUser(stUser User)
        {
            ID = User.ID;
            PersonID = User.PersonID; 
            username = User.username; 
            password = User.password;
            isActive = User.isActive;
            PersonInfo = clsPerson.Find(this.PersonID); 
            _Mode = enMode.Update;
        }

        public static clsUser Find_ByPersonID(int PersonID)
        {
            stUser User = new stUser();
            if (UserData.getUserInfo_ByPersonID(PersonID, ref User))
                return new clsUser(User);
            else return null;
        }

        public static string Username(int userID)
        {
            return UserData.getUsername(userID);
        }
        public static clsUser Find(int UserID)
        {
            stUser User = new stUser();
            if (UserData.getUserInfo_ByID(UserID, ref User))
                return new clsUser(User);
            else return null;
        }

        public static clsUser Find(string username)
        {
            stUser User = new stUser();
            if (UserData.getUserInfo(username, ref User))
                return new clsUser(User);
            else return null;
        }

        public bool _AddNew()
        {
            stUser User = new stUser
            {
                PersonID = this.PersonID,
                username = this.username,
                password = this.password,
                isActive = this.isActive,
            };
           
            this.ID = UserData.Add(User);
            return this.ID != -1;
        }

        public bool _Update()
        {
            stUser User = new stUser
            {
                ID = this.ID,
                PersonID=this.PersonID,
                username = this.username,
                password = this.password,
                isActive=this.isActive,
            };

            return UserData.Update(User);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddNew())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static bool Delete(int ID)
        {
            return UserData.Delete(ID);
        }


        public static bool isExist(int ID)
        {
            return UserData.isExist(ID);
        }
        public static bool isExist(string username)
        {
            return UserData.isExist(username);
        }
        public static bool isExist(string username,string password)
        {
            return UserData.isExist(username, password);
        }
        public static bool isExist_ByPersonID(int personid)
        {
            return UserData.isExist_ByPersonID(personid);
        }

        public static DataTable UsersList()
        {
            return UserData.List();
        }
        public static DataTable ActiveUsersList()
        {
            return UserData.ActiveUsersList();
        }
        public static DataTable NonActiveUsersList()
        {
            return UserData.NonActiveUsersList();
        }
        public static bool Authintication(string username, string password)
        {
            return DataSettings.Authintication(username, password); 
        }

        public static bool SaveLogin(clsUser user)
        {
            return DataSettings.SaveLoginRecord(user.ID);
        }

    }
}
