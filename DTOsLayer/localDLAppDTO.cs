using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class LocalDLApp
    {
        public int ID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public LocalDLApp(int ID, int ApplicationID, int LicenseClassID)
        {
            this.ID = ID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }
    }
    public class LocalDLApp_View
    {
        public int ID { get; set; }
        public string NationalID { get; set; }
        public string Class { get; set; }
        public string FullName { get; set; }
        public DateOnly Date {  get; set; }
        public int PassedTest { get; set; }
        public string Status {  get; set; }

        public LocalDLApp_View(int id, string nationalID , string Class,string fullname, DateOnly date, int passedtest, string status)
        {
            this.ID = id;
            this.NationalID = nationalID;
            this.Class = Class;
            this.FullName = fullname;
            this.Date = date; 
            this.PassedTest = passedtest;
            this.Status = status;
        }
    }
}
