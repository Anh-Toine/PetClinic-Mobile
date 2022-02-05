using System;
namespace PetClinic.Models
{
    public class Visit
    {
        public string visitId { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public int petId { get; set; }
        public int practitionerId { get; set; }
        public bool status { get; set; }
    }
}
