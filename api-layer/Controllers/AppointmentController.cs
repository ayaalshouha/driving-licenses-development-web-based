﻿using BuisnessLayer;
using DTOsLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.ComponentModel;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class appointmentController : Controller
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

        [HttpGet("{id}", Name = "ReadAppointmentByID")]
        public async Task<ActionResult<Appointment>> Read(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Appointment ID Number");

            var appointment = await clsAppointment.FindAsync(id);

            if (appointment == null)
                return NotFound($"Appointment With ID {id} Not Found");

            return Ok(appointment.AppointementDTO);
        }
        [HttpGet("appointment-view/{id}", Name = "ReadAppointmentView")]
        public async Task<ActionResult<Appointment_Veiw>> ReadView(int id)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Appointment ID Number");

            var appointment = await clsAppointment.FindView(id);

            if (appointment == null)
                return NotFound($"Appointment With ID {id} Not Found");

            return Ok(appointment);
        }

        [HttpPost("", Name = "CreateAppointment")]
        public async Task<ActionResult<Appointment>> Create(Appointment newAppointment)
        {
            if (newAppointment == null)
                return BadRequest("invalid object data");


            var appointment = AssignDataToAppointment(newAppointment);

            if (await appointment.SaveAsync())
                return CreatedAtRoute("ReadAppointmentByID", new { appointment.ID }, appointment);
            else
                return StatusCode(500, new { message = "Error Creating Appointment" });
        }

        [HttpPut("{id}", Name = "UpdateAppointment")]
        public async Task<ActionResult<Appointment>> Update(int id, Appointment newAppointment)
        {
            if (newAppointment == null)
                return BadRequest("invalid object data");

            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsAppointment.isExistAsync(id);

            if (!isExist)
                return NotFound("Appointment NOT Found");

            clsAppointment appointment = AssignDataToAppointment(newAppointment, id);

            if (appointment != null && await appointment.SaveAsync())
                return Ok(appointment.AppointementDTO);
            else
                return StatusCode(500, new { message = "Error Updating Appointment" });
        }

        [HttpDelete("{id}", Name = "DeleteAppointment")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!Int32.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid ID");

            bool isExist = await clsAppointment.isExistAsync(id);

            if (isExist)
            {
                bool isDeleted = await clsAppointment.DeleteAsync(id);
                if (isDeleted)
                    return Ok($"Appointment with ID {id} Deletted Successfully");
                else
                    return StatusCode(500, new { Message = "Error Deletting Appointment" });
            }
            else
                return NotFound("Appointment Not Found");
        }

        [HttpGet("active-appointments-exist/by-test-type/{testType}/local-app/{localAppId}", Name = "FindActiveAppointemnts")]
        public async Task<ActionResult<bool>> isThereAnyActiveAppointemnts(int localAppId, enTestType testType)
        {
            var localappID = await clsLocalDrivingLicenses.isExistAsync(localAppId);

            if (!localappID)
                return NotFound($"Local Application ID Not Found");
            else
            {
                var result = await clsAppointment.isThereAnyActiveAppointments(localAppId, testType);
                return Ok(result);
            }
        }

        [HttpGet("appointments/by-test-type/{testType}/local-app/{localAppId}", Name = "AllAppointmentsPerTestType")]
        public async Task<ActionResult<IEnumerable<Appointement_>>> AllAppointmentsPerTestType(int localAppId, enTestType testType)
        {
            var localappID = await clsLocalDrivingLicenses.isExistAsync(localAppId);

            if (!localappID)
                return NotFound($"Local Application ID Not Found");
            else
            {
                var all = clsAppointment.AppointmentsTablePerTestTypeAsync(localAppId, testType);
                return Ok(all);
            }
        }

        [HttpGet("appointments-view", Name = "AllAppointments")]
        public async Task<ActionResult<IEnumerable<Appointement_>>> Appointments()
        {
            var all = await clsAppointment.Appointments_View();
            if (all.Count() <= 0)
                return NotFound("No Appiontments Found");
            else
                return Ok(all);
        }

        [HttpGet("test-type/{testType}/local-app/{localAppID}", Name = "ReadAppointment")]
        public async Task<ActionResult<Appointment>> ReadAppointment(int localAppID, enTestType testType )
        {
            if (!int.TryParse(localAppID.ToString(), out _) || Int32.IsNegative(localAppID))
                return BadRequest("Invalid Application ID Number");

            Appointment appointment = await clsAppointment.GetApointmentPerTestType(localAppID, testType);

            if (appointment == null)
                return NotFound($"There is no unlocked appointment with application id {localAppID} and test type {testType}");

            return Ok(appointment);
        }

        [HttpGet("{id}/update-date/{newDate}", Name = "UpdateAppointmentDate")]
        public async Task<ActionResult<bool>> update(int id, DateTime newDate)
        {
            if (!int.TryParse(id.ToString(), out _) || Int32.IsNegative(id))
                return BadRequest("Invalid Appointment ID Number");
           
            var found = await clsAppointment.isExistAsync(id);
            if (!found)
            {
                return NotFound("No Appiontment Found");
            }
            
            bool updated = await clsAppointment.UpdateDate(id, newDate);
            return Ok(updated);
        }
    }
}
