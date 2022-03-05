using AppointmentContracts;
using Domain;
using PatientDataContracts;
using System;
using System.Runtime.Serialization;

namespace AppointmentDataContracts
{
    [DataContract]
    public class AppointmentDataContract
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public PatientDataContract Patient { get; set; }
        [DataMember]
        public ClinicDataContract Clinic { get; set; }
        [DataMember]
        public AppointmentUrgencyDataContract AppointmentUrgencyData { get; set; }
        [DataMember]
        public AppointmentTypeDataContract AppointmentTypeData { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string FormattedDate { get; set; }
        [DataMember]
        public AppointmentDurationDataContract Duration { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public bool Archived { get; set; }
    }
}
