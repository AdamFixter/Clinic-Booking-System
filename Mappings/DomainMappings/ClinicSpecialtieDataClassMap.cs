using AppointmentDomain;
using FluentNHibernate.Mapping;

namespace DomainMappings
{
    public class ClinicSpecialtieDataClassMap : ClassMap<ClinicSpecialtieData>
    {
        public ClinicSpecialtieDataClassMap()
        {
            Schema("dbo");
            Id(x => x.ID);
            References(x => x.SpecialtieData, "SpecialtieDataID").Cascade.None();
            References(x => x.ClinicData, "ClinicDataID").Cascade.None();
        }
    }
}
