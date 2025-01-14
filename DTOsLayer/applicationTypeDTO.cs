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
        public ApplicationType(int id, string typeTitle, decimal typeFee) {
            this.ID = id;
            this.TypeTitle = typeTitle;
            this.TypeFee = typeFee;
        }
    }
}
