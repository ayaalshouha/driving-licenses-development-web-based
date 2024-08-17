using DVLD_Data;
using System.Data;

namespace DVLD_Buissness
{
    public class clsApplicationTypes
    {
        private enum enMode { add = 1, update };
        private enMode _Mode = enMode.add;
        public int ID { get; set; }
        public string TypeTitle { get; set; }
        public decimal Fees { get; set; }

        public clsApplicationTypes()
        {
            this.ID = -1; 
            this.TypeTitle = string.Empty;
            this.Fees = -1;
            _Mode = enMode.add;
        }

        private clsApplicationTypes(Types type)
        {
            this.ID = type.ID;
            this.TypeTitle = type.TypeTitle; 
            this.Fees = type.Fees;
            _Mode = enMode.update;
        }

        public static clsApplicationTypes Find(int TypeID)
        {
            Types type = new Types();

            if(ApplicationTypesData.getApplicationTypeInfo(TypeID, ref type))
            {
                return new clsApplicationTypes(type);
            }
            else
            {
                return null;
            }
        }
        public static DataTable getAllTypes()
        {
            return ApplicationTypesData.getAllApplicationTypes();
        }
        private bool _Update()
        {
            Types type = new Types
            {
                ID = this.ID,
                TypeTitle = this.TypeTitle,
                Fees = this.Fees
            };

            return ApplicationTypesData.Update(type);
        }

        public bool Save()
        {
            if(this._Mode == enMode.update)
            {
                return _Update();
            }
            return false; 
        }

        public static decimal Fee(int TypeID)
        {
            return ApplicationTypesData.GetFee(TypeID);
        }

    }
}
