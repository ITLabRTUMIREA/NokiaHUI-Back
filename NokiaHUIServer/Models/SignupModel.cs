using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
	public class SignupModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BirthDay { get; set; }
		public string Email { get; set; }
		public string Passw { get; set; }
		public string PhoneNumber { get; set; }
	}
}
