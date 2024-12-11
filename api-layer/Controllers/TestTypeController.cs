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
    public class testTypeController : Controller
    {
        private static clsTestTypes AssignDataToTypeType(TestType newTest, int ID = -1)
        {
            clsTestTypes type;

            if (ID == -1)
                type = new clsTestTypes();
            else
            {
                type = clsTestTypes.FindAsync(ID).GetAwaiter().GetResult();
                if (type == null) return null;
            }

            type.TypeTitle = newTest.TypeTitle;
            type.Fees = newTest.Fees;
            type.Description = newTest.Description;

            return type;
        }

        [HttpGet("test-types", Name = "GetTestTypes")]
        public async Task<ActionResult<IEnumerable<TestType>>> AllTypes()
        {
            var typesList = await clsTestTypes.getAllTypesAsync();

            if (typesList.Count() <= 0)
                return NotFound("No Test Types Found");
            else
                return Ok(typesList);
        }

        [HttpGet("{id}", Name = "ReadTestTypeByID")]
        public async Task<ActionResult<TestType>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Test Type ID Number");

            clsTestTypes type = await clsTestTypes.FindAsync(id);

            if (type == null)
                return NotFound($"Test Type With ID {id} Not Found");

            return Ok(type.TestTypeDTO);
        }

        [HttpPost("", Name = "CreateTestType")]
        public async Task<ActionResult<TestType>> Create(TestType newType)
        {
            if (newType == null)
                return BadRequest("invalid object data");

            clsTestTypes type = AssignDataToTypeType(newType);

            if (await type.SaveAsync())
                return CreatedAtRoute("ReadTestTypeByID", new { type.ID }, newType);
            else
                return StatusCode(500, new { message = "Error Creating Test Type" });
        }

        [HttpPut("{id}", Name = "UpdateTestType")]
        public async Task<ActionResult<TestType>> Update(int id, TestType newType)
        {
            if (newType == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsTestTypes.isExistAsync(id);

            if (!isExist)
                return NotFound("Test Type NOT Found");

            clsTestTypes type =  AssignDataToTypeType(newType, id);

            if (type != null && await type.SaveAsync())
                return Ok(type.TestTypeDTO);
            else
                return StatusCode(500, new { message = "Error Updating Test Type" });
        }

        [HttpDelete("{id}", Name = "DleteTestType")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsTestTypes.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsTestTypes.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"Test Type with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Test Type" });
            }
            else
                return NotFound("Application Type Not Found");
        }

    }
}
