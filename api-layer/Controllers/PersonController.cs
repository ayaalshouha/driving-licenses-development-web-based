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
                person = clsPerson.FindAsync(ID).GetAwaiter().GetResult();
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

        [HttpGet("All", Name = "Allpeople")]
        public async Task<ActionResult<IEnumerable<Person_View>>> getAll()
        {
            var peopleList = await clsPerson.ListAsync();
            if (peopleList.Count() <= 0)
                return NotFound("No People Found");

            return Ok(peopleList);
        }

        [HttpGet("Read", Name = "ReadPersonByID")]
        public async Task<ActionResult<Person>>Read(int ID)
        {
            if (!int.TryParse(ID.ToString(), out _) || Int32.IsNegative(ID))
                return BadRequest("Invalid ID Number"); 

            Person person = await clsPerson.FindPersonDTOAsync(ID);

            if (person == null)
                return NotFound($"Person With ID {ID} Not Found"); 

            return Ok(person);
        }

        [HttpPost("Create", Name = "CreatePerson")]
        public async Task<ActionResult<Person>> Create(Person newPerson)
        {
            if (newPerson == null)
                return BadRequest("invalid object data");

            clsPerson person = assignDataToPerson(newPerson);

            if (await person.SaveAsync())
            {
                newPerson.ID = person.ID; 
                return CreatedAtRoute("ReadPersonByID", new { person.ID }, newPerson);
            }
            else
                return StatusCode(500, new { message = "Error Creating Person" });
        }

        [HttpPut("Update", Name = "UpdatePerson")]
        public async Task<ActionResult<Person>> Update(int ID, Person newPerson)
        {
            if (newPerson == null)
                return BadRequest("invalid object data");

            clsPerson person = assignDataToPerson(newPerson, ID); 

            if (person != null && await person.SaveAsync())
                return Ok(person);
            else
                return StatusCode(500, new { message = "Error Updatting Person" });
        }

        [HttpDelete("Delete", Name = "DeletePerson")]
        public async Task<ActionResult> Delete(int ID)
        {
            if (!int.TryParse(ID.ToString(), out _) || Int32.IsNegative(ID))
                return BadRequest("Invalid ID Number");

            if (!clsPerson.isExistAsync(ID).GetAwaiter().GetResult())
                return NotFound($"Person with ID {ID} NOT Found");

            if (await clsPerson.DeleteAsync(ID))
                return Ok("Person with ID {ID} Deletted Successfully");
            else
                return StatusCode(500, new { Message = "Error Deletting Person" }); 
        }

        [HttpGet("isExistByID", Name ="isPersonExistByID")]
        public async Task<ActionResult<bool>> isExist(int ID)
        {
            if (!int.TryParse(ID.ToString(), out int result) || Int32.IsNegative(ID))
                return BadRequest("Invalid ID Number");

            return await clsPerson.isExistAsync(ID);
        }

        [HttpGet("isExistByNationalNo", Name ="isPersonExistByNationalNo")]
        public async Task<ActionResult<bool>> isExist(string NationalNumber)
        {
            if (string.IsNullOrEmpty(NationalNumber))
                return BadRequest("Invalid National Number");

            return await clsPerson.isExistAsync(NationalNumber);
        }

    }
}
