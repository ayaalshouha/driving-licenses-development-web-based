using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using DTOsLayer;
using BuisnessLayer;
using System.Diagnostics;
using System.Timers;
using DataLayer;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class personController : ControllerBase
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
            person.BirthDate = DateOnly.Parse(newPerson.BirthDate);
            person.PersonalPicture = newPerson.PersonalPicture;
            person.Nationality = newPerson.Nationality;
            person.Gender = newPerson.Gender;
            person.CreatedByUserID = newPerson.CreatedByUserID;
            person.CreationDate = newPerson.CreationDate;
            person.UpdateByUserID = newPerson.UpdatedByUserID;
            person.UpdateDate = newPerson.UpdatedDate;

            return person;
        }

        [HttpGet("people", Name = "Allpeople")]
        public async Task<ActionResult<IEnumerable<Person_View>>> getAll()
        {
            var peopleList = await clsPerson.ListAsync();
            if (peopleList.Count() <= 0)
                return NotFound("No People Found");

            return Ok(peopleList);
        }

        [HttpGet("{id}", Name = "ReadPersonByID")]
        public async Task<ActionResult<Person>>Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID Number"); 

            Person person = await clsPerson.FindPersonDTOAsync(id);

            if (person == null)
                return NotFound($"Person With ID {id} Not Found"); 

            return Ok(person);
        }

        [HttpPost("", Name = "CreatePerson")]
        public async Task<ActionResult<Person>> Create(Person newPerson)
        {
            if (newPerson == null)
                return BadRequest("invalid object data");

            clsPerson person = assignDataToPerson(newPerson);

            if (await person.SaveAsync())
            {
                newPerson.ID = person.ID; 
                return CreatedAtRoute("ReadPersonByID", new { person.ID }, person.full_person);
            }
            else{ 
                return StatusCode(500, new { message = "Error Creating Person" });
            }
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        public async Task<ActionResult<Person>> Update(int id, Person newPerson)
        {
            if (newPerson == null)
                return BadRequest("invalid object data");

            clsPerson person = assignDataToPerson(newPerson, id); 

            if (person != null && await person.SaveAsync())
                return Ok(person.full_person);
            else
                return StatusCode(500, new { message = "Error Updatting Person" });
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID Number");

            if (!clsPerson.isExistAsync(id).GetAwaiter().GetResult())
                return NotFound($"Person with ID {id} NOT Found");

            if (await clsPerson.DeleteAsync(id))
                return Ok("Person with ID {ID} Deletted Successfully");
            else
                return StatusCode(500, new { Message = "Error Deletting Person" }); 
        }

        [HttpGet("{id}/is-exist", Name ="isPersonExistByID")]
        public async Task<ActionResult<bool>> isExist(int id)
        {
            if (!int.TryParse(id.ToString(), out int result) || Int32.IsNegative(id))
                return BadRequest("Invalid ID Number");

            return await clsPerson.isExistAsync(id);
        }

        [HttpGet("No:{nationalNo}/is-exist", Name ="isPersonExistByNationalNo")]
        public async Task<ActionResult<bool>> isExist(string nationalNo)
        {
            if (string.IsNullOrEmpty(nationalNo))
                return BadRequest("Invalid National Number");

            return await clsPerson.isExistAsync(nationalNo);
        }

        [HttpGet("{id}/full-name", Name = "personFullName")]
        public async Task<ActionResult<string>> FullName(int id)
        {
            if (!int.TryParse(id.ToString(), out int result) || Int32.IsNegative(id))
                return BadRequest("Invalid ID Number");

            return await clsPerson.getFullName(id);
        }

    }
}
