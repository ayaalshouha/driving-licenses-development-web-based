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
    public class InternationalLicenseController : Controller
    {
        private static clsInternational_DL AssignDataToApp(InternationalLicense newLicenses, int ID = -1)
        {
            clsInternational_DL license;

            if (ID == -1)
                license = new clsInternational_DL();
            else
            {
                license = clsInternational_DL.FindAsync(ID).GetAwaiter().GetResult();
                if (license == null) return null;
            }

            license.ApplicationID = newLicenses.ApplicationID;
            license.IssuedByLocalLicenseID = newLicenses.IssuedByLocalLicenseID;
            license.isActive = newLicenses.isActive;
            license.IssueDate = newLicenses.IssueDate;
            license.ExpDate = newLicenses.ExpDate;
            license.CreatedByUserID = newLicenses.CreatedByUserID;
            license.DriverID = newLicenses.DriverID;

            return license;
        }

    }
}
