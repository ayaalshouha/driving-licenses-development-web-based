using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using DTOsLayer;
using BuisnessLayer;
using System.Diagnostics;
using System.Timers;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class PersonController : ControllerBase
    {
        private clsPerson assignDataToPerson(Person newPerson, int ID = -1)
        {
            clsPerson person; 

            if(ID == -1)
                 person = new clsPerson();
            else
            {
                person = clsPerson.Find(ID);
                if (person == null) return null; 
            }

            person.FirstName = newPerson.FirstName;
            person.SecondName = newPerson.SecondName;
            person.ThirdName = newPerson.ThirdName;
            person.LastName = newPerson.LastName;
            person.NationalNumber = newPerson.NationalNumber;
            person.Address = newPerson.Address;
            person.Email = newPerson.Email;
            person.PhoneNumber = newPerson.PhoneNumber;
            person.BirthDate = newPerson.BirthDate;
            person.PersonalPicture = newPerson.PersonalPicture;
            person.Nationality = newPerson.Nationality;
            person.Gender = newPerson.Gender;
            person.CreatedByUserID = newPerson.CreatedByUserID;
            person.CreationDate = newPerson.CreationDate;
            person.UpdateByUserID = newPerson.UpdatedByUserID;
            person.UpdateDate = newPerson.UpdatedDate;

            return person;
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<Person_View>> getAll()
        {
            var peopleList = clsPerson.PeopleList();
            if (peopleList.Count <= 0)
                return NotFound("No People Found");

            return Ok(peopleList);
        }

        [HttpGet("getByID/{ID}")]
        public ActionResult<Person>GetByID(int ID)
        {
            if (!int.TryParse(ID.ToString(), out int result) || ID < 0)
                return BadRequest("Invalid ID Number"); 

            Person person = clsPerson.FindPersonDTO(ID);

            if (person == null)
                return NotFound($"Person With ID {ID} Not Found"); 

            return Ok(person);
        }

        [HttpPost("Create")]
        public ActionResult<Person> Create(Person newPerson)
        {
            if (newPerson == null)
                return BadRequest("invalid object data");

            clsPerson person = assignDataToPerson(newPerson);

            if (person.Save())
                return CreatedAtRoute("getByID/{ID}", new { person.ID }, person);
            else
                return StatusCode(500, new { message = "Error Creating Person" });
        }

        [HttpPut("Update")]
        public ActionResult<Person> Update(int ID, Person newPerson)
        {
            if (newPerson == null)
                return BadRequest("invalid object data");

            clsPerson person = assignDataToPerson(newPerson, ID);

            if (person != null && person.Save())
                return Ok(person);
            else
                return StatusCode(500, new { message = "Error Creating Person" });
        }


    }
}
