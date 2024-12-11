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
    public class driverController : Controller
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

        [HttpGet("drivers", Name = "AllDrivers")]
        public async Task<ActionResult<IEnumerable<Driver_View>>> getAll()
        {
            var driversList = await clsDrviers.ListAsync();
            if (driversList.Count() <= 0)
                return NotFound("No Drivers Found");

            return Ok(driversList);
        }

        [HttpGet("{id}", Name = "ReadDriverByID")]
        public async Task<ActionResult<Driver>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid LicenseID ID Number");

            var driver = await clsDrviers.FindAsync(id);

            if (driver == null)
                return NotFound($"Driver With ID {id} Not Found");

            return Ok(driver.DriverDTO);
        }

        [HttpPost("", Name ="CreateDriver")]
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

        [HttpPut("{id}", Name ="UpdateDriver")]
        public async Task<ActionResult<Driver>> Update(int id,Driver newDriver)
        {
            if (newDriver == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsDrviers.isExistAsync(id);

            if (!isExist)
                return NotFound("Driver NOT Found");

            clsDrviers driver = AssignDataToDriver(newDriver, id);

            if (driver != null && await driver.SaveAsync())
                return Ok(driver.DriverDTO);
            else
                return StatusCode(500, new { message = "Error Updating Driver" });
        }

        [HttpDelete("{id}", Name = "DeleteDriver")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsDrviers.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsDrviers.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"Driver with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Driver" });
            }
            else
                return NotFound("Driver Not Found");
        }

        [HttpGet("local-active-licenses/{id}", Name = "DriverLocalLicenses")]
        public async Task<ActionResult<IEnumerable<ActiveLicense>>> LocalActiveLicenses(int id)
        {
            bool isExist = await clsDrviers.isExistAsync(id);

            if (isExist)
            {
                var licenseslist = await clsDrviers.getLocalLicensesAsync(id);
                if (licenseslist.Count() <= 0)
                    return NotFound("No Active Local Licenses Found");

                return Ok(licenseslist);
            }
            else
                return NotFound("Driver Not Found");
        }
        
        [HttpGet("AllInternationalActiveLicenses", Name = "DriverInternationalLicenses")]
        public async Task<ActionResult<IEnumerable<DriverInterNationalLicense>>> InternationalActiveLicenses(int DriverID)
        {
            bool isExist = await clsDrviers.isExistAsync(DriverID);

            if (isExist)
            {
                var licenseslist = await clsDrviers.getInternationalLicenses(DriverID);
                if (licenseslist.Count() <= 0)
                    return NotFound("No Active International Licenses Found");

                return Ok(licenseslist);
            }
            else
                return NotFound("Driver Not Found");
        }

    }
}
