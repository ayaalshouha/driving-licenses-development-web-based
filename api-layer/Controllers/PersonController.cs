using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using DTOsLayer;
using BuisnessLayer;

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
    }
}
