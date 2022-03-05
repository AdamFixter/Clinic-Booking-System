using Domain;
using FluentNHibernate.Mapping;

namespace DomainMappings
{
    public class AppointmentUrgencyDataClassMap : ClassMap<AppointmentUrgencyData>
    {
        public AppointmentUrgencyDataClassMap()
        {
            Schema("dbo");
            Id(x => x.ID);
            Map(x => x.Name);
            HasOne(x => x.AppointmentData).ForeignKey("AppointmentUrgencyDataID").Cascade.None();
        }
    }
}
