using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
    public class Profile
    {
        public uint _Id { get; set; }
        public MedCard _MedCard { get; set; }
        public PersonalInformation _PersonalInformation { get; set; }
    }

    public class ProfileDbContext : DbContext
    {
        public ProfileDbContext(DbContextOptions<ProfileDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
    
