using BuisnessLayer;
using DTOsLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ApplicationController : Controller
    {
        private async Task<clsApplication> assignDataToApp(_Application newApp, int ID = -1)
        {
            clsApplication application; 

            if (ID == -1)
                application = new clsApplication();
            else
            {
                application = await clsApplication.FindAsync(ID);
                if (application == null) return null;
            }

            application.Date = newApp.Date;
            application.TypeID = newApp.Type;
            application.PersonID = newApp.PersonID;
            application.Status = newApp.Status;
            application.lastStatusDate = newApp.lastStatusDate;
            application.CreatedByUserID = newApp.CreatedByUserID;
            application.PaidFees = newApp.PaidFees;

            return application;
        }
     
        [HttpGet("getByID", Name = "getByID")]
        public async Task<ActionResult<_Application>> GetByID(int ApplicationID)
        {
            if (!int.TryParse(ApplicationID.ToString(), out int result) || Int32.IsNegative(ApplicationID)
                return BadRequest("Invalid Application ID Number");

            _Application app = await clsApplication.FindDTOAsync(ApplicationID);

            if (app == null)
                return NotFound($"Application With ID {ApplicationID} Not Found");

            return Ok(app);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<_Application>> Create(_Application newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            bool personFound = clsPerson.isExist(newApp.PersonID);
            if (!personFound)
                return BadRequest("Person with ID {newApp.PersonID} NOT found, You have to add person details first!");

            clsApplication app = await assignDataToApp(newApp);

            if (await app.SaveAsync())
                return CreatedAtRoute("getByID", new { app.ID }, newApp);
            else
                return StatusCode(500, new { message = "Error Creating Application" });
        }

        [HttpPut("Update")]
        public async Task<ActionResult<User>> Update(int ApplicationID, _Application newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(ApplicationID.ToString(), out int result) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplication.isExistAsync(ApplicationID);
            
            if (!isExist)
                return NotFound("Application NOT Found");

            clsApplication app = await assignDataToApp(newApp, ApplicationID);

            if (app != null && await app.SaveAsync())
                return Ok(app.applicationDTO);
            else
                return StatusCode(500, new { message = "Error Updating Application" });
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out int result) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplication.isExistAsync(ApplicationID);

            if (isExist)
            {
                bool isDeleted = await clsApplication.DeleteAsync(ApplicationID);
                if (isDeleted)
                    return Ok("User with ID {ID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Person" });
            }
            else
                return NotFound("Application Not Found");
        }

        [HttpGet("isClassExist")]
        public async Task<ActionResult<bool>> isClassExist(int PersonID, int ClassID)
        {
            if (!Int32.TryParse(PersonID.ToString(), out int result) || Int32.IsNegative(PersonID))
                return BadRequest("Invalid Person ID");

            if (!Int32.TryParse(ClassID.ToString(), out int result1) || Int32.IsNegative(ClassID))
                return BadRequest("Invalid License Class ID");

            return Ok(clsApplication.isClassExistAsync(PersonID, ClassID));
        }

        [HttpGet("SetCompleted")]
        public async Task<ActionResult<bool>> SetCompleted(int ApplicationID)
        {
            clsApplication app = await clsApplication.FindAsync(ApplicationID);
            if (app == null)
                return NotFound("Application Not Founs");
            else
                return Ok(app.setCompletedAsync());
        }

        [HttpGet("Cancel")]
        public async Task<ActionResult<bool>> Cancel(int ApplicationID)
        {
            bool isExist = await clsApplication.isExistAsync(ApplicationID);
            if (isExist)
                return Ok(clsApplication.CancelAsync(ApplicationID));
            else
                return NotFound("Application Not Found"); 
        }

        [HttpGet("getPaidFees")]
        public async Task<ActionResult<int>> GetPaidFees(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out int result) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            clsApplication app = await clsApplication.FindAsync(ApplicationID);
            if (app == null)
                return NotFound("Application Not Found");
            else
                return Ok(app.FeesAsync()); 
        }
    }
}
