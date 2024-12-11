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
    public class licenseController : Controller
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

        [HttpGet("licenses", Name ="AllLicenses")]
        public async Task<ActionResult<IEnumerable<_License>>> getAll()
        {
            var licensesList = await clsLicenses.ListAsync();
            if (licensesList.Count() <= 0)
                return NotFound("No Licenses Found");

            return Ok(licensesList);
        }

        [HttpGet("{id}", Name = "ReadLicenseByID")]
        public async Task<ActionResult<_License>> GetByID(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid LicenseID ID Number");

            var license = await clsLicenses.FindAsync(id);

            if (license == null)
                return NotFound($"License With ID {id} Not Found");

            return Ok(license.licenseDTO);
        }

        [HttpPost("")]
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

        [HttpPut("{id}")]
        public async Task<ActionResult<_License>> Update(int id, _License newLicense)
        {
            if (newLicense == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsLicenses.isExistAsync(id);

            if (!isExist)
                return NotFound("License NOT Found");

            clsLicenses license =  AssignDataToLicense(newLicense, id);

            if (license != null && await license.SaveAsync())
                return Ok(license.licenseDTO);
            else
                return StatusCode(500, new { message = "Error Updating License" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsLicenses.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsLicenses.DeleteAsync(id);
                if (isDeleted)
                    return Ok("License with ID {ID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Person" });
            }
            else
                return NotFound("License Not Found");
        }

        [HttpPatch("{id}/deactivate")]
        public async Task<ActionResult<bool>> DeactivateLicense(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid license ID");
                
            clsLicenses license = await clsLicenses.FindAsync(id);

            if (license != null && !license.isActive)
            {
                var result = await license.DeactivateCurrentLicenseAsync();
                return Ok(result);
            }

            return NotFound("License Not Found");
        }

        [HttpPatch("{id}/activate")]
        public async Task<ActionResult<bool>> ActivateLicense(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid license ID");

            clsLicenses license = await clsLicenses.FindAsync(id);

            if (license != null && license.isActive)
            {
                var result = await license.ActivateCurrentLicenseAsync(); 
                return Ok(result);
            }

            return NotFound("License Not Found");
        }

        [HttpGet("{id}/lost-replacement/by-user-id/{userId}")]
        public async Task<ActionResult<_License>> LostReplacement(int id, int userId)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid License ID");

            var license = await clsLicenses.FindAsync(id);
            if (license != null)
            {
                var result = license.ReplaceAsync(enIssueReason.LostReplacement, userId);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }

        [HttpGet("{id}/damaged-replacement/by-user-id/{userId}")]
        public async Task<ActionResult<_License>> DamagedReplacement(int id, int userId)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid License ID");

            var license = await clsLicenses.FindAsync(id);
            if (license != null)
            {
                var result = license.ReplaceAsync(enIssueReason.DamagedReplacement, userId);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }
        
        [HttpPatch("{id}/detain/fees/{fee}/by-user-id/{userId}")]
        public async Task<ActionResult<int>> Detain(int id, decimal fee, int userId)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid License ID");

            var license = await clsLicenses.FindAsync(id);
            if (license != null)
            {
                var result = license.DetainAsync(fee, userId);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }
            
        [HttpPatch("{id}/release/by-user-id/{userId}")]
        public async Task<ActionResult<bool>> Release(int id, int userId)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid License ID");

            var license = await clsLicenses.FindAsync(id);
            if (license != null)
            {
                var result = license.ReleaseLicenseAsync(userId);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }
        [HttpGet("{id}/is-detained")]
        public async Task<ActionResult<bool>> isDetained(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid License ID");

            var found = await clsLicenses.isExistAsync(id);
            if (found)
            {
                bool result = await clsDetainedLicenses.isLicenseDetainedAsync(id);
                return Ok(result);
            }
            else
                return NotFound("License Not Found");
        }
    }
}
