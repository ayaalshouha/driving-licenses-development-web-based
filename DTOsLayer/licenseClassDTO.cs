using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class LicenseClass
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }
        public byte MinAgeAllowed { get; set; }
        public byte ValidityYears { get; set; }

        public LicenseClass(int id, string classname, string desc, decimal fee, byte minageallow, byte validityyears)
        {
            this.ClassName = classname;
            this.Description = desc;
            this.ID = id;
            this.Fees = fee;
            this.MinAgeAllowed = minageallow;
            this.ValidityYears = validityyears;
        }
    }
}
