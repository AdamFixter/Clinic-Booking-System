using AppointmentDomain;
using AppointmentDurationsRespository;
using AppointmentsRepository;
using AppointmentTypeRepository;
using AppointmentUrgenciesRepository;
using ClinicsRepository;
using Core;
using Domain;
using PatientsRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentsBusiness
{
    public class AppointmentBusiness
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentUrgencyRepository appointmentUrgencyRepository;
        private AppointmentTypeRespoistory appointmentTypeRepository;
        private AppointmentDurationRepository appointmentDurationRepository;
        private ClinicRepository clinicRepository;
        private PatientRepository patientRepository;
        public AppointmentBusiness(IUnitOfWork unitOfWork)
        {
            this.appointmentRepository = new AppointmentRepository(unitOfWork);
            this.appointmentUrgencyRepository = new AppointmentUrgencyRepository(unitOfWork);
            this.appointmentTypeRepository = new AppointmentTypeRespoistory(unitOfWork);
            this.appointmentDurationRepository = new AppointmentDurationRepository(unitOfWork);
            this.clinicRepository = new ClinicRepository(unitOfWork);
            this.patientRepository = new PatientRepository(unitOfWork);
        }

        public IEnumerable<AppointmentUrgencyData> GetAllUrgencies()
        {
            return this.appointmentUrgencyRepository.GetAll();
        }
        public AppointmentUrgencyData GetUrgencyById(int ID)
        {
            return this.appointmentUrgencyRepository.Get(ID);
        }

        public IEnumerable<AppointmentTypeData> GetAllTypes()
        {
            return this.appointmentTypeRepository.GetAll();
        }
        public AppointmentTypeData GetTypeById(int ID)
        {
            return this.appointmentTypeRepository.Get(ID);
        }

        public IEnumerable<AppointmentDurationData> GetAllDurations()
        {
            return this.appointmentDurationRepository.GetAll();
        }
        public AppointmentDurationData GetDurationById(int ID)
        {
            return this.appointmentDurationRepository.Get(ID);
        }


        public void Delete(int ID)
        {
            this.appointmentRepository.Delete(ID);
        }

        public AppointmentData Get(int ID)
        {
            return this.appointmentRepository.Get(ID);
        }

        public IEnumerable<AppointmentData> GetAll()
        {
            //TODO: Validate appointments. (Schedule agent task)
            return this.appointmentRepository.GetAll();
        }
        private void validateAppointment(AppointmentData appointment)
        {
            if (appointment.Date < DateTime.Today)
            {
                appointment.Archived = true;
                this.appointmentRepository.Update(appointment);
            }
        }

        public void Insert(AppointmentData t)
        {
            this.appointmentRepository.Insert(t);
        }

        public void Save(AppointmentData t)
        {
            this.appointmentRepository.Save(t);
        }

        public void Update(AppointmentData t)
        {
            this.appointmentRepository.Update(t);
        }
    }
}
