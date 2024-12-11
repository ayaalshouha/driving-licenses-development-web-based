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
    public class licenseClassController : Controller
    {
        private static async Task<clsLicenseClasses> AssignDataToClass(LicenseClass newClass, int ID = -1)
        {
            clsLicenseClasses licenseClasse;

            if (ID == -1)
                licenseClasse = new clsLicenseClasses();
            else
            {
                licenseClasse = await clsLicenseClasses.FindAsync(ID);
                if (licenseClasse == null) return null;
            }

            licenseClasse.ClassName = newClass.ClassName;
            licenseClasse.MinimumAllowedAge = newClass.MinAgeAllowed;
            licenseClasse.DefaultValidityLength = newClass.ValidityYears;
            licenseClasse.ClassFees = newClass.Fees;
            licenseClasse.ClassDescription = newClass.Description;
            return licenseClasse;
        }

        [HttpGet("license-classes", Name = "GetLicenseClasses")]
        public async Task<ActionResult<IEnumerable<LicenseClass>>> AllTypes()
        {
            var classesList = await clsLicenseClasses.ListAsync();

            if (classesList.Count() <= 0)
                return NotFound("No License Classes Found");
            else
                return Ok(classesList);
        }

        [HttpGet("{id}", Name = "ReadLicenseClassByID")]
        public async Task<ActionResult<LicenseClass>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid License Class ID Number");

            clsLicenseClasses class_ = await clsLicenseClasses.FindAsync(id);

            if (class_ == null)
                return NotFound($"License Class With ID {class_} Not Found");

            return Ok(class_.licenseDTO);
        }

        [HttpPost("", Name = "CreateLicenseClass")]
        public async Task<ActionResult<LicenseClass>> Create(LicenseClass newClass)
        {
            if (newClass == null)
                return BadRequest("invalid object data");

            clsLicenseClasses class_ = await AssignDataToClass(newClass);

            if (await class_.SaveAsync())
                return CreatedAtRoute("ReadLicenseClassByID", new { class_.LicenseClassID }, newClass);
            else
                return StatusCode(500, new { message = "Error Creating License Class" });
        }

        [HttpPut("{id}", Name = "UpdateLicenseClass")]
        public async Task<ActionResult<LicenseClass>> Update(int id, LicenseClass newClass)
        {
            if (newClass == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsLicenseClasses.isExistAsync(id);

            if (!isExist)
                return NotFound("License Class NOT Found");

            clsLicenseClasses class_ = await AssignDataToClass(newClass, id);

            if (class_ != null && await class_.SaveAsync())
                return Ok(class_.licenseDTO);
            else
                return StatusCode(500, new { message = "Error Updating License Class" });
        }

        [HttpDelete("{id}", Name = "DeleteLicenseClass")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsLicenseClasses.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsLicenseClasses.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"License Class with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting License Class" });
            }
            else
                return NotFound("License Class Not Found");
        }

        [HttpGet("classes-name", Name = "GetClassesNames")]
        public async Task<ActionResult<IEnumerable<string>>> ClassesName()
        {
            var classesList = await clsLicenseClasses.ClassesNames();

            if (classesList.Count() <= 0)
                return NotFound("No License Classes Found");
            else
                return Ok(classesList);
        }

    }
}
