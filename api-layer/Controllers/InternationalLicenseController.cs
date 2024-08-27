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
    public class InternationalLicenseController : Controller
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


        [HttpGet("Read", Name = "ReadInternationalLicenseByID")]
        public async Task<ActionResult<InternationalLicense>> Read(int licenseID)
        {
            if (!int.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid Application ID Number");

            clsInternational_DL license = await clsInternational_DL.FindAsync(licenseID);

            if (license == null)
                return NotFound($"International License With ID {licenseID} Not Found");

            return Ok(license.internationalLicenseDTO);
        }


        [HttpPost("Create", Name = "CreateInternationaLicense")]
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


        [HttpPut("Update", Name = "UpdateInternationaLicense")]
        public async Task<ActionResult<_Application>> Update(int licenseID, InternationalLicense newLicense)
        {
            if ( newLicense == null)
               return BadRequest("invalid object data");

            if (!Int32.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid ID");

            bool isExist = await clsInternational_DL.isE(licenseID);

            if (!isExist)
                return NotFound("Application NOT Found");

            clsApplication app = await AssignDataToApp(newApp, ApplicationID);

            if (app != null && await app.SaveAsync())
                return Ok(app.applicationDTO);
            else
                return StatusCode(500, new { message = "Error Updating Application" });
        }

    }
}
