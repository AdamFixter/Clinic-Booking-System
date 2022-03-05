using AppointmentDomain;
using System;
namespace Domain
{
    public interface IAppointmentData
    {
         int ID { get; set; }
         PatientData Patient { get; set; }
         ClinicData Clinic { get; set; }
         AppointmentUrgencyData AppointmentUrgencyData { get; set; }
         AppointmentTypeData AppointmentTypeData { get; set; }
         DateTime Date { get; set; }
         AppointmentDurationData Duration { get; set; }
         string PhoneNumber { get; set; }
         string Email { get; set; }
         bool Archived { get; set; }
    }
}