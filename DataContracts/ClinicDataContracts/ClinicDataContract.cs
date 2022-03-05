using Domain;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace ClinicDataContracts
{
    [DataContract]
    public class ClinicDataContract
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public IEnumerable<SpecialtieData> Specialties { get; set; }
        [DataMember]
        public IEnumerable<AppointmentData> Appointments { get; set; }

    }
}
