using AppointmentDomain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMappings
{
    public class AppointmentDurationDataClassMap : ClassMap<AppointmentDurationData>
    {
        public AppointmentDurationDataClassMap()
        {
            Schema("dbo");
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.Seconds);
            HasOne(x => x.AppointmentData).ForeignKey("AppointmentDurationDataID").Cascade.None();
        }
    }
}
