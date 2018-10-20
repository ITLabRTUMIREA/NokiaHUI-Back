using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
	public class PacientProfileContext : DbContext
	{
		public PacientProfileContext(DbContextOptions<PacientProfileContext> options)
			: base(options)
		{

		}

		public DbSet<PacientProfile> PacientProfiles { get; set; }
	}
}
