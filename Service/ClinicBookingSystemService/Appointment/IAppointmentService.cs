using AppointmentDataContracts;
using AppointmentDomain;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace ClinicBookingSystemService
{
    [ServiceContract]
    public interface IAppointmentService
    {
        [OperationContract]
        AppointmentUrgencyData GetUrgencyData(int ID);
        [OperationContract]
        IEnumerable<AppointmentUrgencyDataContract> GetAllUrgencies();
        [OperationContract]
        AppointmentUrgencyDataContract GetUrgencyById(int ID);
        [OperationContract]
        IEnumerable<AppointmentDataContract> Search(string input, DateTime? date);

        [OperationContract]
        AppointmentDurationData GetDurationData(int ID);
        [OperationContract]
        IEnumerable<AppointmentDurationDataContract> GetAllDurations();
        [OperationContract]
        AppointmentDurationDataContract GetDurationById(int ID);

        [OperationContract]
        AppointmentTypeData GetTypeData(int ID);
        [OperationContract]
        IEnumerable<AppointmentTypeDataContract> GetAllTypes();
        [OperationContract]
        AppointmentTypeDataContract GetTypeById(int ID);
        [OperationContract]
        AppointmentData GetAppointmentData(int ID);
        [OperationContract]
        AppointmentDataContract Get(int ID);
        [OperationContract]
        IEnumerable<AppointmentDataContract> GetAll();
        [OperationContract]
        IEnumerable<AppointmentDataContract> GetArchived();
        [OperationContract]
        IEnumerable<AppointmentDataContract> GetAllAvailable();
        [OperationContract]
        void CreateAppointment(AppointmentData appointment);
        [OperationContract]
        void DeleteAppointment(int ID);
        [OperationContract]
        void UpdateAppointment(AppointmentData appointment);
    }
}