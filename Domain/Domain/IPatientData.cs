using System.Collections.Generic;

namespace Domain
{
    public interface IPatientData
    {
        int ID { get; set; }
        string Firstname { get; set; }
        string Surname { get; set; }
        IEnumerable<AppointmentData> Appointments { get; set; }
    }
}
