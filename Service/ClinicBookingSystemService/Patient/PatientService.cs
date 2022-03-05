using Core;
using Domain;
using PatientDataContracts;
using PatientsBusiness;
using System.Collections.Generic;
using System.Linq;

namespace ClinicBookingSystemService
{
    public class PatientService : IPatientService
    {
        public PatientService() { }
        public IEnumerable<PatientDataContract> GetPatients()
        {
            IEnumerable<PatientData> patients;
            using (var unitOfWork = new UnitOfWork())
            {
                patients = new PatientBusiness(unitOfWork).GetAll();
                unitOfWork.Close();
            }
            return patients.Select(patient => this.MapToDataContract(patient));
        }
        public PatientDataContract GetPatient(int ID)
        {
            PatientData patient;
            using (var unitOfWork = new UnitOfWork())
            {
                patient = new PatientBusiness(unitOfWork).Get(ID);
                unitOfWork.Close();
            }
            return this.MapToDataContract(patient);

        }
        public void CreatePatient(PatientData patient)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                new PatientBusiness(unitOfWork).Insert(patient);
                unitOfWork.Close();
            }
        }
        public void DeletePatient(int ID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                new PatientBusiness(unitOfWork).Delete(ID);
                unitOfWork.Close();
            }
        }
        public PatientData GetPatientData(int ID)
        {
            PatientData patient;
            using (var unitOfWork = new UnitOfWork())
            {
                patient = new PatientBusiness(unitOfWork).Get(ID);
            }
            return patient;
        }
        private PatientDataContract MapToDataContract(PatientData patient)
        {
            return new PatientDataContract
            {
                Id = patient.ID,
                Appointments = patient.Appointments,
                Firstname = patient.Firstname,
                Surname = patient.Surname,                
                Name = $"{patient.Firstname} {patient.Surname}"
            };
        }
    }
}