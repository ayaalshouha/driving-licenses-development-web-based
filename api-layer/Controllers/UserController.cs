using BuisnessLayer;
using DTOsLayer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class UserController : ControllerBase
    {
        private clsUser assignDataToUser(User newUser, int ID = -1)
        {
            clsUser user;

            if (ID == -1)
                user = new clsUser();
            else
            {
                user = clsUser.Find(ID);
                if (user == null) return null;
            }

            user.username = newUser.username;
            user.password = newUser.password;
            user.PersonID = newUser.PersonID;
            user.isActive = newUser.isActive;

            return user;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<UserSummery>>> getAll()
        {
            var usersList = await clsUser.UsersListAsync();
            if (usersList.Count <= 0)
                return NotFound("No People Found");

            return Ok(usersList);
        }

        [HttpGet("getByID", Name="getByID")]
        public async Task<ActionResult<User>> GetByID(int ID)
        {
            if (!int.TryParse(ID.ToString(), out int result) || Int32.IsNegative(ID))
                return BadRequest("Invalid ID Number");

            User user = await clsUser.FindUserDTOAsync(ID);

            if (user == null)
                return NotFound($"User With ID {ID} Not Found");

            return Ok(user);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<User>> Create(User newUser)
        {
            if (newUser == null)
                return BadRequest("invalid object data");

            bool personFound = clsPerson.isExist(newUser.PersonID);
            if (!personFound)
                return BadRequest("Person with ID {newUser.PersonID} NOT found, You have to add person details first!");

            clsUser user = assignDataToUser(newUser);

            if (await user.SaveAsync())
                return CreatedAtRoute("getByID", new { user.ID }, newUser);
            else
                return StatusCode(500, new { message = "Error Creating User" });
        }

        [HttpPut("Update")]
        public async Task<ActionResult<User>> Update(int ID, User newUser)
        {
            if (newUser == null)
                return BadRequest("invalid object data");

            clsUser user = assignDataToUser(newUser, ID);

            if (user != null && await user.SaveAsync())
                return Ok(user.UserDTO);
            else
                return StatusCode(500, new { message = "Error Updating User" });
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int ID)
        {
            if (!Int32.TryParse(ID.ToString(), out int result) || Int32.IsNegative(ID))
                return BadRequest("Invalid ID");

            bool isExist = await clsUser.isExistAsync(ID); 

            if (!isExist)
                return NotFound($"User with ID {ID} NOT Found");

            bool isDeleted = await clsUser.DeleteAsync(ID); 
            if (isDeleted)
                return Ok("User with ID {ID} Deletted Successfully");
            else
                return StatusCode(500, new { Message = "Error Deletting Person" });
        }

        [HttpGet("isExistByID")]
        public async Task<ActionResult<bool>> isExist(int ID)
        {
            if (ID < 0)
                return BadRequest("Invalid ID");

            return await clsUser.isExistAsync(ID);
        }

        [HttpGet("isExistByNationalNo")]
        public async Task<ActionResult<bool>> isExist(string NationalNumber)
        {
            if (string.IsNullOrEmpty(NationalNumber))
                return BadRequest("Invalid National Number");

            return await clsUser.isExistAsync(NationalNumber);
        }
    }
}

