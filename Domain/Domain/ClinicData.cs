using AppointmentDomain;
using System.Collections.Generic;

namespace Domain
{
    public class ClinicData : IClinicData
    {
        public virtual int ID { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual IEnumerable<ClinicSpecialtieData> Specialties { get; set; }
        public virtual IEnumerable<AppointmentData> Appointments { get; set; }
    }
}