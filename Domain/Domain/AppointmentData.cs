using AppointmentDomain;
using System;

namespace Domain
{
    public class AppointmentData : IAppointmentData
    {
        public AppointmentData() { }
        public virtual int ID { get; set; }
        public virtual PatientData Patient { get; set; }
        public virtual ClinicData Clinic { get; set; }
        public virtual AppointmentUrgencyData AppointmentUrgencyData { get; set; }
        public virtual AppointmentTypeData AppointmentTypeData { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual AppointmentDurationData Duration { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual bool Archived { get; set; }

    }
}
