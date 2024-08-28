using DataLayer;
using System.Data;
using DTOsLayer;
using Azure.Core;

namespace BuisnessLayer
{
    public class clsApplicationTypes
    {
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

        public ApplicationType AppTypeDTO
        {
            get
            {
                return new ApplicationType(this.ID, this.TypeTitle, this.Fees); 
            }
        }
        private clsApplicationTypes(ApplicationType type)
        {
            this.ID = type.ID;
            this.TypeTitle = type.TypeTitle; 
            this.Fees = type.TypeFee;
            _Mode = enMode.update;
        }

        public static async Task<clsApplicationTypes> FindAsync(int TypeID)
        {
            ApplicationType type = await ApplicationTypesData.getApplicationTypeInfoAsync(TypeID);

            if(type != null)
                return new clsApplicationTypes(type);
            else
                return null;
        }
        public static async Task<IEnumerable<ApplicationType>> getAllTypesAsync()
        {
            return await ApplicationTypesData.getAllApplicationTypesAsync();
        }
        public async Task<bool> _AddNewAsync()
        {
            this.ID = await ApplicationTypesData.AddAsync(AppTypeDTO);
            return this.ID != -1;
        }
        private async Task<bool> _UpdateAsync()
        {
            return await ApplicationTypesData.UpdateAsync(AppTypeDTO);
        }

        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (await _AddNewAsync())
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
        public static async Task<decimal> FeeAsync(enApplicationType TypeID)
        {
            return await ApplicationTypesData.GetFeeAsync((int)TypeID);
        }
        public static async Task<bool> isExistAsync(enApplicationType id)
        {
            return await ApplicationTypesData.isExistAsync((int)id);
        }
        public static async Task<bool> DeleteAsync(int id)
        {
            return await ApplicationTypesData.DeleteAsync(id);
        }
    }
}
