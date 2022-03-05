using System.Runtime.Serialization;

namespace AppointmentDataContracts
{
    public class AppointmentDurationDataContract
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Seconds { get; set; }
    }
}
