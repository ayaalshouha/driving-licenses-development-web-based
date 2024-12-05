using BuisnessLayer;
using DTOsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AppointmentController : Controller
    {
        private clsAppointment AssignDataToAppointment(Appointment newAppointment, int ID = -1)
        {
            clsAppointment appointment;

            if (ID == -1)
                appointment = new clsAppointment();
            else
            {
                appointment = clsAppointment.FindAsync(ID).GetAwaiter().GetResult();
                if (appointment == null) return null;
            }

            appointment.LocalLicenseApplicationID = newAppointment.LocalLicenseApplicationID;
            appointment.TestType = (enTestType)newAppointment.TestType;
            appointment.isLocked = newAppointment.isLocked;
            appointment.Date = newAppointment.Date;
            appointment.RetakeTestApplicationID = newAppointment.RetakeTestID;
            appointment.CreatedByUserID = newAppointment.CreatedByUserID;
            appointment.PaidFees = newAppointment.PaidFees;
            return appointment;
        }

        [HttpGet("Read", Name = "ReadAppointmentByID")]
        public async Task<ActionResult<Appointment>> Read(int appointmentID)
        {
            if (!int.TryParse(appointmentID.ToString(), out _) || Int32.IsNegative(appointmentID))
                return BadRequest("Invalid Test ID Number");

            var appointment = await clsAppointment.FindAsync(appointmentID);

            if (appointment == null)
                return NotFound($"Appointment With ID {appointmentID} Not Found");

            return Ok(appointment.AppointementDTO);
        }

        [HttpPost("Create", Name = "CreateAppointment")]
        public async Task<ActionResult<Appointment>> Create(Appointment newAppointment)
        {
            if (newAppointment == null)
                return BadRequest("invalid object data");

            bool appointmentFound = await clsAppointment.isExistAsync(newAppointment.ID);
            if (!appointmentFound)
                return BadRequest($"Appointment with ID {newAppointment.ID} NOT found, You have to add appointment details first!");

            var appointment = AssignDataToAppointment(newAppointment);

            if (await appointment.SaveAsync())
                return CreatedAtRoute("ReadAppointmentByID", new { appointment.ID }, newAppointment);
            else
                return StatusCode(500, new { message = "Error Creating Appointment" });
        }

        [HttpPut("Update", Name = "UpdateAppointment")]
        public async Task<ActionResult<Appointment>> Update(int AppointmentID, Appointment newAppointment)
        {
            if (newAppointment == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(AppointmentID.ToString(), out _) || Int32.IsNegative(AppointmentID))
                return BadRequest("Invalid ID");

            bool isExist = await clsAppointment.isExistAsync(AppointmentID);

            if (!isExist)
                return NotFound("Appointment NOT Found");

            clsAppointment appointment = AssignDataToAppointment(newAppointment, AppointmentID);

            if (appointment != null && await appointment.SaveAsync())
                return Ok(appointment.AppointementDTO);
            else
                return StatusCode(500, new { message = "Error Updating Appointment" });
        }

        [HttpDelete("Delete", Name = "DeleteAppointment")]
        public async Task<ActionResult> Delete(int AppointemntID)
        {
            if (!Int32.TryParse(AppointemntID.ToString(), out _) || Int32.IsNegative(AppointemntID))
                return BadRequest("Invalid ID");

            bool isExist = await clsAppointment.isExistAsync(AppointemntID);

            if (isExist)
            {
                bool isDeleted = await clsAppointment.DeleteAsync(AppointemntID);
                if (isDeleted)
                    return Ok($"Appointment with ID {AppointemntID} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Appointment" });
            }
            else
                return NotFound("Appointment Not Found");
        }

        [HttpGet("isThereAnyActiveAppointemnts", Name = "FindActiveAppointemnts")]
        public async Task<ActionResult<bool>> isThereAnyActiveAppointemnts(int LocalApplicationID, enTestType TestType)
        {
            var localappID = await clsLocalDrivingLicenses.isExistAsync(LocalApplicationID);

            if (!localappID)
                return NotFound($"Local Application ID Not Found");
            else
            {
                var result = await clsAppointment.isThereAnyActiveAppointments(LocalApplicationID, TestType);
                return Ok(result);
            }
        }

        [HttpGet("ReadAppointmentsPerTestType", Name = "AllAppointmentsPerTestType")]
        public async Task<ActionResult<bool>> AllAppointmentsPerTestType(int LocalApplicationID, enTestType TestType)
        {
            var localappID = await clsLocalDrivingLicenses.isExistAsync(LocalApplicationID);

            if (!localappID)
                return NotFound($"Local Application ID Not Found");
            else
            {
                var all = clsAppointment.AppointmentsTablePerTestTypeAsync(LocalApplicationID, TestType);
                return Ok(all);
            }
        }

    }
}
