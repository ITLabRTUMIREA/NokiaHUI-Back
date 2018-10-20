using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
	public class PacientProfile
	{
		public PacientProfile()
		{

		}

		public PacientProfile(SignupModel info)
		{
			FirstName = info.FirstName;
			LastName = info.LastName;
			Email = info.Email;
			Passw = info.Passw;
			PhoneNumber = info.PhoneNumber;
			BirthDay = info.BirthDay;
		}
		
		public PacientProfile(string firstName,
			string lastName,
			string email,
			string passw,
			string phoneNumber,
			string additionalPhoneNumber,
			string birthDay,
			string address,
			MedCard medCard)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Passw = passw;
			PhoneNumber = phoneNumber;
			AdditionalPhoneNumber = additionalPhoneNumber;
			BirthDay = birthDay;
			Address = address;
			MedCard = medCard;
		}

		public int PacientProfileId { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Email { get; set; }
		public string Passw { get; set; }
		public string PhoneNumber { get; set; }
		public string AdditionalPhoneNumber { get; set; }
		public string BirthDay { get; set; }
		public string Address { get; set; }

		public int MedCardId { get; set; }
		public MedCard MedCard { get; set; }
	}
}
