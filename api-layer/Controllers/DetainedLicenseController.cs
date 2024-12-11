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
    public class detainedLicenseController : Controller
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


        [HttpGet("detained-licenses", Name = "AllDetainedLicenses")]
        public async Task<ActionResult<IEnumerable<DetainedLicense_View>>> getAll()
        {
            var appsList = await clsDetainedLicenses.ListAsync();
            if (appsList.Count() <= 0)
                return NotFound("No Detained Licenses Found");

            return Ok(appsList);
        }


        [HttpGet("{id}", Name = "ReadDetainByID")]
        public async Task<ActionResult<DetainedLicense>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Detain ID Number");

            var detain = await clsDetainedLicenses.FindAsync(id);

            if (detain == null)
                return NotFound($"detain With ID {id} Not Found");

            return Ok(detain.DetainedLicenseDTO);
        }


        [HttpGet("by-license-id/{licenseID}", Name = "ReadDetainByLicenseID")]
        public async Task<ActionResult<DetainedLicense>> ReadByLicenseID(int licenseID)
        {
            if (!int.TryParse(licenseID.ToString(), out _) || Int32.IsNegative(licenseID))
                return BadRequest("Invalid Detain ID Number");
            var isFound = await clsLicenses.isExistAsync(licenseID);
            
            if (!isFound)
                return NotFound($"License with ID {licenseID} NOT found"); 

            var detain = await clsDetainedLicenses.FindByLicenseIDAsync(licenseID);

            if (detain == null)
                return NotFound($"detain With ID {licenseID} Not Found");

            return Ok(detain.DetainedLicenseDTO);
        }

        [HttpPost("", Name = "CreateDetain")]
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

        [HttpPut("{id}", Name = "UpdateDetain")]
        public async Task<ActionResult<DetainedLicense>> Update(int id, DetainedLicense newDetain)
        {
            if (newDetain == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsDetainedLicenses.isExistAsync(id);

            if (!isExist)
                return NotFound("Detain NOT Found");

            clsDetainedLicenses detain = AssignDataToDetainApp(newDetain, id);

            if (detain != null && await detain.SaveAsync())
                return Ok(detain.DetainedLicenseDTO);
            else
                return StatusCode(500, new { message = "Error Updating Detain" });
        }

        [HttpDelete("{id}", Name = "DeleteDetain")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsDetainedLicenses.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsDetainedLicenses.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"Detain with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Detain" });
            }
            else
                return NotFound("Detain Not Found");
        }
    
        
    }
}
