using System;
using System.Collections.Generic;
using DTOsLayer;
using DataLayer;
using System.Text.RegularExpressions;

namespace BuisnessLayer
{
    public class clsPerson
    {
        public enMode _Mode { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        public string PersonalPicture { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public int UpdateByUserID { get; set; }
        public DateTime UpdateDate { get; set; }
        public Person full_person
        {
            get
            {
                return new Person(this.ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.NationalNumber, this.Address, this.Email, this.PhoneNumber,
                this.BirthDate, this.PersonalPicture, this.Nationality, this.Gender,
                this.CreatedByUserID, this.CreationDate, this.UpdateByUserID, this.UpdateDate);
            }
        }
        public Person_View person_view_DTO
        {
            get
            {
                return new Person_View(this.ID, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                this.NationalNumber, this.Email, this.PhoneNumber,
                this.BirthDate, this.Nationality, this.Gender);
            }
        }
        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }
        public clsPerson()
        {
            ID = 0;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            NationalNumber = "";
            Address = "";
            Email = "";
            PhoneNumber = "";
            BirthDate = DateOnly.MinValue;
            CreationDate = DateTime.MinValue;
            UpdateDate = DateTime.MinValue;
            PersonalPicture = "";
            Nationality = "";
            Gender = "";
            UpdateByUserID = 0;
            CreatedByUserID = 0;

            _Mode = enMode.add;
        }
        private clsPerson(Person person)
        {
            ID = person.ID;
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            ThirdName = person.ThirdName;
            LastName = person.LastName;
            NationalNumber = person.NationalNumber;
            Address = person.Address;
            Email = person.Email;
            PhoneNumber = person.PhoneNumber;
            BirthDate = person.BirthDate;
            PersonalPicture = person.PersonalPicture;
            Nationality = person.Nationality;
            Gender = person.Gender;
            CreationDate = person.CreationDate;
            UpdateByUserID = person.UpdatedByUserID;
            CreatedByUserID = person.CreatedByUserID;
            UpdateDate = person.UpdatedDate;
            _Mode = enMode.update;
        }
        public static async Task<clsPerson> FindAsync(int ID)
        {
            Person person = await PersonData.getPersonInfoAsync(ID);
            if (person != null)
                return new clsPerson(person);
            else return null;
        }
        public static async Task<Person> FindPersonDTOAsync(int ID)
        {
            return await PersonData.getPersonInfoAsync(ID);
        }
        public static async Task<clsPerson> FindAsync(string NationalNumber)
        {
            Person person = await PersonData.getPersonInfoAsync(NationalNumber);
            if (person != null)
                return new clsPerson(person);
            else return null;
        }
        private async Task<bool> _AddNewAsync()
        {
            this.ID = await PersonData.AddAsync(full_person);
            return this.ID > 0;
        }
        private async Task<bool> _UpdateAsync()
        {
            return await PersonData.UpdateAsync(full_person);
        }

        public bool ValidateEmail(string email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        private bool IsValidAsync()
        {
            if (string.IsNullOrEmpty(this.FirstName) ||
                string.IsNullOrEmpty(this.SecondName) ||
                string.IsNullOrEmpty(this.ThirdName) ||
                string.IsNullOrEmpty(this.LastName) ||
                string.IsNullOrEmpty(this.NationalNumber) ||
                string.IsNullOrEmpty(this.Address) ||
                string.IsNullOrEmpty(this.PersonalPicture) ||
                string.IsNullOrEmpty(this.Nationality) ||
                string.IsNullOrEmpty(this.Gender))
            {
                return false;
            }

            if (this.BirthDate == DateOnly.MinValue)
                return false;

            if (!ValidateEmail(this.Email))
                return false;

            return true;
        }
        public async Task<bool> SaveAsync()
        {
            if (IsValidAsync())
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
            }
            
            return false;
        }
        public static async Task<bool> DeleteAsync(int ID)
        {
            if (await UserData.isExist_ByPersonIDAsync(ID) || await DriverData.isExist_ByPersonIDAsync(ID))
                return false;
            
            return await PersonData.DeleteAsync(ID);
        }
        public static async Task<bool> DeleteAsync(string NationalNumber)
        {
            return await PersonData.DeleteAsync(NationalNumber);
        }
        public static async Task<bool> isExistAsync(int ID)
        {
            return await PersonData.isExistAsync(ID);
        }
        public static async Task<bool> isExistAsync(string NationalNumber)
        {
            return await PersonData.isExistAsync(NationalNumber);
        }
        public static async Task<IEnumerable<Person_View>> ListAsync()
        {
            return await PersonData.ListAsync();
        }

    }
}
