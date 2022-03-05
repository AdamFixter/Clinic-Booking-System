using AppointmentContracts;
using AppointmentDataContracts;
using AppointmentDomain;
using AppointmentsBusiness;
using Core;
using Domain;
using PatientDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClinicBookingSystemService
{
    public class AppointmentService : IAppointmentService
    {
        private IPatientService patientService;
        private IClinicService clinicService;
        private readonly Logger logger;

        public AppointmentService(IPatientService patientService, IClinicService clinicService) {
            this.patientService = patientService;
            this.clinicService = clinicService;
            this.logger = new Logger();
        }

        public AppointmentDataContract Get(int ID)
        {
            this.logger.Log("BEGIN - Get Appointment");
            AppointmentData appointment;
            using (var unitOfWork = new UnitOfWork())
            {
                appointment = new AppointmentBusiness(unitOfWork).Get(ID);
            }
            return this.MapToDataContract(appointment);
        }
        public AppointmentData GetAppointmentData(int ID)
        {
            this.logger.Log("BEGIN - Get Appointment Data");
            AppointmentData appointment;
            using (var unitOfWork = new UnitOfWork())
            {
                appointment = new AppointmentBusiness(unitOfWork).Get(ID);
            }
            return appointment;
        }
        public IEnumerable<AppointmentDataContract> GetAllAvailable()
        {
            this.logger.Log("BEGIN - Get Available appointments");
            IEnumerable<AppointmentDataContract> appointments;
            using (var unitOfWork = new UnitOfWork())
            {
                appointments = new AppointmentBusiness(unitOfWork).GetAll().Where(a => a.Archived == false).Select(patient => this.MapToDataContract(patient));
                unitOfWork.Close();
            }
            return appointments;
        }
        public IEnumerable<AppointmentDataContract> GetArchived()
        {
            this.logger.Log("BEGIN - Get Archived appointment");
            IEnumerable<AppointmentDataContract> appointments;
            using (var unitOfWork = new UnitOfWork())
            {
                appointments = new AppointmentBusiness(unitOfWork).GetAll().Where(a => a.Archived).Select(a => this.MapToDataContract(a));
                unitOfWork.Close();
            }
            return appointments;
        }
        public IEnumerable<AppointmentDataContract> GetAll()
        {
            this.logger.Log("BEGIN - Get All appointments");
            IEnumerable<AppointmentDataContract> appointments;
            using (var unitOfWork = new UnitOfWork())
            {
                appointments = new AppointmentBusiness(unitOfWork).GetAll().Select(patient => this.MapToDataContract(patient));
                unitOfWork.Close();
            }
            return appointments;
        }
        public void UpdateAppointment(AppointmentData appointment)
        {
            this.logger.Log("BEGIN - Update Appointment");
            using (var unitOfWork = new UnitOfWork())
            {
                new AppointmentBusiness(unitOfWork).Update(appointment);
                unitOfWork.Close();
            }
        }
        public void CreateAppointment(AppointmentData appointment)
        {
            this.logger.Log("BEGIN - Create Appointment");
            using (var unitOfWork = new UnitOfWork())
            {
                new AppointmentBusiness(unitOfWork).Insert(appointment);
                unitOfWork.Close();
            }
        }
        public IEnumerable<AppointmentDataContract> Search(string searchString, DateTime? searchDate)
        {
            this.logger.Log("BEGIN - Search Appointment");
            searchString = searchString.ToLower();
            IEnumerable<AppointmentData> appointments;
            using (var unitOfWork = new UnitOfWork())
            {
                appointments = new AppointmentBusiness(unitOfWork).GetAll().Where(a =>
                {

                    ClinicDataContract clinic = this.clinicService.GetClinic(a.Clinic.ID);
                    PatientDataContract patient = this.patientService.GetPatient(a.Patient.ID);

                    bool foundStrings = false;
                    bool foundDate = false;
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        foundStrings = searchString.Contains(clinic.Code.ToLower()) ||
                                       searchString.Contains(clinic.Description.ToLower()) ||
                                       searchString.Contains(patient.Firstname.ToLower()) ||
                                       searchString.Contains(patient.Surname.ToLower());
                    }
                    if (searchDate != null)
                    {
                        foundDate = (searchDate == a.Date);
                    }
                    return foundStrings || foundDate;
                });
                unitOfWork.Close();
            }
            return appointments.Select(appointment => this.MapToDataContract(appointment));
        }
        public void DeleteAppointment(int ID)
        {
            this.logger.Log("BEGIN - Delete Appointment");
            using (var unitOfWork = new UnitOfWork())
            {
                new AppointmentBusiness(unitOfWork).Delete(ID);
            }
        }
        //
        public AppointmentUrgencyData GetUrgencyData(int ID)
        {
            this.logger.Log("BEGIN - Get Urgency Data");
            AppointmentUrgencyData urgency;
            using (var unitOfWork = new UnitOfWork())
            {
                urgency = new AppointmentBusiness(unitOfWork).GetUrgencyById(ID);
                unitOfWork.Close();
            }
            return urgency;
        }
        public IEnumerable<AppointmentUrgencyDataContract> GetAllUrgencies()
        {
            this.logger.Log("BEGIN - Get All Urgencies");
            IEnumerable<AppointmentUrgencyData> urgencies;
            using (var unitOfWork = new UnitOfWork())
            {
                urgencies = new AppointmentBusiness(unitOfWork).GetAllUrgencies();
                unitOfWork.Close();
            }
            return urgencies.Select(urgency => this.MapToUrgencyDataContract(urgency));
        }

        public AppointmentUrgencyDataContract GetUrgencyById(int ID)
        {
            this.logger.Log("BEGIN - Get Urgency by ID");
            AppointmentUrgencyData urgency;
            using (var unitOfWork = new UnitOfWork())
            {
                urgency = new AppointmentBusiness(unitOfWork).GetUrgencyById(ID);
                unitOfWork.Close();
            }
            return this.MapToUrgencyDataContract(urgency);
        }
        //
        public AppointmentTypeData GetTypeData(int ID)
        {
            this.logger.Log("BEGIN - Get Type Data by ID");
            AppointmentTypeData type;
            using (var unitOfWork = new UnitOfWork())
            {
                type = new AppointmentBusiness(unitOfWork).GetTypeById(ID);
                unitOfWork.Close();
            }
            return type;
        }
        public IEnumerable<AppointmentTypeDataContract> GetAllTypes()
        {
            this.logger.Log("BEGIN - Get All Types");
            IEnumerable<AppointmentTypeData> types;
            using (var unitOfWork = new UnitOfWork())
            {
                types = new AppointmentBusiness(unitOfWork).GetAllTypes();
                unitOfWork.Close();
            }
            return types.Select(type => this.MapToTypeDataContract(type));
        }
        public AppointmentTypeDataContract GetTypeById(int ID)
        {
            this.logger.Log("BEGIN - Get Type by ID");
            AppointmentTypeData type;
            using (var unitOfWork = new UnitOfWork())
            {
                type = new AppointmentBusiness(unitOfWork).GetTypeById(ID);
                unitOfWork.Close();
            }
            return this.MapToTypeDataContract(type);
        }

        public IEnumerable<AppointmentDurationDataContract> GetAllDurations()
        {
            this.logger.Log("BEGIN - Get All Durations");
            IEnumerable<AppointmentDurationData> types;
            using (var unitOfWork = new UnitOfWork())
            {
                types = new AppointmentBusiness(unitOfWork).GetAllDurations();
                unitOfWork.Close();
            }
            return types.Select(type => this.MapToDurationDataContract(type));
        }
        public AppointmentDurationDataContract GetDurationById(int ID)
        {
            this.logger.Log("BEGIN - Get Duration by ID");
            AppointmentDurationData type;
            using (var unitOfWork = new UnitOfWork())
            {
                type = new AppointmentBusiness(unitOfWork).GetDurationById(ID);
                unitOfWork.Close();
            }
            return this.MapToDurationDataContract(type);
        }
        public AppointmentDurationData GetDurationData(int ID)
        {
            this.logger.Log("BEGIN - Get Duration Data by ID");
            AppointmentDurationData type;
            using (var unitOfWork = new UnitOfWork())
            {
                type = new AppointmentBusiness(unitOfWork).GetDurationById(ID);
                unitOfWork.Close();
            }
            return type;
        }


        private AppointmentDataContract MapToDataContract(AppointmentData appointment)
        {
            AppointmentDurationDataContract appointmentDuration = this.GetDurationById(appointment.Duration.ID);
            string FormattedString = $"{appointment.Date.ToShortDateString()} At {appointment.Date.ToString("HH:mm")} For {TimeSpan.FromSeconds(appointmentDuration.Seconds).Minutes} minute(s)";

            return new AppointmentDataContract
            {
                ID = appointment.ID,
                Patient = this.patientService.GetPatient(appointment.Patient.ID),
                Clinic = this.clinicService.GetClinic(appointment.Clinic.ID),
                AppointmentUrgencyData = this.GetUrgencyById(appointment.AppointmentUrgencyData.ID),
                AppointmentTypeData = this.GetTypeById(appointment.AppointmentTypeData.ID),
                Duration = appointmentDuration,
                Date = appointment.Date,
                FormattedDate = FormattedString,
                PhoneNumber = appointment.PhoneNumber,
                Email = appointment.Email,
                Archived = appointment.Archived
            };
        }
        private AppointmentDurationDataContract MapToDurationDataContract(AppointmentDurationData data)
        {
            return new AppointmentDurationDataContract
            {
                ID = data.ID,
                Name = data.Name,
                Seconds = data.Seconds
            };
        }
        private AppointmentUrgencyDataContract MapToUrgencyDataContract(AppointmentUrgencyData data)
        {
            return new AppointmentUrgencyDataContract
            {
                Id = data.ID,
                Name = data.Name
            };
        }
        private AppointmentTypeDataContract MapToTypeDataContract(AppointmentTypeData data)
        {
            return new AppointmentTypeDataContract
            {
                Id = data.ID,
                Name = data.Name
            };
        }
    }
}