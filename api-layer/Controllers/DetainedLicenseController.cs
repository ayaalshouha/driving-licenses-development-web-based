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
    public class DetainedLicenseController : Controller
    {
        private clsDetainedLicenses AssignDataToDetainApp(DetainedLicense newDetain, int ID = -1)
        {
            clsDetainedLicenses detain;

            if (ID == -1)
                detain = new clsDetainedLicenses();
            else
            {
                detain = clsDetainedLicenses.FindAsync(ID).GetAwaiter().GetResult();
                if (detain == null) return null;
            }

            detain.ReleaseApplicationID = newDetain.ReleaseApplicationID;
            detain.LicenseID = newDetain.LicenseID;
            detain.ReleaseDate = newDetain.ReleaseDate;
            detain.DetainDate = newDetain.DetainDate;
            detain.FineFees = newDetain.FineFees;
            detain.isReleased = newDetain.isReleased;
            detain.CreatedByUserID = newDetain.CreatedByUserID;
            detain.ReleasedByUserID = newDetain.ReleasedByUserID;
            return detain;
        }

        [HttpGet("Read", Name = "ReadDetainByID")]
        public async Task<ActionResult<DetainedLicense>> Read(int detainID)
        {
            if (!int.TryParse(detainID.ToString(), out _) || Int32.IsNegative(detainID))
                return BadRequest("Invalid Detain ID Number");

            var detain = await clsDetainedLicenses.FindAsync(detainID);

            if (detain == null)
                return NotFound($"detain With ID {detainID} Not Found");

            return Ok(detain.DetainedLicenseDTO);
        }

        [HttpPost("Create", Name = "CreateDetain")]
        public async Task<ActionResult<DetainedLicense>> Create(DetainedLicense newDetain)
        {
            if (newDetain == null)
                return BadRequest("invalid object data");

            bool licenseFound = await clsLicenses.isExistAsync(newDetain.LicenseID);
            if (!licenseFound)
                return BadRequest($"License with ID {newDetain.LicenseID} NOT found!!");

            var detain = AssignDataToDetainApp(newDetain);

            if (await detain.SaveAsync())
                return CreatedAtRoute("ReadDetainByID", new { detain.ID }, newDetain);
            else
                return StatusCode(500, new { message = "Error Creating Detain" });
        }

        [HttpPut("Update", Name = "UpdateDetain")]
        public async Task<ActionResult<DetainedLicense>> Update(int detainID, DetainedLicense newDetain)
        {
            if (newDetain == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(detainID.ToString(), out _) || Int32.IsNegative(detainID))
                return BadRequest("Invalid ID");

            bool isExist = await clsDetainedLicenses.isExistAsync(detainID);

            if (!isExist)
                return NotFound("Detain NOT Found");

            clsDetainedLicenses detain = AssignDataToDetainApp(newDetain, detainID);

            if (detain != null && await detain.SaveAsync())
                return Ok(detain.DetainedLicenseDTO);
            else
                return StatusCode(500, new { message = "Error Updating Detain" });
        }

        [HttpDelete("Delete", Name = "DeleteDetain")]
        public async Task<ActionResult> Delete(int detainID)
        {
            if (!Int32.TryParse(detainID.ToString(), out _) || Int32.IsNegative(detainID))
                return BadRequest("Invalid ID");

            bool isExist = await clsDetainedLicenses.isExistAsync(detainID);

            if (isExist)
            {
                bool isDeleted = await clsDetainedLicenses.DeleteAsync(detainID);
                if (isDeleted)
                    return Ok($"Detain with ID {detainID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Detain" });
            }
            else
                return NotFound("Detain Not Found");
        }
    
        
    }
}
