using DVLD_Data;
using System.Data;

namespace DVLD_Buissness
{
    public class clsTestTypes
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public clsTestTypes.enTestType ID { get; set; }
        public string TypeTitle { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }
        public enum enMode { add = 1, update };
        public enMode _Mode { get; set; }

        public clsTestTypes()
        {
            this.ID = clsTestTypes.enTestType.VisionTest;
            this.TypeTitle = string.Empty;
            this.Fees = -1;
            this.Description = string.Empty;
            _Mode = enMode.add;
        }

        private clsTestTypes(Types type)
        {
            this.ID = (clsTestTypes.enTestType)type.ID;
            this.TypeTitle = type.TypeTitle;
            this.Fees = type.Fees;
            this.Description = type.Description;
            _Mode = enMode.update;
        }

        public static clsTestTypes Find(int TypeID)
        {
            Types type = new Types();

            if (TestTypesData.getTestTypeInfo(TypeID, ref type))
            {
                return new clsTestTypes(type);
            }
            else
            {
                return null;
            }
        }
        public static DataTable getAllTypes()
        {
            return TestTypesData.getAllTestTypes();
        }
        private bool _Update()
        {
            Types type = new Types
            {
                ID = (int)this.ID,
                TypeTitle = this.TypeTitle,
                Fees = this.Fees, 
                Description = this.Description
            };

            return TestTypesData.Update(type);
        }

        public bool Save()
        {
            if (this._Mode == enMode.update)
            {
                return _Update();
            }
            return false;
        }



    }
}
