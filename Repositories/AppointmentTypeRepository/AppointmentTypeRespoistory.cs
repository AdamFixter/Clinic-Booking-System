using Core;
using Domain;
using Repository;

/// <summary>
/// The Appointment Types Repository
/// </summary>
namespace AppointmentTypeRepository
{
    public class AppointmentTypeRespoistory : BaseRepository<AppointmentTypeData>
    {
        public AppointmentTypeRespoistory(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
