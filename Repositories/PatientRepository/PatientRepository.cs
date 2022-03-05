using Core;
using Domain;
using Repository;

/// <summary>
/// The Patients Repository
/// </summary>
namespace PatientsRepository
{
    public class PatientRepository : BaseRepository<PatientData>
    {
        public PatientRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}