using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
	public class ProfileContext : DbContext
	{
		public ProfileContext(DbContextOptions<ProfileContext> options)
			: base(options)
		{

		}

		public DbSet<PacientProfile> PacientProfiles { get; set; }
		public DbSet<DoctorProfile> DoctorProfiles { get; set; }
	}
}
