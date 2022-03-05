using Domain;

namespace AppointmentDomain
{
    public interface IClinicSpecialtieData
    {
        int ID { get; set; }
        ClinicData ClinicData { get; set; }
        SpecialtieData SpecialtieData { get; set; }
    }
}
