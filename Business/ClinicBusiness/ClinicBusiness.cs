using AppointmentDomain;
using ClinicSpecialtiesRepository;
using ClinicsRepository;
using Core;
using Domain;
using PatientsRepository;
using System.Collections.Generic;
using System.Linq;

namespace ClinicsBusiness
{
    public class ClinicBusiness
    {
        private readonly IUnitOfWork unitOfWork;

        public ClinicBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<SpecialtieData> GetSpecialties(int ID)
        {
            return new ClinicSpecialtieRepository(this.unitOfWork).GetByClinicID(ID);
        }
        public IEnumerable<SpecialtieData> GetAvailableSpecialties(int ID)
        {
            return new ClinicSpecialtieRepository(this.unitOfWork).GetByClinicID(ID);
        }
        public void Delete(int ID)
        {
            new ClinicRepository(this.unitOfWork).Delete(ID);
        }

        public ClinicData Get(int ID)
        {
            return new ClinicRepository(this.unitOfWork).Get(ID);
        }


        public IEnumerable<ClinicData> GetAll()
        {
            return new ClinicRepository(this.unitOfWork).GetAll();
        }

        public void Insert(ClinicData t)
        {
            new ClinicRepository(this.unitOfWork).Insert(t);
        }

        public void Save(ClinicData t)
        {
            new ClinicRepository(this.unitOfWork).Save(t);
        }

        public void Update(ClinicData t)
        {
            new ClinicRepository(this.unitOfWork).Update(t);
        }
    }
}
