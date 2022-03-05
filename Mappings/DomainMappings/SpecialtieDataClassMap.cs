using Domain;
using FluentNHibernate.Mapping;

namespace DomainMappings
{
    public class SpecialtieDataClassMap : ClassMap<SpecialtieData>
    {
        public SpecialtieDataClassMap()
        {
            Schema("dbo");
            Id(x => x.ID);
            Map(x => x.Code);
            Map(x => x.Description);
        }
    }
}
