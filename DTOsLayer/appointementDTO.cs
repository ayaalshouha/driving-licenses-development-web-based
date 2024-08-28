using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class Appointement_
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }

        public Appointement_(int id, DateOnly date, decimal fees, bool islocked)
        {
            this.Date= date;
            this.ID = id;
            this.PaidFees= fees;
            this.isLocked = islocked;
        }

    }
    public class Appointment_Veiw : Appointement_
    {
        public int TestType { get; set; }
        public int LocalLicenseApplicationID { get; set; }

        public Appointment_Veiw(int testtype,int locallicenseid, int id, DateOnly date, decimal fees, bool islocked)
            : base(id, date, fees, islocked)
        {
            this.TestType = testtype;
            this.LocalLicenseApplicationID = locallicenseid;
            this.isLocked = islocked;
            this.ID = id;
            this.PaidFees= fees;
            this.Date= date;
        }

    }
    public class Appointment : Appointment_Veiw
    {
        public int CreatedByUserID { get; set; }
        public int RetakeTestID { get; set; }

        public Appointment(int createdby, int retaketestid, int testtype, int locallicenseid, int id, DateOnly date, decimal fees, bool islocked) 
            : base(testtype, locallicenseid, id, date, fees, islocked)
        {
            this.RetakeTestID = retaketestid;
            this.CreatedByUserID = createdby;
            this.ID = id; 
            this.PaidFees= fees;
            this.Date= date;
            this.isLocked = islocked;
            this.TestType= testtype;
            this.LocalLicenseApplicationID= locallicenseid;
        }
    }

    
}
