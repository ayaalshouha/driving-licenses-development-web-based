using Microsoft.AspNetCore.Mvc;
using BuisnessLayer;
using DTOsLayer;
using static System.Net.Mime.MediaTypeNames;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ApplicationController : Controller
    {
        private static async Task<clsApplication> AssignDataToApp(_Application newApp, int ID = -1)
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
     
        [HttpGet("Read", Name = "ReadApplicationByID")]
        public async Task<ActionResult<_Application>> Read(int ApplicationID)
        {
            if (!int.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid Application ID Number");

            _Application app = await clsApplication.FindDTOAsync(ApplicationID);

            if (app == null)
                return NotFound($"Application With ID {ApplicationID} Not Found");

            return Ok(app);
        }

        [HttpPost("Create", Name = "CreateApplication")]
        public async Task<ActionResult<_Application>> Create(_Application newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            bool personFound = await clsPerson.isExistAsync(newApp.PersonID);
            if (!personFound)
                return BadRequest($"Person with ID {newApp.PersonID} NOT found, You have to add person details first!");

            clsApplication app = await AssignDataToApp(newApp);

            if (await app.SaveAsync())
                return CreatedAtRoute("ReadApplicationByID", new { app.ID }, app.applicationDTO);
            else
                return StatusCode(500, new { message = "Error Creating Application" });
        }

        [HttpPut("Update", Name = "UpdateApplication")]
        public async Task<ActionResult<_Application>> Update(int ApplicationID, _Application newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplication.isExistAsync(ApplicationID);
            
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

        [HttpGet("isClassExist", Name = "IsClassExist")]
        public async Task<ActionResult<bool>> isClassExist(int PersonID, int ClassID)
        {
            if (!Int32.TryParse(PersonID.ToString(), out _) || Int32.IsNegative(PersonID))
                return BadRequest("Invalid Person ID");

            if (!Int32.TryParse(ClassID.ToString(), out _) || Int32.IsNegative(ClassID))
                return BadRequest("Invalid License Class ID");

            return Ok(await clsApplication.isClassExistAsync(PersonID, ClassID));
        }

        [HttpGet("SetCompleted", Name = "CompleteApplication")]
        public async Task<ActionResult<bool>> SetCompleted(int ApplicationID)
        {
            clsApplication app = await clsApplication.FindAsync(ApplicationID);
            if (app == null)
                return NotFound("Application Not Founs");
            else
                return Ok(app.setCompletedAsync());
        }

        [HttpGet("Cancel", Name = "CancelApplciation")]
        public async Task<ActionResult<bool>> Cancel(int ApplicationID)
        {
            bool isExist = await clsApplication.isExistAsync(ApplicationID);
            if (isExist)
                return Ok(clsApplication.CancelAsync(ApplicationID));
            else
                return NotFound("Application Not Found"); 
        }

        [HttpGet("getPaidFees", Name = "GetApplicationPaidFees")]
        public async Task<ActionResult<decimal>> GetPaidFees(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            clsApplication app = await clsApplication.FindAsync(ApplicationID);
            if (app == null)
                return NotFound("Application Not Found");
            else
            {
                decimal fee = await app.FeesAsync();
                return Ok(fee); 
            }
        }
   
    }
}
