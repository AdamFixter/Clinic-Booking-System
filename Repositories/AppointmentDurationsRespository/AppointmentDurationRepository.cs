using AppointmentDomain;
using Core;
using Repository;

namespace AppointmentDurationsRespository
{
    public class AppointmentDurationRepository : BaseRepository<AppointmentDurationData>
    {
        public AppointmentDurationRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
