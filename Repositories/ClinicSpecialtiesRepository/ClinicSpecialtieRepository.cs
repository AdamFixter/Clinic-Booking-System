using AppointmentDomain;
using Core;
using Domain;
using NHibernate.Criterion;
using Repository;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClinicSpecialtiesRepository
{
    public class ClinicSpecialtieRepository : BaseRepository<ClinicSpecialtieData>
    {
        private IUnitOfWork unitOfWork;
        public ClinicSpecialtieRepository(IUnitOfWork unitOfWork) : base(unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<SpecialtieData> GetByClinicID(int ID)
        {
            return this.unitOfWork.Session.QueryOver<ClinicSpecialtieData>()
                .Where(x => x.ClinicData.ID == ID)
                .Select(x => x.SpecialtieData)
                .List<SpecialtieData>();
        }
    }
}
