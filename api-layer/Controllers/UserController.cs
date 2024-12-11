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

    public class userController : ControllerBase
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

        [HttpGet("users", Name = "AllUsers")]
        public async Task<ActionResult<IEnumerable<UserSummery>>> getAll()
        {
            var usersList = await clsUser.UsersListAsync();
            if (usersList.Count <= 0)
                return NotFound("No People Found");

            return Ok(usersList);
        }

        [HttpGet("{id}", Name= "ReadUserByID")]
        public async Task<ActionResult<User>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID Number");

            User user = await clsUser.FindUserDTOAsync(id);

            if (user == null)
                return NotFound($"User With ID {id} Not Found");

            return Ok(user);
        }
        [HttpGet("user:{username}", Name = "ReadUserByUsername")]
        public async Task<ActionResult<User>> Read(string username)
        {
            if (string.IsNullOrEmpty(username))
                return BadRequest("Invalid username ");

            clsUser user = await clsUser.FindAsync(username);
            

            if (user == null)
                return NotFound($"User With ID {username} Not Found");

            return Ok(user.UserDTO);
        }

        [HttpPost("", Name = "CreateUser")]
        public async Task<ActionResult<User>> Create(User newUser)
        {
            if (newUser == null)
                return BadRequest("invalid object data");

            bool personFound = await clsPerson.isExistAsync(newUser.PersonID);
            if (!personFound)
                return BadRequest("Person with ID {newUser.PersonID} NOT found, You have to add person details first!");

            clsUser user = assignDataToUser(newUser);

            if (await user.SaveAsync())
                return CreatedAtRoute("ReadUserByID", new { user.ID }, newUser);
            else
                return StatusCode(500, new { message = "Error Creating User" });
        }

        [HttpPut("{id}", Name ="UpdateUser")]
        public async Task<ActionResult<User>> Update(int id, User newUser)
        {
            if (newUser == null)
                return BadRequest("invalid object data");

            clsUser user = assignDataToUser(newUser, id);

            if (user != null && await user.SaveAsync())
                return Ok(user.UserDTO);
            else
                return StatusCode(500, new { message = "Error Updating User" });
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsUser.isExistAsync(id); 

            if (!isExist)
                return NotFound($"User with ID {id} NOT Found");

            bool isDeleted = await clsUser.DeleteAsync(id); 
            if (isDeleted)
                return Ok("User with ID {ID} Deletted Successfully");
            else
                return StatusCode(500, new { Message = "Error Deletting Person" });
        }

        [HttpGet("{id}/existance", Name = "isUserExistByID")]
        public async Task<ActionResult<bool>> isExist(int id)
        {
            if (id < 0)
                return BadRequest("Invalid ID");

            return await clsUser.isExistAsync(id);
        }

        

      
    
    }
}

