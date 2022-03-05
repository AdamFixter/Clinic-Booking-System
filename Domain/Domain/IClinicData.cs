using AppointmentDomain;
using System.Collections.Generic;

namespace Domain
{
    public interface IClinicData
    {
        int ID { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        IEnumerable<ClinicSpecialtieData> Specialties { get; set; }
        IEnumerable<AppointmentData> Appointments { get; set; }
    }
}
