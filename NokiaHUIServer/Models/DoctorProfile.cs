using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
	public class DoctorProfile
	{
		public int DoctorProfileId { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Occupation Occupation { get; set; }
		public string HospitalName { get; set; }
		public int Experience { get; set; } // by years
	}

}
