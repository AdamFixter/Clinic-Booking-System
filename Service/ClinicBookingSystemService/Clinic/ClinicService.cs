using AppointmentContracts;
using ClinicsBusiness;
using Core;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace ClinicBookingSystemService
{
    public class ClinicService : IClinicService
    {
        public ClinicService() { }

        public IEnumerable<ClinicDataContract> GetClinics()
        {
            IEnumerable<ClinicData> patients;
            using (var unitOfWork = new UnitOfWork())
            {
                patients = new ClinicBusiness(unitOfWork).GetAll();
                unitOfWork.Close();
            }
            return patients.Select(patient => this.MapToDataContract(patient));
        }
        public ClinicDataContract GetClinic(int ID)
        {
            ClinicData clinic;
            using (var unitOfWork = new UnitOfWork())
            {
                clinic = new ClinicBusiness(unitOfWork).Get(ID);
                unitOfWork.Close();
            }
            return this.MapToDataContract(clinic);

        }
        public void CreateClinic(ClinicData clinic)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                new ClinicBusiness(unitOfWork).Insert(clinic);
                unitOfWork.Close();
            }
        }
        public ClinicData GetClinicData(int ID)
        {
            ClinicData clinic;
            using (var unitOfWork = new UnitOfWork())
            {
                clinic = new ClinicBusiness(unitOfWork).Get(ID);
                unitOfWork.Close();
            }
            return clinic;
        }
        public IEnumerable<SpecialtieDataContract> GetSpecialties(int ID)
        {
            IEnumerable<SpecialtieData> specialties;
            using (var unitOfWork = new UnitOfWork())
            {
                specialties = new ClinicBusiness(unitOfWork).GetSpecialties(ID);
                unitOfWork.Close();
            }
            return specialties.Select(specialtie => this.MapToSpecialtieDataContract(specialtie));
        }

        public SpecialtieDataContract MapToSpecialtieDataContract(SpecialtieData specialtie)
        {
            return new SpecialtieDataContract()
            {
                Id = specialtie.ID,
                Code = specialtie.Code,
                Description = specialtie.Description
            };
        }
        public ClinicDataContract MapToDataContract(ClinicData clinic)
        {
            return new ClinicDataContract
            {
                ID = clinic.ID,
                Code = clinic.Code,
                Description = clinic.Description,
                Specialties = clinic.Specialties,
                Appointments = clinic.Appointments
            };
        }
    }
}