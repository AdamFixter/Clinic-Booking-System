using Core;
using Domain;
using Repository;

/// <summary>
/// The Appointments Repository
/// </summary>
namespace AppointmentsRepository
{
    public class AppointmentRepository : BaseRepository<AppointmentData>
    {
        public AppointmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
