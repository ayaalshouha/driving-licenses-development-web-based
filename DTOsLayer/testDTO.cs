using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class Test
    {
        public int ID { get; set; }
        public int AppointmentID { get; set; }
        public bool Result { get; set; }
        public string? Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public Test(int id, int appointmentID, bool result, string? notes, int createdByUserID)
        {
            this.ID = id;
            this.AppointmentID = appointmentID;
            this.Result = result;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;
        }

    }

}
