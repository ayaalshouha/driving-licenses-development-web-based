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
    public class loginController : Controller
    {
        [HttpGet("{username}/{password}/is-active", Name = "isActive")]
        public ActionResult<bool> isActive(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
                return BadRequest("invalid username/password");
            }

            return clsUser.Authintication(username, password);
        }

        [HttpPost("", Name = "CreateRecord")]
        public ActionResult<bool> Create(int UserID)
        {
            if (!Int32.TryParse(UserID.ToString(), out _) || Int32.IsNegative(UserID))
                return BadRequest("Invalid UserID");

            bool isSaved = clsUser.SaveLogin(UserID); 

            if (isSaved)
                return Ok();
            else
                return StatusCode(500, new { message = "Error saving login record" });
        }

        [HttpGet("{username}/is-exist", Name = "isUserExistByUsername")]
        public async Task<ActionResult<bool>> isExist(string username)
        {
            if (string.IsNullOrEmpty(username))
                return BadRequest("Invalid username");

            return await clsUser.isExistAsync(username);
        }

        [HttpGet("{username}/{password}/is-exist", Name = "isUserExist")]
        public async Task<ActionResult<bool>> isExist(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return BadRequest("Invalid username/password");

            return await clsUser.isExistAsync(username, password);
        }
    }
}
