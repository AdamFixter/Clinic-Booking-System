using Core;
using Domain;
using Repository;
using System.Linq;

/// <summary>
/// The Specialtie Repository
/// </summary>
namespace PatientsRepository
{
    public class SpecialtieRepository : BaseRepository<SpecialtieData>
    {
        private readonly IUnitOfWork unitOfWork;

        public SpecialtieRepository(IUnitOfWork unitOfWork) : base(unitOfWork) {
            this.unitOfWork = unitOfWork;
        }
    }
}