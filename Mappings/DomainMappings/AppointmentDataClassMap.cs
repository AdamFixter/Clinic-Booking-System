using Domain;
using FluentNHibernate.Mapping;

namespace DomainMappings
{
    public class AppointmentDataClassMap : ClassMap<AppointmentData>
    {
        public AppointmentDataClassMap()
        {
            Schema("dbo");
            Id(x => x.ID);
            Map(x => x.PhoneNumber);
            Map(x => x.Email);
            Map(x => x.Date);
            Map(x => x.Archived);
            References(x => x.Patient, "PatientDataID").Cascade.None();
            References(x => x.Clinic, "ClinicDataID").Cascade.None();
            References(x => x.Duration, "AppointmentDurationDataID").Cascade.None();
            References(x => x.AppointmentUrgencyData, "AppointmentUrgencyDataID").Cascade.None();
            References(x => x.AppointmentTypeData, "AppointmentTypeDataID").Cascade.None();

        }
    }
}
