using System;
using System.Collections.Generic;
using DTOsLayer;
using DataLayer;

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
        public static clsPerson Find(int ID)
        {
            Person person = PersonData.getPersonInfo(ID);
            if (person != null)
                return new clsPerson(person);
            else return null;
        }
        public static Person FindPersonDTO(int ID)
        {
            return PersonData.getPersonInfo(ID);
        }
        public static clsPerson Find(string NationalNumber)
        {
            Person person = PersonData.getPersonInfo(NationalNumber);
            if (person != null)
                return new clsPerson(person);
            else return null;
        }
        private bool _AddNew()
        {
            this.ID = PersonData.Add(full_person);
            return this.ID > 0;
        }
        private bool _Update()
        {
            return PersonData.Update(full_person);
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(this.FirstName) ||
                string.IsNullOrEmpty(this.SecondName) ||
                string.IsNullOrEmpty(this.ThirdName) ||
                string.IsNullOrEmpty(this.LastName) ||
                string.IsNullOrEmpty(this.NationalNumber) ||
                string.IsNullOrEmpty(this.Address) ||
                string.IsNullOrEmpty(this.Email) ||
                string.IsNullOrEmpty(this.PersonalPicture) ||
                string.IsNullOrEmpty(this.Nationality) ||
                string.IsNullOrEmpty(this.Gender))
            {
                return false;
            }

            if (this.BirthDate == default(DateOnly))
                return false;


            return true;
        }
        public bool Save()
        {
            if (IsValid())
            {
                switch (_Mode)
                {
                    case enMode.add:
                        if (_AddNew())
                        {
                            this._Mode = enMode.update;
                            return true;
                        }
                        break;
                    case enMode.update:
                        return _Update();
                }
            }
            
            return false;
        }
        public static bool Delete(int ID)
        {
            if (UserData.isExist_ByPersonID(ID) || DriverData.isExist_ByPersonID(ID))
                return false;
            
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
        public static List<Person_View> PeopleList()
        {
            return PersonData.List();
        }

    }
}
