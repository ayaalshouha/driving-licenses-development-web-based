using BuisnessLayer;
using DTOsLayer;
using Microsoft.AspNetCore.Mvc;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public class countryController : Controller
    {
        [HttpGet("countries", Name = "GetCountries")]
        public ActionResult<IEnumerable<string>> AllTypes()
        {
            var list =  clsCountries.GetAllCountries();

            if (!list.Any())
                return NoContent();
            else
                return Ok(list);
        }
    }
}
