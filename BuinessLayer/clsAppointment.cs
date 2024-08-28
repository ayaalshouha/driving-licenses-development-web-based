﻿using System;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using DataLayer;
using DTOsLayer; 

namespace BuisnessLayer
{
    public class clsAppointment
    {
        public enMode _Mode = enMode.add;
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public enTestType TestType { get; set; }
        public decimal PaidFees { get; set; }
        public bool isLocked { get; set; }
        public int CreatedByUserID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public int RetakeTestApplicationID { set; get; }
        public clsApplication RetakeTestInfo {  get; set; }
        public int TestID
        {
            get
            {
                return Appointments_Data.getTestIDAsync(this.ID).GetAwaiter().GetResult(); 
            }
        }
        public Appointment AppointementDTO
        {
            get
            {
                Appointment AppointmentDTO = new Appointment(this.CreatedByUserID, this.RetakeTestApplicationID);
                AppointmentDTO.appoint.TestType = (int)this.TestType;
                AppointmentDTO.appoint.LocalLicenseApplicationID = this.LocalLicenseApplicationID;
                AppointmentDTO.appoint.info.ID = this.ID;
                AppointmentDTO.appoint.info.isLocked = this.isLocked;
                AppointmentDTO.appoint.info.PaidFees = this.PaidFees;
                AppointmentDTO.appoint.info.Date = this.Date;

                return AppointmentDTO;
            }
        }
        public clsAppointment()
        {
            this.ID = -1;
            this.Date = DateOnly.FromDateTime(DateTime.Now);
            this.TestType = 0;
            this.PaidFees = -1;
            this.isLocked = false;
            this.CreatedByUserID = -1;
            this.LocalLicenseApplicationID = -1;
            this.RetakeTestApplicationID = -1;
            this._Mode = enMode.add;
        }
        private clsAppointment(Appointment appointment)
        {
            this.ID = appointment.appoint.info.ID;
            this.Date = appointment.appoint.info.Date;
            this.TestType = (enTestType)appointment.appoint.TestType;
            this.PaidFees = appointment.appoint.info.PaidFees;
            this.isLocked = appointment.appoint.info.isLocked;
            this.CreatedByUserID = appointment.CreatedByUserID;
            this.LocalLicenseApplicationID = appointment.appoint.LocalLicenseApplicationID;
            this.RetakeTestApplicationID = appointment.RetakeTestID; 
            this._Mode = enMode.update; 
        }

        public static async Task<clsAppointment> FindAsync(int appointmentID)
        {
            Appointment appointment = await Appointments_Data.getAppointmentInfoAsync(appointmentID);
            if(appointment != null)
                return new clsAppointment(appointment);
            else
                return null;
        }
        public async Task<bool> _AddNewAsync()
        {
            this.ID = await Appointments_Data.AddAsync(AppointementDTO);
            return this.ID != -1;
        }
        public async Task<bool> _UpdateAsync()
        {
            return await Appointments_Data.UpdateAsync(AppointementDTO);
        }
        public async Task<bool> SaveAsync()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (await _AddNewAsync())
                    {
                        this._Mode = enMode.update;
                        return true;
                    }
                    break;
                case enMode.update:
                    return await _UpdateAsync();
            }

            return false;
        }
        public static async Task<IEnumerable<Appointement_>> AppointmentsTablePerTestTypeAsync(int LocalDrivingID,enTestType TestType)
        {
            return await Appointments_Data.getAppointmentsTablePerTestTypeAsync(LocalDrivingID, (int)TestType); 
        }
        public static async Task<bool> isThereAnyActiveAppointments(int LocalDrivingID, enTestType TestType)
        {
            return await Appointments_Data.isThereAnyActiveAppointmentsAsync(LocalDrivingID, (int)TestType); 
        }    
        public static async Task<bool> isExistAsync(int id)
        {
            return await Appointments_Data.isExist(id);
        }
        public static async Task<bool> DeleteAsync(int id)
        {
            return await Appointments_Data.DeleteAsync(id);
        }
    }
}
