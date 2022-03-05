using System.Runtime.Serialization;

namespace AppointmentDataContracts
{
    [DataContract]
    public class AppointmentUrgencyDataContract
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}