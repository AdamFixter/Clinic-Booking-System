using Domain;
using PatientDataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClinicBookingSystemService
{
    [ServiceContract]
    public interface IPatientService
    {
        [OperationContract]
        IEnumerable<PatientDataContract> GetPatients();
        [OperationContract]
        PatientDataContract GetPatient(int ID);
        [OperationContract]
        PatientData GetPatientData(int ID);
        [OperationContract]
        void CreatePatient(PatientData patient);
        [OperationContract]
        void DeletePatient(int ID);
    }
}