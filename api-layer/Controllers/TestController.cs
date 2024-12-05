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
    public class TestController : Controller
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

        [HttpGet("Read", Name = "ReadTestByID")]
        public async Task<ActionResult<Test>> Read(int testID)
        {
            if (!int.TryParse(testID.ToString(), out _) || Int32.IsNegative(testID))
                return BadRequest("Invalid Test ID Number");

            var test = await clsTests.FindAsync(testID);

            if (test == null)
                return NotFound($"Test With ID {testID} Not Found");

            return Ok(test.testDTO);
        }

        [HttpPost("Create", Name = "CreateTest")]
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

        [HttpPut("Update", Name = "UpdateTest")]
        public async Task<ActionResult<Test>> Update(int TestID, Test newTest)
        {
            if (newTest == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(TestID.ToString(), out _) || Int32.IsNegative(TestID))
                return BadRequest("Invalid ID");

            bool isExist = await clsTests.isExistAsync(TestID);

            if (!isExist)
                return NotFound("Test NOT Found");

            clsTests test = AssignDataToTest(newTest, TestID);

            if (test != null && await test.SaveAsync())
                return Ok(test.testDTO);
            else
                return StatusCode(500, new { message = "Error Updating Test" });
        }

        [HttpDelete("Delete", Name = "DeleteTest")]
        public async Task<ActionResult> Delete(int TestID)
        {
            if (!Int32.TryParse(TestID.ToString(), out _) || Int32.IsNegative(TestID))
                return BadRequest("Invalid ID");

            bool isExist = await clsTests.isExistAsync(TestID);

            if (isExist)
            {
                bool isDeleted = await clsTests.DeleteAsync(TestID);
                if (isDeleted)
                    return Ok($"Test with ID {TestID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Test" });
            }
            else
                return NotFound("Test Not Found");
        }

        [HttpGet("Find", Name = "ReadByPersonAndLicenseClass")]
        public async Task<ActionResult<Test>> FindByPersonAndLicenseClass(int personID, int LicenseCLassID, enTestType TestType)
        {
             var test = await clsTests.FindTestByPersonIDAndLicenseClassAsync(personID, LicenseCLassID, TestType);

            if (test == null)
                return NotFound($"Test Not Found");

            return Ok(test.testDTO);
        }



    }
}
