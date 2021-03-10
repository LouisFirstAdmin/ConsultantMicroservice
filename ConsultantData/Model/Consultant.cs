using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantData.Model
{
    public class Consultant
    {
        public Consultant()
        {

        }

        public Consultant(string firstName, string lastName, string description, string place, string email, string phone, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            Place = place;
            EmailAddress = email;
            PhoneNumber = phone;
            DateOfBirth = dateOfBirth;
        }

		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Description { get; set; }
        public string Place { get; set; }
        public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
