namespace Domain
{
    public interface IAppointmentTypeData
    {
        int ID { get; set; }
        string Name { get; set; }
        AppointmentData AppointmentData { get; set; }
    }
}