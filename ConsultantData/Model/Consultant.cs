using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultantData.Model
{
    public class Consultant
    {		
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
