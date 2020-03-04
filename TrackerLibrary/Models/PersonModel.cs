using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public string PersonTitle
        {
            get { return Name; }
        }

        public PersonModel() {}

        public PersonModel(string name, string emailAddress, string phoneNumber)
        {
            Name = name;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }
    }
}
