using System.ServiceModel;

namespace ClinicBookingSystemService
{
    [ServiceContract]
    public interface IClinicBookingSystemService
    {
        [OperationContract]
        IAppointmentService GetAppointmentService();
        [OperationContract]
        IPatientService GetPatientService();

    }
}