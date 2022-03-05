using Core;
using Domain;
using Repository;

/// <summary>
/// The Appointment Urgency Repository
/// </summary>
namespace AppointmentUrgenciesRepository
{
    public class AppointmentUrgencyRepository : BaseRepository<AppointmentUrgencyData>
    {
        public AppointmentUrgencyRepository(IUnitOfWork unitOfWork) : base(unitOfWork) {}
    }
}
