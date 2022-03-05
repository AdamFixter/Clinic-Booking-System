using Domain;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PatientDataContracts
{
    [DataContract]
    public class PatientDataContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public IEnumerable<AppointmentData> Appointments { get; set; }
    }
}
