using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
	public class MedCard
	{
		public int MedCardId { get; set; }

		public int Grow { get; set; }
		public int Weight { get; set; }
		public string AB0 { get; set; } // blood { 1, ..., 4 }
		public string Rh { get; set; } // blood { Rh+, Rh- }
		public string MedHistory { get; set; }
		public string HospitalName { get; set; }

		public int PacientProfileId { get; set; }
	}
}
