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
        public ActionResult<IEnumerable<UserSummery>> getAll()
        {
            var usersList = clsUser.UsersList();
            if (usersList.Count <= 0)
                return NotFound("No People Found");

            return Ok(usersList);
        }

        [HttpGet("getByID/{ID}")]
        public ActionResult<User> GetByID(int ID)
        {
            if (!int.TryParse(ID.ToString(), out int result) || ID < 0)
                return BadRequest("Invalid ID Number");

            User user = clsUser.FindUserDTO(ID);

            if (user == null)
                return NotFound($"User With ID {ID} Not Found");

            return Ok(user);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<User>> Create(Person newperson, User newUser)
        {
            HttpClient httpClient = new HttpClient();
            var personInfo = new StringContent(JsonSerializer.Serialize(newperson), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:5226/api/Person/Create", personInfo);

            if (response.IsSuccessStatusCode)
            {
                if (newUser == null)
                    return BadRequest("invalid object data");

                clsUser user = assignDataToUser(newUser);
                user.PersonID = newperson.ID;
                if (user.Save())
                    return CreatedAtRoute("getByID/{ID}", new { user.ID }, user);
            }

            return StatusCode(500, new { message = "Error Creating User" });
        }

        //[HttpPut("Update")]
        //public ActionResult<Person> Update(int ID, Person newPerson)
        //{
        //    if (newPerson == null)
        //        return BadRequest("invalid object data");

        //    clsPerson person = assignDataToPerson(newPerson, ID);

        //    if (person != null && person.Save())
        //        return Ok(person);
        //    else
        //        return StatusCode(500, new { message = "Error Creating Person" });
        //}

        //[HttpDelete("Delete")]
        //public ActionResult Delete(int ID)
        //{
        //    if (ID < 0)
        //        return BadRequest("Invalid ID");

        //    if (clsPerson.Find(ID) == null)
        //        return NotFound($"Person with ID {ID} NOT Found");

        //    if (clsPerson.Delete(ID))
        //        return Ok("Person with ID {ID} Deletted Successfully");
        //    else
        //        return StatusCode(500, new { Message = "Error Deletting Person" });
        //}

        //[HttpGet("isExistByID")]
        //public ActionResult<bool> isExist(int ID)
        //{
        //    if (ID < 0)
        //        return BadRequest("Invalid ID");

        //    return clsPerson.isExist(ID);
        //}

        //[HttpGet("isExistByNationalNo")]
        //public ActionResult<bool> isExist(string NationalNumber)
        //{
        //    if (string.IsNullOrEmpty(NationalNumber))
        //        return BadRequest("Invalid National Number");

        //    return clsPerson.isExist(NationalNumber);
        //}
    }
}

