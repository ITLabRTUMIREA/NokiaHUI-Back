using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
	public static class DoctorsInit
	{
		public static void Init(ProfileContext context)
		{
			if (!context.DoctorProfiles.Any())
			{
				context.DoctorProfiles.AddRange(
					new DoctorProfile {
						FirstName = "Abigail",
						LastName = "Smith",
						Occupation = Occupation.FamilyDoctor,
						HospitalName = "Budapest Central Hospital",
						Experience = 10
					},
					new DoctorProfile
					{
						FirstName = "John",
						LastName = "Brown",
						Occupation = Occupation.Endocrinologist,
						HospitalName = "Budapest Central Hospital",
						Experience = 10
					},
					new DoctorProfile
					{
						FirstName = "Anton",
						LastName = "Thomas",
						Occupation = Occupation.Immunologist,
						HospitalName = "Budapest Central Hospital",
						Experience = 10
					},
					new DoctorProfile
					{
						FirstName = "David",
						LastName = "Rogers",
						Occupation = Occupation.Neurologist,
						HospitalName = "Budapest Central Hospital",
						Experience = 10
					},
					new DoctorProfile
					{
						FirstName = "Emma",
						LastName = "Cox",
						Occupation = Occupation.FamilyDoctor,
						HospitalName = "Budapest Central Hospital",
						Experience = 10
					}
				);

				context.SaveChanges();
			}
		}
	}
}
