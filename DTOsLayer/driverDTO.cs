using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class Driver
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public DateOnly CreationDate { get; set; }
        public int CreatedByUserID { get; set; }
        public Driver(int id, int personId, DateOnly creationDate, int createdByUserId)
        {
            this.ID = id;
            this.PersonID = personId;
            this.CreationDate = creationDate;
            this.CreatedByUserID = createdByUserId;
        }
    }
    public class ActiveLicense
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public string Class { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public bool isActive { get; set; }
        public ActiveLicense(int id, int appid, string clss, DateOnly issue, DateOnly exp, bool isactive)
        {
            this.isActive = isactive;
            this.ApplicationID = appid;
            this.Class = clss;
            this.IssueDate = issue;
            this.ExpirationDate = exp;
            this.LicenseID = id;
        }
    }
    public class DriverInterNationalLicense
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public bool isActive { get; set; }
        public DriverInterNationalLicense(int id, int appid, int localid, DateOnly issue, DateOnly exp, bool isactive)
        {
            this.LicenseID = id;
            this.ApplicationID = appid;
            this.IssuedUsingLocalLicenseID = localid;
            this.IssueDate = issue;
            this.ExpirationDate = exp;
            this.isActive = isactive;
        }
    }
}
