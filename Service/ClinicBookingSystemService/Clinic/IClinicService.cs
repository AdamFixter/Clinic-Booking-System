using AppointmentContracts;
using Domain;
using System.Collections.Generic;
using System.ServiceModel;

namespace ClinicBookingSystemService
{
    [ServiceContract]
    public interface IClinicService
    {
        [OperationContract]
        IEnumerable<ClinicDataContract> GetClinics();
        [OperationContract]
        ClinicDataContract GetClinic(int ID);
        [OperationContract]
        void CreateClinic(ClinicData clinic);
        [OperationContract]
        ClinicData GetClinicData(int ID);
        [OperationContract]
        IEnumerable<SpecialtieDataContract> GetSpecialties(int ID);
    }
}