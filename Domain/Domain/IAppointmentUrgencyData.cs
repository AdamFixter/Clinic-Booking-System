namespace Domain
{
    public interface IAppointmentUrgencyData
    {
        int ID { get; set; }
        string Name { get; set; }
        AppointmentData AppointmentData { get; set; }
    }
}
