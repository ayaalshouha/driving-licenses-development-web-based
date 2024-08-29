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
    public class LicenseController : Controller
    {
        private clsLicenses AssignDataToLicense(_License newLicense, int ID = -1)
        {
            clsLicenses license;

            if (ID == -1)
                license = new clsLicenses();
            else
            {
                license = clsLicenses.FindAsync(ID).GetAwaiter().GetResult();
                if (license == null) return null;
            }

            license.ApplicationID = newLicense.ApplicationID;
            license.DriverID = newLicense.DriverID;
            license.IssueDate = newLicense.IssueDate;
            license.LicenseClass = newLicense.LicenseClass;
            license.ExpDate = newLicense.ExpDate;
            license.isActive = newLicense.isActive;
            license.IssueReason = (enIssueReason)newLicense.IssueReason;
            license.PaidFees = newLicense.PaidFees;
            license.Notes = newLicense.Notes;
            license.CreatedByUserID = newLicense.CreatedByUserID;
            return license;
        }

        [HttpGet("All", Name ="AllLicenses")]
        public async Task<ActionResult<IEnumerable<_License>>> getAll()
        {
            var licensesList = await clsLicenses.ListAsync();
            if (licensesList.Count() <= 0)
                return NotFound("No Licenses Found");

            return Ok(licensesList);
        }

        [HttpGet("Read", Name = "ReadLicenseByID")]
        public async Task<ActionResult<_License>> GetByID(int LicenseID)
        {
            if (!int.TryParse(LicenseID.ToString(), out _) || Int32.IsNegative(LicenseID))
                return BadRequest("Invalid LicenseID ID Number");

            var license = await clsLicenses.FindAsync(LicenseID);

            if (license == null)
                return NotFound($"License With ID {LicenseID} Not Found");

            return Ok(license.licenseDTO);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<_License>> Create(_License newLicense)
        {
            if (newLicense == null)
                return BadRequest("invalid object data");

            bool driverFound = await clsDrviers.isExistAsync(newLicense.DriverID);
            if (!driverFound)
                return BadRequest($"Driver with ID {newLicense.DriverID} NOT found, You have to add driver details first!");

            var license = AssignDataToLicense(newLicense);

            if (await license.SaveAsync())
                return CreatedAtRoute("ReadLicenseByID", new { license.ID }, newLicense);
            else
                return StatusCode(500, new { message = "Error Creating License" });
        }

        [HttpPut("Update")]
        public async Task<ActionResult<_License>> Update(int LicenseID, _License newLicense)
        {
            if (newLicense == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(LicenseID.ToString(), out _) || Int32.IsNegative(LicenseID))
                return BadRequest("Invalid ID");

            bool isExist = await clsLicenses.isExistAsync(LicenseID);

            if (!isExist)
                return NotFound("License NOT Found");

            clsLicenses license =  AssignDataToLicense(newLicense, LicenseID);

            if (license != null && await license.SaveAsync())
                return Ok(license.licenseDTO);
            else
                return StatusCode(500, new { message = "Error Updating License" });
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int LicenseID)
        {
            if (!Int32.TryParse(LicenseID.ToString(), out _) || Int32.IsNegative(LicenseID))
                return BadRequest("Invalid ID");

            bool isExist = await clsLicenses.isExistAsync(LicenseID);

            if (isExist)
            {
                bool isDeleted = await clsLicenses.DeleteAsync(LicenseID);
                if (isDeleted)
                    return Ok("License with ID {ID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Person" });
            }
            else
                return NotFound("License Not Found");
        }

        [HttpGet("Deactivate")]
        public async Task<ActionResult<bool>> DeactivateLicense(int licenseID)
        {
            if (!Int32.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid license ID");
                
            clsLicenses license = await clsLicenses.FindAsync(licenseID);

            if (license != null && !license.isActive)
            {
                var result = await license.DeactivateCurrentLicenseAsync();
                return Ok(result);
            }

            return NotFound("License Not Found");
        }

        [HttpGet("Activate")]
        public async Task<ActionResult<bool>> ActivateLicense(int licenseID)
        {
            if (!Int32.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid license ID");

            clsLicenses license = await clsLicenses.FindAsync(licenseID);

            if (license != null && license.isActive)
            {
                var result = await license.ActivateCurrentLicenseAsync(); 
                return Ok(result);
            }

            return NotFound("License Not Found");
        }

        [HttpGet("LostReplacement")]
        public async Task<ActionResult<_License>> LostReplacement(int licenseID, int UserID)
        {
            if (!Int32.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid License ID");

            var license = await clsLicenses.FindAsync(licenseID);
            if (license != null)
            {
                var result = license.ReplaceAsync(enIssueReason.LostReplacement, UserID);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }

        [HttpGet("DamagedReplacement")]
        public async Task<ActionResult<_License>> DamagedReplacement(int licenseID, int UserID)
        {
            if (!Int32.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid License ID");

            var license = await clsLicenses.FindAsync(licenseID);
            if (license != null)
            {
                var result = license.ReplaceAsync(enIssueReason.DamagedReplacement, UserID);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }
        [HttpGet("Detain")]
        public async Task<ActionResult<int>> Detain(int licenseID,decimal fee, int UserID)
        {
            if (!Int32.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid License ID");

            var license = await clsLicenses.FindAsync(licenseID);
            if (license != null)
            {
                var result = license.DetainAsync(fee, UserID);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }
            
        [HttpGet("Release")]
        public async Task<ActionResult<bool>> Release(int licenseID, int UserID)
        {
            if (!Int32.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid License ID");

            var license = await clsLicenses.FindAsync(licenseID);
            if (license != null)
            {
                var result = license.ReleaseLicenseAsync(UserID);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }
        [HttpGet("isDetained")]
        public async Task<ActionResult<bool>> isDetained(int licenseID)
        {
            if (!Int32.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid License ID");

            var found = await clsLicenses.isExistAsync(licenseID);
            if (found)
            {
                bool result = await clsDetainedLicenses.isLicenseDetainedAsync(licenseID);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }
    }
}
