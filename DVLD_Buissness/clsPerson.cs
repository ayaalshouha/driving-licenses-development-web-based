using System;
using System.Collections.Generic;
using System.Data;

using DVLD_Data;

namespace DVLD_Buissness
{
    public class clsPerson
    {
        private enum enMode { Add, Update };
        private enMode _Mode { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalPicture { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreationDate { get; set; }
        public int UpdateByUserID { get; set; }
        public DateTime UpdateDate { get; set; }
        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }

        public clsPerson()
        {
            ID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            NationalNumber = "";
            Address = "";
            Email = "";
            PhoneNumber = "";
            BirthDate =  DateTime.MinValue;
            CreationDate = DateTime.MinValue;
            UpdateDate = DateTime.MinValue;
            PersonalPicture = "";
            Nationality = "";
            Gender = "";
            UpdateByUserID = -1;
            CreatedByUserID = -1; 


            _Mode = enMode.Add; 
        }

        private clsPerson(stPerson person)
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
            _Mode = enMode.Update;
        }

        public static clsPerson Find(int ID)
        {
            stPerson person = new stPerson();
            if (PersonData.getPersonInfo(ID, ref person))
                return new clsPerson(person); 
            else return null;
        }

        public static clsPerson Find(string NationalNumber)
        {
            stPerson person = new stPerson();
            if (PersonData.getPersonInfo(NationalNumber, ref person))
                return new clsPerson(person);
            else return null;
        }

        private bool _AddNew()
        {
            stPerson person = new stPerson
            {
                NationalNumber = this.NationalNumber,
                Address = this.Address,
                FirstName = this.FirstName,
                LastName = this.LastName,
                ThirdName = this.ThirdName,
                SecondName = this.SecondName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                BirthDate = this.BirthDate,
                PersonalPicture = this.PersonalPicture,
                Nationality = this.Nationality,
                Gender = this.Gender,
                CreationDate = this.CreationDate,
                UpdatedByUserID = this.UpdateByUserID,
                CreatedByUserID = this.CreatedByUserID,
                UpdatedDate = this.UpdateDate
            };

            this.ID = PersonData.Add(person); 
            return this.ID != -1; 
        }

        private bool _Update()
        {
            stPerson person = new stPerson
            {
                ID = this.ID,
                NationalNumber = this.NationalNumber,
                Address = this.Address,
                FirstName = this.FirstName,
                LastName = this.LastName,
                ThirdName = this.ThirdName,
                SecondName = this.SecondName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                BirthDate = this.BirthDate,
                PersonalPicture = this.PersonalPicture,
                Nationality = this.Nationality,
                Gender = this.Gender,
                CreationDate = this.CreationDate,
                UpdatedByUserID = this.UpdateByUserID,
                CreatedByUserID = this.CreatedByUserID,
                UpdatedDate = this.UpdateDate
            };

            return PersonData.Update(person); 
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_AddNew())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update(); 
            }

            return false ;
        }

        public static bool Delete(int ID)
        {
            if(UserData.isExist_ByPersonID(ID) || DriverData.isExist_ByPersonID(ID))
            {
                return false; 
            }
            return PersonData.Delete(ID);
        }

        public static bool Delete(string NationalNumber)
        {
            return PersonData.Delete(NationalNumber); 
        }

        public static bool isExist(int ID)
        {
            return PersonData.isExist(ID);
        }
        public static bool isExist(string NationalNumber)
        {
            return PersonData.isExist(NationalNumber);
        }

        public static DataTable PeopleList()
        {
            return PersonData.List();
        }
    }
}
