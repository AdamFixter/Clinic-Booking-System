using Domain;
using System.Runtime.Serialization;

namespace AppointmentContracts
{
    [DataContract]
    public class SpecialtieDataContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public ClinicData ClinicData { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}