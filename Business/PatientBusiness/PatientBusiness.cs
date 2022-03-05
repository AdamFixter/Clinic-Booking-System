using Core;
using Domain;
using PatientsRepository;
using System.Collections.Generic;

namespace PatientsBusiness
{
    public class PatientBusiness
    {
        private readonly IUnitOfWork unitOfWork;

        public PatientBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int ID)
        {
            new PatientRepository(this.unitOfWork).Delete(ID);
        }

        public PatientData Get(int ID)
        {
            return new PatientRepository(this.unitOfWork).Get(ID);
        }


        public IEnumerable<PatientData> GetAll()
        {
            return new PatientRepository(this.unitOfWork).GetAll();
        }

        public void Insert(PatientData t)
        {
            new PatientRepository(this.unitOfWork).Insert(t);
        }

        public void Save(PatientData t)
        {
            new PatientRepository(this.unitOfWork).Save(t);
        }

        public void Update(PatientData t)
        {
            new PatientRepository(this.unitOfWork).Update(t);
        }
    }
}
