namespace AppointmentContracts
{
    using AppointmentDomain;
    using Domain;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

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
        public IEnumerable<ClinicSpecialtieData> Specialties { get; set; }
        [DataMember]
        public IEnumerable<AppointmentData> Appointments { get; set; }
    }
}