using Microsoft.AspNetCore.Mvc;
using DTOsLayer;
using BuisnessLayer;
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
    public class localApplicationController : Controller
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

        [HttpGet("local-applications", Name = "AllLocalLicensesApplications")]
        public async Task<ActionResult<IEnumerable<LocalDLApp_View>>> getAll()
        {
            var appsList = await clsLocalDrivingLicenses.ListAsync();
            if (appsList.Count() <= 0)
                return NotFound("No Local Driving License Applications Found");

            return Ok(appsList);
        }
       
        [HttpGet("{id}", Name = "ReadLocalApplicationByID")]
        public async Task<ActionResult<LocalDLApp>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Local Driving License Application ID Number");

            clsLocalDrivingLicenses app = await clsLocalDrivingLicenses.FindAsync(id);

            if (app == null)
                return NotFound($"Local Driving License Application With ID {id} Not Found");

            return Ok(app.LocalDLAppDTO);
        }

        [HttpGet("{id}/view", Name = "ReadLocalApplicationView")]
        public async Task<ActionResult<LocalDLApp_View>> ReadView(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Local Driving License Application ID Number");

            LocalDLApp_View app = await clsLocalDrivingLicenses.LocalAppView(id);

            if (app == null)
                return NotFound($"Local Driving License Application With ID {id} Not Found");

            return Ok(app);
        }

        [HttpPost("", Name = "CreateLocalApplication")]
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


        [HttpPut("{id}", Name = "UpdateLocalApplication")]
        public async Task<ActionResult<LocalDLApp>> Update(int id, LocalDLApp newApp)
        {
            if (newApp == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsLocalDrivingLicenses.isExistAsync(id);

            if (!isExist)
                return NotFound("Application NOT Found");

            clsLocalDrivingLicenses app = AssignDataToApplication(newApp, id);

            if (app != null && await app.SaveAsync())
                return Ok(app.LocalDLAppDTO);
            else
                return StatusCode(500, new { message = "Error Updating Application" });
        }

        [HttpDelete("{id}", Name = "DleteLocalApplication")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsLocalDrivingLicenses.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsLocalDrivingLicenses.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"Application with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Application" });
            }
            else
                return NotFound("Application Not Found");
        }


        [HttpGet("{id}/does-passed-all-tests", Name = "isAllTestsPassed")]
        public async Task<ActionResult<bool>> isAllTestsPassed(int id)
        {
            clsLocalDrivingLicenses app = await clsLocalDrivingLicenses.FindAsync(id);
            if (app == null)
                return NotFound($"Local Driving License Application Not Found");

            var result = await app.isAllTestsPassed();
            return Ok(result);
        }

        [HttpGet("{id}/passed-test-count", Name = "PassedTestCount")]
        public async Task<ActionResult<int>> getPassedTestCount(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            var isExist = await clsLocalDrivingLicenses.isExistAsync(id); 

            if (!isExist)
                return NotFound("Application Not Found");
            
            int passedTest = await clsLocalDrivingLicenses.PassedTestAsync(id);
            return Ok(passedTest);
        }

        [HttpGet("{id}/is-test-passed/test-type/{testType}", Name = "isTestPassed")]
        public async Task<ActionResult<bool>> isTestPassed(int id, enTestType testType)
        {
            clsLocalDrivingLicenses app = await clsLocalDrivingLicenses.FindAsync(id);
            if (app == null)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await app.isTestPassedAsync(testType));
        }

        [HttpGet("{id}/canceled", Name = "isCancelled")]
        public async Task<ActionResult<bool>> isCancelled(int id)
        {
            var isExist = await clsLocalDrivingLicenses.isExistAsync(id);
            if(!isExist)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await clsLocalDrivingLicenses.DoesItCancelledAsync(id));
        }

        [HttpGet("{id}/completed", Name = "isCompleted")]
        public async Task<ActionResult<bool>> isCompleted(int id)
        {
            var isExist = await clsLocalDrivingLicenses.isExistAsync(id);
            if (!isExist)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await clsLocalDrivingLicenses.DoesItCompletedAsync(id));
        }

        [HttpGet("{id}/license-issued", Name = "isLicenseIssued")]
        public async Task<ActionResult<bool>> isLicenseIssued(int id)
        {
            var app = await clsLocalDrivingLicenses.FindAsync(id);
            if (app == null)
                return NotFound($"Local Driving License Application Not Found");
            var issued = await app.isLicenseIssuedAsync();

            return Ok(issued);
        }

        [HttpGet("{id}/license-id", Name = "ReadLicenseID")]
        public async Task<ActionResult<int>> ReadLicenseID(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            var app = await clsLocalDrivingLicenses.FindAsync(id);

            if (app == null)
                return NotFound("Local Driving License Application Not Found");

            int licenseID = await app.getLicenseIDAsync();
            
            if (licenseID > 0)
                return Ok(licenseID);
            else
                return NotFound("NO active license issued");
        }

        [HttpGet("{id}/last-test-per-test-type/test-type/{testId}", Name = "LastTestPerTestType")]
        public async Task<ActionResult<clsTests>> LastTestPerTestType(int id, enTestType testId)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            var app = await clsLocalDrivingLicenses.FindAsync(id);

            if (app == null)
                return NotFound("Local Driving License Application Not Found");

            var lastTest = await app.GetLastTestPerTestTypeAsync(testId);
            return Ok(lastTest);
        }

        
        [HttpGet("{id}/is-test-attended/{testId}", Name = "isTestAttended")]
        public async Task<ActionResult<bool>> isTestAttended(int id, enTestType testId)
        {
            var app = await clsLocalDrivingLicenses.FindAsync(id);
            if (app == null)
                return NotFound($"Local Driving License Application Not Found");

            return Ok(await app.DoesAttendTestTypeAsync(testId));
        }
 
        [HttpPatch("{id}/complete", Name = "CompleteLocalApplication")]
        public async Task<ActionResult<bool>> SetCompleted(int id)
        {
            var app = await clsLocalDrivingLicenses.FindAsync(id);
            if (app == null)
                return NotFound("Local Driving License Application Not Founs");
            else
            {
                bool isCompleted = await app.setCompletedAsync();
                return Ok(isCompleted);
            }
        }

        [HttpPatch("{id}/cancel", Name = "CancelLocalApplciation")]
        public async Task<ActionResult<bool>> Cancel(int id)
        {
            var app = await clsLocalDrivingLicenses.FindAsync(id);
            if (app == null)
                return NotFound("Local Driving License Application Not Founs");
            else
            {
                bool isCancelled = await app.setCancelledAsync();
                return Ok(isCancelled);
            }
        }

        [HttpGet("{id}/issue-license/notes/{notes}/user-id/{byUserId}", Name = "IssueFirstTimeLicense")]
        public async Task<ActionResult<int>> IssueFirstTimeLicense(int id, int byUserId, string notes="")
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            var app = await clsLocalDrivingLicenses.FindAsync(id);

            if (app == null)
                return NotFound("Local Driving License Application Not Found");

            int licenseID = await app.IssueLicenseForTheFirstTime(byUserId, notes);

            if (licenseID > 0)
                return Ok(licenseID);
            else
                return StatusCode(500, new { message = "Internal Server Error" });
        }

    }
}
