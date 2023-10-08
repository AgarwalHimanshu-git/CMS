using System.Runtime.Serialization;

namespace SampleFinalSolution.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember(Name = "id")]
        public string? Id { get; set; }
        [DataMember(Name = "firstname")]
        public string? Firstname { get; set; }
        [DataMember(Name = "gender")]
        public string? Gender { get; set; }
        [DataMember(Name = "lastname")]
        public string? Lastname { get; set; }
        [DataMember(Name = "email")]
        public string? Email { get; set; }
        [DataMember(Name = "country_code")]
        public string? Country_Code { get; set; }
        [DataMember(Name = "balance")]
        public double? Balance { get; set; }
        [DataMember(Name = "phone_Number")]
        public string? Phone_Number { get; set; }
    }
}


