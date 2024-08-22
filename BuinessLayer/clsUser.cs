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
        public static async Task<clsUser> Find_ByPersonID(int PersonID)
        {
            User user = await UserData.getUserInfo_ByPersonIDAsync(PersonID); 
            if (user != null)
            {
               // user.password = clsGeneral.Decrypt(user.password);
                return new clsUser(user);
            }
            else return null;
        }
        public static async Task<string> UsernameAsync(int userID)
        {
            return await UserData.getUsernameAsync(userID);
        }
        public static async Task<clsUser> FindAsync(int UserID)
        {
            User user = await UserData.getUserInfo_ByIDAsync(UserID);
            if (user != null)
            {
                //user.password = clsGeneral.Decrypt(user.password);
                return new clsUser(user);

            }
            else return null;
        }

        //TODO : Make this async 
        public static clsUser Find(int UserID)
        {
            User user =  UserData.getUserInfo_ByID(UserID);
            if (user != null)
            {
                //user.password = clsGeneral.Decrypt(user.password);
                return new clsUser(user);
            }
            else return null;
        }
        public static async Task<User> FindUserDTOAsync(int UserID)
        {
            User user = await UserData.getUserInfo_ByIDAsync(UserID);
            //user.password = clsGeneral.Decrypt(user.password);
            return user; 
        }
        public static async Task<clsUser> FindAsync(string username)
        {
            User user = await UserData.getUserInfoAsync(username);
            if (user != null)
            {
                //user.password = clsGeneral.Decrypt(user.password);
                return new clsUser(user);
            }
            else return null;
        }
        private async Task<bool> _AddNewAsync()
        {
            //UserDTO.password = clsGeneral.Encrypt(UserDTO.password);
            this.ID = await UserData.AddAsync(UserDTO);
            return this.ID != -1;
        }
        private async Task<bool> _UpdateAsync()
        {
            //UserDTO.password = clsGeneral.Encrypt(UserDTO.password);
            return await UserData.UpdateAsync(UserDTO);
        }
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (await _AddNewAsync())
                    {
                        this._Mode = enMode.update;
                        return true;
                    }
                    break;
                case enMode.update:
                    return await _UpdateAsync();
            }

            return false;
        }
        public static async Task<bool> DeleteAsync(int ID)
        {
            return await UserData.DeleteAsync(ID);
        }
        public static async Task<bool> isExistAsync(int ID)
        {
            return await UserData.isExistAsync(ID);
        }
        public static async Task<bool> isExistAsync(string username)
        {
            return await UserData.isExistAsync(username);
        }
        public static async Task<bool> isExistAsync(string username,string password)
        {
            //password = clsGeneral.Encrypt(password);
            return await UserData.isExistAsync(username, password);
        }
        public static async Task<bool> isExist_ByPersonIDAsync(int personid)
        {
            return await UserData.isExist_ByPersonIDAsync(personid);
        }
        public static async Task<List<UserSummery>> UsersListAsync()
        {
            return await UserData.ListAsync();
        }
        public static async Task<List<UserSummery>> ActiveUsersListAsync()
        {
            return await UserData.ActiveUsersListAsync();
        }
        public static async Task<List<UserSummery>> NonActiveUsersListAsync()
        {
            return await UserData.NonActiveUsersListAsync();
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
