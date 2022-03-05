namespace Domain
{
    public class SpecialtieData : ISpecialtieData
    {
        public virtual int ID { get; set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}
