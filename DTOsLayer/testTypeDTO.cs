using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class TestType
    {
        public int ID { get; set; }
        public string TypeTitle { get; set; }
        public decimal Fees { get; set; }
        public string Description { get; set; }
        public TestType(int id, string typetitle, decimal fee, string desc)
        {
            this.Description = desc;
            this.ID = id;
            this.Fees = fee;
            this.TypeTitle = typetitle;
        }
    }
}
