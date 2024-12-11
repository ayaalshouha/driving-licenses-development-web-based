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
    public class internationalLicenseController : Controller
    {
        private static clsInternational_DL AssignDataToApp(InternationalLicense newLicenses, int ID = -1)
        {
            clsInternational_DL license;

            if (ID == -1)
                license = new clsInternational_DL();
            else
            {
                license = clsInternational_DL.FindAsync(ID).GetAwaiter().GetResult();
                if (license == null) return null;
            }

            license.ApplicationID = newLicenses.ApplicationID;
            license.IssuedByLocalLicenseID = newLicenses.IssuedByLocalLicenseID;
            license.isActive = newLicenses.isActive;
            license.IssueDate = newLicenses.IssueDate;
            license.ExpDate = newLicenses.ExpDate;
            license.CreatedByUserID = newLicenses.CreatedByUserID;
            license.DriverID = newLicenses.DriverID;

            return license;
        }

        [HttpGet("international-licenses", Name = "AllInternationalLicenses")]
        public async Task<ActionResult<IEnumerable<InternationalLicense>>> getAll()
        {
            var licensesList = await clsInternational_DL.ListAsync();
            if (licensesList.Count() <= 0)
                return NotFound("No International Licenses Found");

            return Ok(licensesList);
        }

        [HttpGet("{id}", Name = "ReadInternationalLicenseByID")]
        public async Task<ActionResult<InternationalLicense>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Application ID Number");

            clsInternational_DL license = await clsInternational_DL.FindAsync(id);

            if (license == null)
                return NotFound($"International License With ID {id} Not Found");

            return Ok(license.internationalLicenseDTO);
        }


        [HttpPost("", Name = "CreateInternationaLicense")]
        public async Task<ActionResult<_Application>> Create(InternationalLicense newLicense)
        {
            if (newLicense == null)
                return BadRequest("invalid object data");

            bool driverFound = await clsDrviers.isExistAsync(newLicense.DriverID);
            if (!driverFound)
                return BadRequest($"Driver with ID {newLicense.DriverID} NOT found, You have to add driver details first!");

            bool localAppFound = await clsLocalDrivingLicenses.isExistAsync(newLicense.IssuedByLocalLicenseID);
            if (!localAppFound)
                return BadRequest($"Local Driving License Application with ID {newLicense.IssuedByLocalLicenseID} NOT found, You have to issue a local license first!");


            clsInternational_DL app =  AssignDataToApp(newLicense);

            if (await app.SaveAsync())
                return CreatedAtRoute("ReadApplicationByID", new { app.ID }, newLicense);
            else
                return StatusCode(500, new { message = "Error Creating International License" });
        }


        [HttpPut("{id}", Name = "UpdateInternationalLicense")]
        public async Task<ActionResult<_Application>> Update(int id, InternationalLicense newLicense)
        {
            if ( newLicense == null)
               return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsInternational_DL.isExistAsync(id);

            if (!isExist)
                return NotFound("International License NOT Found");

            clsInternational_DL license =  AssignDataToApp(newLicense, id);

            if (license != null && await license.SaveAsync())
                return Ok(license.internationalLicenseDTO);
            else
                return StatusCode(500, new { message = "Error Updating International License" });
        }


        [HttpDelete("{id}", Name = "DeleteInternationaLicense")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsInternational_DL.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsInternational_DL.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"International License with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting International License" });
            }
            else
                return NotFound("Application Not Found");
        }
    
    
    }
}
