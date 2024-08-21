using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer
{
    public class Person
    {
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
        public int UpdatedByUserID { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Person(int id, string firstName, string secondName, string thirdName, string lastName,
            string nationalNumber, string address, string email, string phoneNumber, DateOnly birthDate,
            string personalPicture, string nationality, string gender, int createdByUserId, DateTime creationDate,
            int updatedByUserId, DateTime updatedDate)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNumber = nationalNumber;
            this.Address = address;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = birthDate;
            this.PersonalPicture = personalPicture;
            this.Nationality = nationality;
            this.Gender = gender;
            this.CreatedByUserID = createdByUserId;
            this.CreationDate = creationDate;
            this.UpdatedByUserID = updatedByUserId;
            this.UpdatedDate = updatedDate;
        }
    }
    public class Person_View
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string NationalNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }

        public Person_View(int id, string firstName, string secondName, string thirdName, string lastName, string nationalNumber, string email, string phoneNumber, DateOnly birthDate, string nationality, string gender)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.NationalNumber = nationalNumber;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = birthDate;
            this.Nationality = nationality;
            this.Gender = gender;
        }

    }
}
