using DataLayer;
using System.Data;
using DTOsLayer; 

namespace BuisnessLayer
{
    public class clsTestTypes
    {
        public enTestType ID { get; set; }
        public string TypeTitle { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }
        public enMode _Mode { get; set; }

        public TestType TestTypeDTO
        {
            get
            {
                return new TestType((int)this.ID, this.TypeTitle, this.Fees, this.Description);
            }
        }
        public clsTestTypes()
        {
            this.ID = enTestType.VisionTest;
            this.TypeTitle = string.Empty;
            this.Fees = -1;
            this.Description = string.Empty;
            _Mode = enMode.add;
        }

        private clsTestTypes(TestType type)
        {
            this.ID = (enTestType)type.ID;
            this.TypeTitle = type.TypeTitle;
            this.Fees = type.Fees;
            this.Description = type.Description;
            _Mode = enMode.update;
        }

        public static async Task<clsTestTypes> FindAsync(int TypeID)
        {
            TestType type = await TestTypesData.getTestTypeInfoAsync(TypeID);
            if (type != null)
                return new clsTestTypes(type);
            else
                return null;
        }
        public static async Task<IEnumerable<TestType>> getAllTypesAsync()
        {
            return await TestTypesData.getAllTestTypesAsync();
        }
        private async Task<bool> _AddAsync()
        {
            this.ID = (enTestType)await TestTypesData.AddAsync(TestTypeDTO);
            return ID > 0; 
        }
        private async Task<bool> _UpdateAsync()
        {
            return await TestTypesData.UpdateAsync(TestTypeDTO);
        }

        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (await _AddAsync())
                    {
                        this._Mode = enMode.update;
                        return true;
                    }
                    break;
                case enMode.update:
                    return await _UpdateAsync();
            }
            return false;
        }

    }
}
