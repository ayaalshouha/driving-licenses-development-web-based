using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class Appointment
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public int TestType { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }
        public int CreatedByUserID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public int RetakeTestID { get; set; }

        public Appointment(int id, DateOnly date, int testtype, decimal paidfees, bool islocked, int createdby, int locallicenseid, int retaketestid)
        {
            this.isLocked = islocked;
            this.ID = id;
            this.Date = date;
            this.TestType = testtype;
            this.RetakeTestID = retaketestid;
            this.CreatedByUserID = createdby;
            this.PaidFees = paidfees;
            this.LocalLicenseApplicationID = locallicenseid;
        }
    }

    public class Appointment_Veiw
    {
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public int TestType { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public int RetakeTestID { get; set; }

        public Appointment_Veiw(int id, DateOnly date, int testtype,
            decimal paidfees, bool islocked, int locallicenseid)
        {
            this.isLocked = islocked;
            this.ID = id;
            this.Date = date;
            this.TestType = testtype;
            this.PaidFees = paidfees;
            this.LocalLicenseApplicationID = locallicenseid;
        }

    }
}
