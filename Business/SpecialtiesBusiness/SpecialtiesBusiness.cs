using Core;
using Domain;
using PatientsRepository;
using System.Collections.Generic;

namespace SpecialtiesBusiness
{
    public class SpecialtieBusiness
    {
        private readonly IUnitOfWork unitOfWork;

        public SpecialtieBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int ID)
        {
            new SpecialtieRepository(this.unitOfWork).Delete(ID);
        }

        public SpecialtieData Get(int ID)
        {
            return new SpecialtieRepository(this.unitOfWork).Get(ID);
        }


        public IEnumerable<SpecialtieData> GetAll()
        {
            return new SpecialtieRepository(this.unitOfWork).GetAll();
        }

        public void Insert(SpecialtieData t)
        {
            new SpecialtieRepository(this.unitOfWork).Insert(t);
        }

        public void Save(SpecialtieData t)
        {
            new SpecialtieRepository(this.unitOfWork).Save(t);
        }

        public void Update(SpecialtieData t)
        {
            new SpecialtieRepository(this.unitOfWork).Update(t);
        }
    }
}
