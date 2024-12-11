using Microsoft.AspNetCore.Mvc;
using BuisnessLayer;
using DTOsLayer;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class applicationController : Controller
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
     
        [HttpGet("{id}", Name = "ReadApplicationByID")]
        public async Task<ActionResult<_Application>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Application ID Number");

            _Application app = await clsApplication.FindDTOAsync(id);

            if (app == null)
                return NotFound($"Application With ID {id} Not Found");

            return Ok(app);
        }

        [HttpPost("", Name = "CreateApplication")]
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

        [HttpPut("{id}", Name = "UpdateApplication")]
        public async Task<ActionResult<_Application>> Update(int id, _Application newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplication.isExistAsync(id);
            
            if (!isExist)
                return NotFound("Application NOT Found");

            clsApplication app = await AssignDataToApp(newApp, id);

            if (app != null && await app.SaveAsync())
                return Ok(app.applicationDTO);
            else
                return StatusCode(500, new { message = "Error Updating Application" });
        }

        [HttpDelete("{id}", Name = "DleteApplication")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplication.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsApplication.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"Application with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Application" });
            }
            else
                return NotFound("Application Not Found");
        }

        //[HttpGet("isClassExist", Name = "IsClassExist")]
        //public async Task<ActionResult<bool>> isClassExist(int PersonID, int ClassID)
        //{
        //    if (!Int32.TryParse(PersonID.ToString(), out _) || Int32.IsNegative(PersonID))
        //        return BadRequest("Invalid Person ID");

        //    if (!Int32.TryParse(ClassID.ToString(), out _) || Int32.IsNegative(ClassID))
        //        return BadRequest("Invalid License Class ID");

        //    return Ok(await clsApplication.isClassExistAsync(PersonID, ClassID));
        //}

        [HttpPatch("complete/{id}", Name = "CompleteApplication")]
        public async Task<ActionResult<bool>> SetCompleted(int id)
        {
            clsApplication app = await clsApplication.FindAsync(id);
            if (app == null)
                return NotFound("Application Not Founs");
            else
                return Ok(app.setCompletedAsync());
        }

        [HttpPatch("cancel/{id}", Name = "CancelApplciation")]
        public async Task<ActionResult<bool>> Cancel(int id)
        {
            bool isExist = await clsApplication.isExistAsync(id);
            if (isExist)
                return Ok(clsApplication.CancelAsync(id));
            else
                return NotFound("Application Not Found"); 
        }

        [HttpGet("paid-fees/{id}", Name = "GetApplicationPaidFees")]
        public async Task<ActionResult<decimal>> GetPaidFees(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            clsApplication app = await clsApplication.FindAsync(id);
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
