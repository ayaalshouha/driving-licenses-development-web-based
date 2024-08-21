using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class User
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        public int PersonID { get; set; }
        public User(int id, string username, string password, bool isActive, int personId)
        {
            this.ID = id;
            this.username = username;
            this.password = password;
            this.isActive = isActive;
            this.PersonID = personId;
        }
    }
    public class UserSummery
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string fullName { get; set; }
        public string username { get; set; }

        public bool isActive { get; set; }

        public UserSummery(int id, int personid, string fullname, string username, bool isactive)
        {
            this.ID = id;
            this.PersonID = personid;
            this.fullName = fullname;
            this.username = username;
            this.isActive = isactive;
        }
    }
}
