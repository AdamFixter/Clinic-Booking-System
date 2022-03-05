using AppointmentDomain;
using Core;
using Domain;
using NHibernate.Util;
using Repository;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The Clinics Repository
/// </summary>
namespace ClinicsRepository
{
    public class ClinicRepository : BaseRepository<ClinicData>
    {
        public ClinicRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
