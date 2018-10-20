using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
	public class DoctorProfileContext : DbContext
	{
		public DoctorProfileContext(DbContextOptions<DoctorProfileContext> options)
			: base(options)
		{

		}

		public DbSet<DoctorProfile> DoctorProfiles { get; set; }
	}
}
