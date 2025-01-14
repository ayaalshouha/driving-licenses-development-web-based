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
    public class applicationTypeController : Controller
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
             
        [HttpGet("application-types", Name = "GetApplicationTypes")]
        public async Task<ActionResult<IEnumerable<ApplicationType>>> AllTypes()
        {
            var typesList = await clsApplicationTypes.getAllTypesAsync();

            if (typesList.Count()<=0)
                return NotFound("No Application Types Found");
            else
                return Ok(typesList);
        }

        [HttpGet("{id}", Name = "ReadApplicationTypeByID")]
        public async Task<ActionResult<ApplicationType>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Application Type ID Number");

            clsApplicationTypes app = await clsApplicationTypes.FindAsync(id);

            if (app == null)
                return NotFound($"Application Type With ID {id} Not Found");

            return Ok(app.AppTypeDTO);
        }
       
        [HttpPost("", Name = "CreateApplicationType")]
        public async Task<ActionResult<ApplicationType>> Create(ApplicationType newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            clsApplicationTypes app = await AssignDataToAppType(newApp);

            if (await app.SaveAsync())
                return CreatedAtRoute("ReadApplicationTypeByID", new { app.ID }, app.AppTypeDTO);
            else
                return StatusCode(500, new { message = "Error Creating Application" });
        }

        [HttpPut("{id}", Name = "UpdateApplicationType")]
        public async Task<ActionResult<ApplicationType>> Update(int id, ApplicationType newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplicationTypes.isExistAsync((enApplicationType)id);

            if (!isExist)
                return NotFound("Application Type NOT Found");

            clsApplicationTypes app = await AssignDataToAppType(newApp, id);

            if (app != null && await app.SaveAsync())
                return Ok(app.AppTypeDTO);
            else
                return StatusCode(500, new { message = "Error Updating Application Type" });
        }

        [HttpDelete("{id}", Name = "DleteApplicationType")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplicationTypes.isExistAsync((enApplicationType)id);

            if (isExist)
            {
                bool isDeleted = await clsApplicationTypes.DeleteAsync(id);
                if (isDeleted)
                    return Ok(isDeleted);

                else
                    return StatusCode(500, new { Message = "Error Deletting Application Type" });
            }
            else
                return NotFound("Application Type Not Found");
        }

        [HttpGet("{id}/application-type-fees", Name = "GetApplicationTypeFees")]
        public async Task<ActionResult<int>> GetFees(enApplicationType id)
        {

            var isExist = await clsApplicationTypes.isExistAsync(id);
            
            if (!isExist)
                return NotFound("Application Type Not Found");
            else
            {
                decimal fee = await clsApplicationTypes.FeeAsync(id); 
                return Ok(fee);
            }
        }

    }
}
