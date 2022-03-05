using Domain;

namespace AppointmentDomain
{
    public class ClinicSpecialtieData : IClinicSpecialtieData
    {
        public virtual int ID { get; set; }
        public virtual ClinicData ClinicData { get; set; }
        public virtual SpecialtieData SpecialtieData { get; set; }
    }
}
