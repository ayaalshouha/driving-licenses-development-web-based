using BuisnessLayer;
using DTOsLayer;
using Microsoft.AspNetCore.Mvc;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class DriverController : Controller
    {
        private clsDrviers AssignDataToDriver(Driver newDriver, int ID = -1)
        {
            clsDrviers driver;

            if (ID == -1)
                driver = new clsDrviers();
            else
            {
                driver = clsDrviers.FindAsync(ID).GetAwaiter().GetResult();
                if (driver == null) return null;
            }

            driver.PersonID = newDriver.PersonID;
            driver.CreationDate = newDriver.CreationDate;
            driver.CreatedByUserID = newDriver.CreatedByUserID;

            return driver;
        }

        [HttpGet("All", Name = "AllDrivers")]
        public async Task<ActionResult<IEnumerable<Driver_View>>> getAll()
        {
            var driversList = await clsDrviers.ListAsync();
            if (driversList.Count() <= 0)
                return NotFound("No Drivers Found");

            return Ok(driversList);
        }

        [HttpGet("Read", Name = "ReadDriverByID")]
        public async Task<ActionResult<Driver>> Read(int DriverID)
        {
            if (!int.TryParse(DriverID.ToString(), out _) || Int32.IsNegative(DriverID))
                return BadRequest("Invalid LicenseID ID Number");

            var driver = await clsDrviers.FindAsync(DriverID);

            if (driver == null)
                return NotFound($"Driver With ID {DriverID} Not Found");

            return Ok(driver.DriverDTO);
        }

        [HttpPost("Create", Name ="CreateDriver")]
        public async Task<ActionResult<Driver>> Create(Driver newDriver)
        {
            if (newDriver == null)
                return BadRequest("invalid object data");

            bool personFound = await clsPerson.isExistAsync(newDriver.PersonID);
            if (!personFound)
                return BadRequest($"Person with ID {newDriver.PersonID} NOT found, You have to add driver details first!");

            var driver = AssignDataToDriver(newDriver);

            if (await driver.SaveAsync())
                return CreatedAtRoute("ReadDriverByID", new { driver.ID }, newDriver);
            else
                return StatusCode(500, new { message = "Error Creating Driver" });
        }

        [HttpPut("Update", Name ="UpdateDriver")]
        public async Task<ActionResult<Driver>> Update(int DriverID, Driver newDriver)
        {
            if (newDriver == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(DriverID.ToString(), out _) || Int32.IsNegative(DriverID))
                return BadRequest("Invalid ID");

            bool isExist = await clsDrviers.isExistAsync(DriverID);

            if (!isExist)
                return NotFound("Driver NOT Found");

            clsDrviers driver = AssignDataToDriver(newDriver, DriverID);

            if (driver != null && await driver.SaveAsync())
                return Ok(driver.DriverDTO);
            else
                return StatusCode(500, new { message = "Error Updating Driver" });
        }

        [HttpDelete("Delete", Name = "DeleteDriver")]
        public async Task<ActionResult> Delete(int DriverID)
        {
            if (!Int32.TryParse(DriverID.ToString(), out _) || Int32.IsNegative(DriverID))
                return BadRequest("Invalid ID");

            bool isExist = await clsDrviers.isExistAsync(DriverID);

            if (isExist)
            {
                bool isDeleted = await clsDrviers.DeleteAsync(DriverID);
                if (isDeleted)
                    return Ok($"Driver with ID {DriverID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Driver" });
            }
            else
                return NotFound("Driver Not Found");
        }







           
    }
}
