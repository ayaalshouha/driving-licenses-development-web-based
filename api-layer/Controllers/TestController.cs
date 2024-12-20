using BuisnessLayer;
using DTOsLayer;
using Microsoft.AspNetCore.Mvc;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class testController : Controller
    {
        private clsTests AssignDataToTest(Test newTest, int ID = -1)
        {
            clsTests test;

            if (ID == -1)
                test = new clsTests();
            else
            {
                test = clsTests.FindAsync(ID).GetAwaiter().GetResult();
                if (test == null) return null;
            }

            test.AppointmentID = newTest.AppointmentID;
            test.Result = newTest.Result;
            test.Notes = newTest.Notes;
            test.CreatedByUserID = newTest.CreatedByUserID;
            return test ;
        }

        [HttpGet("tests", Name ="getAllTests")] 
        public async Task<ActionResult<IEnumerable<Test>>> All()
        {
            var tests = await clsTests.getAllAsync();

            if (tests.Count() <= 0)
                return NotFound("No Tests Found");
            else
                return Ok(tests);
        }

        [HttpGet("{id}", Name = "ReadTestByID")]
        public async Task<ActionResult<Test>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Test ID Number");

            var test = await clsTests.FindAsync(id);

            if (test == null)
                return NotFound($"Test With ID {id} Not Found");

            return Ok(test.testDTO);
        }

        [HttpPost("", Name = "CreateTest")]
        public async Task<ActionResult<Test>> Create(Test newTest)
        {
            if (newTest == null)
                return BadRequest("invalid object data");

            bool appointmentFound = await clsAppointment.isExistAsync(newTest.AppointmentID);
            if (!appointmentFound)
                return BadRequest($"Appointment with ID {newTest.AppointmentID} NOT found, You have to add appointment details first!");

            var test = AssignDataToTest(newTest);

            if (await test.SaveAsync())
                return CreatedAtRoute("ReadTestByID", new { test.ID }, newTest);
            else
                return StatusCode(500, new { message = "Error Creating Test" });
        }

        [HttpPut("{id}", Name = "UpdateTest")]
        public async Task<ActionResult<Test>> Update(int id, Test newTest)
        {
            if (newTest == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsTests.isExistAsync(id);

            if (!isExist)
                return NotFound("Test NOT Found");

            clsTests test = AssignDataToTest(newTest, id);

            if (test != null && await test.SaveAsync())
                return Ok(test.testDTO);
            else
                return StatusCode(500, new { message = "Error Updating Test" });
        }

        [HttpDelete("{id}", Name = "DeleteTest")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsTests.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsTests.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"Test with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Test" });
            }
            else
                return NotFound("Test Not Found");
        }

        [HttpGet("test-by/test-type/{id}/{personId}/{licenseClass} ", Name = "ReadByPersonAndLicenseClass")]
        public async Task<ActionResult<Test>> FindByPersonAndLicenseClass(int personId, int licenseClass, enTestType id)
        {
             var test = await clsTests.FindTestByPersonIDAndLicenseClassAsync(personId, licenseClass, id);

            if (test == null)
                return NotFound($"Test Not Found");

            return Ok(test.testDTO);
        }



    }
}
