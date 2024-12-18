using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class Appointement_
    {
        //to preview certain local application appointments for certain test type in frontend
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }

        public Appointement_(int ID, DateTime Date, decimal PaidFees, bool isLocked)
        {
            this.Date= Date;
            this.ID = ID;
            this.PaidFees= PaidFees;
            this.isLocked = isLocked;
        }

    }
    public class Appointment_Veiw : Appointement_
    {
        public int TestType { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public string FullName { get; set; }

        public Appointment_Veiw(int TestType, int LocalLicenseApplicationID,string FullName, int ID, DateTime Date, decimal PaidFees, bool isLocked)
            : base(ID, Date, PaidFees, isLocked)
        {
            this.TestType = TestType;
            this.FullName = FullName;
            this.LocalLicenseApplicationID = LocalLicenseApplicationID;
            this.isLocked = isLocked;
            this.ID = ID;
            this.PaidFees= PaidFees;
            this.Date = Date;
        }

    }
    public class Appointment : Appointment_Veiw
    {
        public int CreatedByUserID { get; set; }
        public int? RetakeTestID { get; set; }

        public Appointment(int CreatedByUserID, int? RetakeTestID, int TestType, int LocalLicenseApplicationID, int ID, DateTime Date, decimal PaidFees, bool isLocked) 
            : base(TestType, LocalLicenseApplicationID,"", ID, Date, PaidFees, isLocked)
        {
            this.ID = ID; 
            this.LocalLicenseApplicationID= LocalLicenseApplicationID;
            this.TestType= TestType;
            this.PaidFees= PaidFees;
            this.Date= Date;
            this.isLocked = isLocked;
            this.RetakeTestID = RetakeTestID;
            this.CreatedByUserID = CreatedByUserID;
        }
    }

    
}
