using Domain;
using FluentNHibernate.Mapping;

namespace DomainMappings
{
    public class ClinicDataClassMap : ClassMap<ClinicData>
    {
        public ClinicDataClassMap()
        {
            Schema("dbo");
            Id(x => x.ID);
            Map(x => x.Code);
            Map(x => x.Description);
            HasMany(x => x.Specialties).KeyColumn("ClinicDataID").Inverse().Cascade.All();
            HasMany(x => x.Appointments).KeyColumn("ClinicDataID").Inverse().Cascade.All();
        }
    }
}
