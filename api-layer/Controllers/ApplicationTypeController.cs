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
    public class ApplicationTypeController : Controller
    {
        private static async Task<clsApplicationTypes> AssignDataToAppType(ApplicationType newApp, int ID = -1)
        {
            clsApplicationTypes application;

            if (ID == -1)
                application = new clsApplicationTypes();
            else
            {
                application = await clsApplicationTypes.FindAsync(ID);
                if (application == null) return null;
            }

            application.TypeTitle = newApp.TypeTitle;
            application.Fees = newApp.TypeFee;
            return application;
        }
        
        
        [HttpGet("Read", Name = "ReadApplicationTypeByID")]
        public async Task<ActionResult<ApplicationType>> Read(int ApplicationID)
        {
            if (!int.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid Application Type ID Number");

            clsApplicationTypes app = await clsApplicationTypes.FindAsync(ApplicationID);

            if (app == null)
                return NotFound($"Application Type With ID {ApplicationID} Not Found");

            return Ok(app.AppTypeDTO);
        }

       
        [HttpPost("Create", Name = "CreateApplicationType")]
        public async Task<ActionResult<ApplicationType>> Create(ApplicationType newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            clsApplicationTypes app = await AssignDataToAppType(newApp);

            if (await app.SaveAsync())
                return CreatedAtRoute("ReadApplicationTypeByID", new { app.ID }, newApp);
            else
                return StatusCode(500, new { message = "Error Creating Application" });
        }

        [HttpPut("Update", Name = "UpdateApplicationType")]
        public async Task<ActionResult<ApplicationType>> Update(int ApplicationID, ApplicationType newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplicationTypes.ise(ApplicationID);

            if (!isExist)
                return NotFound("Application NOT Found");

            clsApplication app = await AssignDataToApp(newApp, ApplicationID);

            if (app != null && await app.SaveAsync())
                return Ok(app.applicationDTO);
            else
                return StatusCode(500, new { message = "Error Updating Application" });
        }

        [HttpDelete("Delete", Name = "DleteApplication")]
        public async Task<ActionResult> Delete(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplication.isExistAsync(ApplicationID);

            if (isExist)
            {
                bool isDeleted = await clsApplication.DeleteAsync(ApplicationID);
                if (isDeleted)
                    return Ok($"Application with ID {ApplicationID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Application" });
            }
            else
                return NotFound("Application Not Found");
        }


    }
}
