using System;
using System.Collections.Generic;

namespace PetClinic.Models
{

    public class Owner
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string telephone { get; set; }
        public List<Pet> pets { get; set; }
        public List<Visit> visits { get; set; }

        public Owner(string firstName,string lastName,string address,string city,string telephone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.telephone = telephone;
        }
    }
}
