﻿using BuisnessLayer;
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
    public class TestTypeController : Controller
    {
        private static clsTestTypes AssignDataToTypeType(TestType newTest, int ID = -1)
        {
            clsTestTypes type;

            if (ID == -1)
                type = new clsTestTypes();
            else
            {
                type = await clsTestTypes.FindAsync(ID);
                if (type == null) return null;
            }

            type.TypeTitle = newTest.TypeTitle;
            type.Fees = newTest.Fees;
            type.Description = newTest.Description;

            return type;
        }

        [HttpGet("All", Name = "GetTestTypes")]
        public async Task<ActionResult<IEnumerable<TestType>>> AllTypes()
        {
            var typesList = await clsTestTypes.getAllTypesAsync();

            if (typesList.Count() <= 0)
                return NotFound("No Test Types Found");
            else
                return Ok(typesList);
        }

        [HttpGet("Read", Name = "ReadTestTypeByID")]
        public async Task<ActionResult<TestType>> Read(int typeID)
        {
            if (!int.TryParse(typeID.ToString(), out _) || Int32.IsNegative(typeID))
                return BadRequest("Invalid Test Type ID Number");

            clsTestTypes type = await clsTestTypes.FindAsync(typeID);

            if (type == null)
                return NotFound($"Test Type With ID {typeID} Not Found");

            return Ok(type.TestTypeDTO);
        }

        [HttpPost("Create", Name = "CreateTestType")]
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

        [HttpPut("Update", Name = "UpdateTestType")]
        public async Task<ActionResult<TestType>> Update(int typeID, TestType newType)
        {
            if (newType == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(typeID.ToString(), out _) || Int32.IsNegative(typeID))
                return BadRequest("Invalid ID");

            bool isExist = await clsTestTypes.isExistAsync(typeID);

            if (!isExist)
                return NotFound("Test Type NOT Found");

            clsTestTypes type =  AssignDataToTypeType(newType, typeID);

            if (type != null && await type.SaveAsync())
                return Ok(type.TestTypeDTO);
            else
                return StatusCode(500, new { message = "Error Updating Test Type" });
        }

        [HttpDelete("Delete", Name = "DleteApplicationType")]
        public async Task<ActionResult> Delete(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            bool isExist = await clsApplicationTypes.isExistAsync(ApplicationID);

            if (isExist)
            {
                bool isDeleted = await clsApplicationTypes.DeleteAsync(ApplicationID);
                if (isDeleted)
                    return Ok($"Application Type with ID {ApplicationID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Application Type" });
            }
            else
                return NotFound("Application Type Not Found");
        }

        [HttpGet("ApplicationTypeFees", Name = "GetApplicationTypeFees")]
        public async Task<ActionResult<int>> GetFees(int ApplicationID)
        {
            if (!Int32.TryParse(ApplicationID.ToString(), out _) || Int32.IsNegative(ApplicationID))
                return BadRequest("Invalid ID");

            var isExist = await clsApplicationTypes.isExistAsync(ApplicationID);

            if (!isExist)
                return NotFound("Application Type Not Found");
            else
                return Ok(clsApplicationTypes.FeeAsync(ApplicationID));
        }

    }
}
