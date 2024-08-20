using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using DTOs;
using DVLD_Buissness;

namespace api_layer.Controllers
{
    public class PersonController : ControllerBase
    {
        [HttpGet("All")]
        public ActionResult<IEnumerable<Person_View>> getAll()
        {
            var peopleList = clsPerson.PeopleList();
            if(peopleList.Count <= 0)
                return NotFound("No People Found");

            return Ok(peopleList);
        }
    }
}
