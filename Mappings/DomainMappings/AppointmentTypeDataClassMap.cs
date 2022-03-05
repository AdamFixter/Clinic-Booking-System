using Domain;
using FluentNHibernate.Mapping;

namespace DomainMappings
{
    public class AppointmentTypeDataClassMap : ClassMap<AppointmentTypeData>
    {
        public AppointmentTypeDataClassMap()
        {
            Schema("dbo");
            Id(x => x.ID);
            Map(x => x.Name);
            HasOne(x => x.AppointmentData).ForeignKey("AppointmentTypeDataID").Cascade.None();
        }
    }
}
