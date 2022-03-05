namespace Domain
{
    public class AppointmentTypeData : IAppointmentTypeData
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual AppointmentData AppointmentData { get; set; }
    }
}
