using Domain;

namespace AppointmentDomain
{
    public class AppointmentDurationData : IAppointmentDurationData
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int Seconds { get; set; }
        public virtual AppointmentData AppointmentData { get; set; }
    }
}
