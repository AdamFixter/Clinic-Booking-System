using Core;

namespace ClinicBookingSystemService
{

    public class ClinicBookingSystemService : IClinicBookingSystemService
    {
        private Logger logger;
        public IPatientService patientService;
        public IAppointmentService appointmentService;
        public IClinicService clinicService;

        public ClinicBookingSystemService()
        {
            this.logger = new Logger();
            this.patientService = new PatientService();
            this.clinicService = new ClinicService();
            this.appointmentService = new AppointmentService(this.patientService, this.clinicService);
        }

        public IAppointmentService GetAppointmentService()
        {
            return this.appointmentService;
        }
        public IPatientService GetPatientService()
        {
            return this.patientService;
        }
        public IClinicService GetClinicService()
        {
            return this.clinicService;
        }
    }
}
