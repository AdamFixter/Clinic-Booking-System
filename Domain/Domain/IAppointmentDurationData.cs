using Domain;

namespace AppointmentDomain
{
    public interface IAppointmentDurationData
    {
        int ID { get; set; }
        string Name { get; set; }
        int Seconds { get; set; }
        AppointmentData AppointmentData { get; set; }
    }
}
