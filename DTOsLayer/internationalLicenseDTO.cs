using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class InternationalLicense
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedByLocalLicenseID { get; set; }
        public DateOnly IssueDate { get; set; }
        public DateOnly ExpDate { get; set; }
        public bool isActive { get; set; }
        public int CreatedByUserID { get; set; }

        public InternationalLicense(int id, int appid, int driverid,
            int issuedbylocalid, DateOnly issuedate, DateOnly expdate, bool isactive, int createdby)
        {
            this.ID = id;
            this.ApplicationID = appid;
            this.DriverID = driverid;
            this.IssuedByLocalLicenseID = issuedbylocalid;
            this.isActive = isactive;
            this.ExpDate = expdate;
            this.IssueDate = issuedate;
            this.CreatedByUserID = createdby;
        }
    }
}
