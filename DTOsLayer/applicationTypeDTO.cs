using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class ApplicationType
    {
        public int ID {  get; set; }
        public string TypeTitle { get; set; }
        public decimal TypeFee { get; set; }
        public ApplicationType(int id, string title , decimal fee) {
            this.ID = id;
            this.TypeTitle = title;
            this.TypeFee = fee;
        }
    }
}
