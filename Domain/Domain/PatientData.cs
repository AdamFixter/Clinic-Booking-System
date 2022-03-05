using System.Collections.Generic;

namespace Domain
{
    public class PatientData : IPatientData
    {
        public PatientData() { }
        public virtual int ID { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Surname { get; set; }
        public virtual IEnumerable<AppointmentData> Appointments { get; set; }
    }
}
