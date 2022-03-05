namespace SampleDataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The sample data contract.
    /// </summary>
    [DataContract]
    public class SampleDataContract
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the sample property.
        /// </summary>
        [DataMember]
        public string SampleProperty { get; set; }
    }
}