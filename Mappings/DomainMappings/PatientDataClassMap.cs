using Domain;
using FluentNHibernate.Mapping;

namespace DomainMappings
{
    public class PatientDataClassMap : ClassMap<PatientData>
    {
        public PatientDataClassMap()
        {
            Schema("dbo");
            Id(x => x.ID);
            Map(x => x.Firstname);
            Map(x => x.Surname);
            //HasMany(x => x.Appointments).KeyColumn("PatientDataID").Inverse().Cascade.All();
        }
    }
}
