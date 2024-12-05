using Microsoft.AspNetCore.Mvc;
using DTOsLayer;
using BuisnessLayer;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class LocalApplicationController : Controller
    {
        private clsLocalDrivingLicenses AssignDataToApplication(LocalDLApp newLocalApp, int ID = -1)
        {
            clsLocalDrivingLicenses application ;

            if (ID == -1)
                application = new clsLocalDrivingLicenses();
            else
            {
                application = clsLocalDrivingLicenses.FindAsync(ID).GetAwaiter().GetResult();
                if (application == null) return null;
            }

            application.ApplicationID = newLocalApp.ApplicationID;
            application.LicenseClassID = newLocalApp.LicenseClassID;
            return application;
        }

        [HttpGet("All", Name = "AllLocalLicensesApplications")]
        public async Task<ActionResult<IEnumerable<LocalDLApp_View>>> getAll()
        {
            var appsList = await clsLocalDrivingLicenses.ListAsync();
            if (appsList.Count() <= 0)
                return NotFound("No Local Driving License Applications Found");

            return Ok(appsList);
        }
       
        [HttpGet("Read", Name = "ReadLocalApplicationByID")]
        public async Task<ActionResult<LocalDLApp>> Read(int ApplicationID)
        {
            if (!int.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid Local Driving License Application ID Number");

            clsLocalDrivingLicenses app = await clsLocalDrivingLicenses.FindAsync(ApplicationID);

            if (app == null)
                return NotFound($"Local Driving License Application With ID {ApplicationID} Not Found");

            return Ok(app.LocalDLAppDTO);
        }


        [HttpPost("Create", Name = "CreateLocalApplication")]
        public async Task<ActionResult<LocalDLApp>> Create(LocalDLApp newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            bool applicationFound = await clsApplication.isExistAsync(newApp.ApplicationID);
            if (!applicationFound)
                return BadRequest($"Application with ID {newApp.ApplicationID} NOT found, You have to request an application first!");

            clsLocalDrivingLicenses app = AssignDataToApplication(newApp);

            if (await app.SaveAsync())
                return CreatedAtRoute("ReadLocalApplicationByID", new { app.ID }, app.LocalDLAppDTO);
            else
                return StatusCode(500, new { message = "Error Creating Local Driving License Application" });
        }


        [HttpPut("Update", Name = "UpdateLocalApplication")]
        public async Task<ActionResult<LocalDLApp>> Update(int ApplicationID, LocalDLApp newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            bool isExist = await clsLocalDrivingLicenses.isExistAsync(ApplicationID);

            if (!isExist)
                return NotFound("Application NOT Found");

            clsLocalDrivingLicenses app = AssignDataToApplication(newApp, ApplicationID);

            if (app != null && await app.SaveAsync())
                return Ok(app.LocalDLAppDTO);
            else
                return StatusCode(500, new { message = "Error Updating Application" });
        }

        [HttpDelete("Delete", Name = "DleteLocalApplication")]
        public async Task<ActionResult> Delete(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            bool isExist = await clsLocalDrivingLicenses.isExistAsync(ApplicationID);

            if (isExist)
            {
                bool isDeleted = await clsLocalDrivingLicenses.DeleteAsync(ApplicationID);
                if (isDeleted)
                    return Ok($"Application with ID {ApplicationID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Application" });
            }
            else
                return NotFound("Application Not Found");
        }


        [HttpGet("isRepeatedClass", Name = "isRepeatedClass")]
        public async Task<ActionResult<bool>> isRepeatedClass(int localAppID, int personID)
        {
            clsLocalDrivingLicenses app = await clsLocalDrivingLicenses.FindAsync(localAppID);
            if (app != null)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await app.isRepeatedClassAsync(personID));
        }

        [HttpGet("isAllTestsPassed", Name = "isAllTestsPassed")]
        public async Task<ActionResult<bool>> isAllTestsPassed(int localAppID)
        {
            clsLocalDrivingLicenses app = await clsLocalDrivingLicenses.FindAsync(localAppID);
            if (app == null)
                return NotFound($"Local Driving License Application Not Found");

            var result = await app.isAllTestsPassed();
            return Ok(result);
        }

        [HttpGet("getPassedTestCount", Name = "PassedTestCount")]
        public async Task<ActionResult<int>> getPassedTestCount(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            var isExist = await clsLocalDrivingLicenses.isExistAsync(ApplicationID); 

            if (!isExist)
                return NotFound("Application Not Found");
            
            int passedTest = await clsLocalDrivingLicenses.PassedTestAsync(ApplicationID);
            return Ok(passedTest);
        }


        [HttpGet("isTestPassed", Name = "isTestPassed")]
        public async Task<ActionResult<bool>> isTestPassed(int localAppID, enTestType TestTypeID)
        {
            clsLocalDrivingLicenses app = await clsLocalDrivingLicenses.FindAsync(localAppID);
            if (app == null)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await app.isTestPassedAsync(TestTypeID));
        }

        [HttpGet("isCancelled", Name = "isCancelled")]
        public async Task<ActionResult<bool>> isCancelled(int localAppID)
        {
            var isExist = await clsLocalDrivingLicenses.isExistAsync(localAppID);
            if(!isExist)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await clsLocalDrivingLicenses.DoesItCancelledAsync(localAppID));
        }

        [HttpGet("isCompleted", Name = "isCompleted")]
        public async Task<ActionResult<bool>> isCompleted(int localAppID)
        {
            var isExist = await clsLocalDrivingLicenses.isExistAsync(localAppID);
            if (!isExist)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await clsLocalDrivingLicenses.DoesItCompletedAsync(localAppID));
        }

        [HttpGet("isLicenseIssued", Name = "isLicenseIssued")]
        public async Task<ActionResult<bool>> isLicenseIssued(int localAppID)
        {
            var app = await clsLocalDrivingLicenses.FindAsync(localAppID);
            if (app == null)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await app.isLicenseIssuedAsync());
        }

        [HttpGet("ReadLicenseID", Name = "ReadLicenseID")]
        public async Task<ActionResult<int>> ReadLicenseID(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            var app = await clsLocalDrivingLicenses.FindAsync(ApplicationID);

            if (app == null)
                return NotFound("Local Driving License Application Not Found");

            int licenseID = await app.getLicenseIDAsync();
            
            if (licenseID > 0)
                return Ok(licenseID);
            else
                return NotFound("NO active license issued");
        }

        [HttpGet("LastTestPerTestType", Name = "LastTestPerTestType")]
        public async Task<ActionResult<clsTests>> LastTestPerTestType(int ApplicationID, enTestType TestTypeID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            var app = await clsLocalDrivingLicenses.FindAsync(ApplicationID);

            if (app == null)
                return NotFound("Local Driving License Application Not Found");

            var lastTest = await app.GetLastTestPerTestTypeAsync(TestTypeID);
            return Ok(lastTest);
        }

        [HttpGet("isTestAttended", Name = "isTestAttended")]
        public async Task<ActionResult<bool>> isTestAttended(int localAppID, enTestType TestTypeID)
        {
            var app = await clsLocalDrivingLicenses.FindAsync(localAppID);
            if (app == null)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await app.DoesAttendTestTypeAsync(TestTypeID));
        }

        [HttpGet("SetCompleted", Name = "CompleteLocalApplication")]
        public async Task<ActionResult<bool>> SetCompleted(int ApplicationID)
        {
            var app = await clsLocalDrivingLicenses.FindAsync(ApplicationID);
            if (app == null)
                return NotFound("Local Driving License Application Not Founs");
            else
                return Ok(app.setCompletedAsync());
        }

        [HttpGet("Cancel", Name = "CancelLocalApplciation")]
        public async Task<ActionResult<bool>> Cancel(int ApplicationID)
        {
            var app = await clsLocalDrivingLicenses.FindAsync(ApplicationID);
            if (app == null)
                return NotFound("Local Driving License Application Not Founs");
            else
                return Ok(app.setCancelledAsync());
        }

        [HttpGet("IssueFirstTimeLicense", Name = "IssueFirstTimeLicense")]
        public async Task<ActionResult<int>> IssueFirstTimeLicense(int ApplicationID, int CreatedByUserID, string Notes )
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            var app = await clsLocalDrivingLicenses.FindAsync(ApplicationID);

            if (app == null)
                return NotFound("Local Driving License Application Not Found");

            int licenseID = await app.IssueLicenseForTheFirstTime(CreatedByUserID, Notes);

            if (licenseID > 0)
                return Ok(licenseID);
            else
                return StatusCode(500, new { message = "Internal Server Error" });
        }

    }
}
