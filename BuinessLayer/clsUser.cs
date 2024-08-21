using DataLayer;
using System.Data;
using DTOsLayer;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BuisnessLayer
{
    public class clsUser
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public enMode _Mode { get; set; }
        public User UserDTO
        {
            get
            {
                return new User(this.ID, this.username, this.password, this.isActive, this.PersonID);
            }
        }
        public UserSummery User
        {
            get
            {
                return new UserSummery(this.ID, this.PersonID, this.PersonInfo.FullName(), this.username, this.isActive); 
            }
        }
        public clsUser()
        {
            ID = -1;
            PersonID = -1; 
            username = "";
            password = "";
            isActive = false; 
            PersonInfo = null;
            _Mode = enMode.add;
        }
        private clsUser(User User)
        {
            ID = User.ID;
            PersonID = User.PersonID; 
            username = User.username; 
            password = User.password;
            isActive = User.isActive;
            PersonInfo = clsPerson.Find(this.PersonID); 
            _Mode = enMode.update;
        }
        public static clsUser Find_ByPersonID(int PersonID)
        {
            User user = UserData.getUserInfo_ByPersonID(PersonID); 
            if (user != null)
                return new clsUser(user);
            else return null;
        }
        public static string Username(int userID)
        {
            return UserData.getUsername(userID);
        }
        public static clsUser Find(int UserID)
        {
            User user = UserData.getUserInfo_ByID(UserID);
            if (user != null)
                return new clsUser(user);
            else return null;
        }
        public static User FindUserDTO(int UserID)
        {
            return UserData.getUserInfo_ByID(UserID);
        }
        public static clsUser Find(string username)
        {
            User user = UserData.getUserInfo(username);
            if (user != null)
                return new clsUser(user);
            else return null;
        }
        public bool _AddNew()
        {
            this.ID = UserData.Add(UserDTO);
            return this.ID != -1;
        }
        public bool _Update()
        {
            return UserData.Update(UserDTO);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (_AddNew())
                    {
                        this._Mode = enMode.update;
                        return true;
                    }
                    break;
                case enMode.update:
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
        public static List<UserSummery> UsersList()
        {
            return UserData.List();
        }
        public static List<User> ActiveUsersList()
        {
            return UserData.ActiveUsersList();
        }
        public static List<User> NonActiveUsersList()
        {
            return UserData.NonActiveUsersList();
        }
        public static bool Authintication(string username, string password)
        {
            return DataSettings.Authintication(username, password); 
        }
        public static bool SaveLogin(User user)
        {
            return DataSettings.SaveLoginRecord(user.ID);
        }

    }
}
