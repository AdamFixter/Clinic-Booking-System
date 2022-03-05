using Domain;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AppointmentDataContracts
{
    [DataContract]
    public class ClinicSpecialtieDataContract
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public IEnumerable<SpecialtieData> Specialties { get; set; }
        [DataMember]
        public IEnumerable<ClinicData> Appointments { get; set; }
    }
}
