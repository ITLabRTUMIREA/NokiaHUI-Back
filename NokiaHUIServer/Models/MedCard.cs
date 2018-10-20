using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
    public class MedCard
    {
        public uint Grow { get; set; }
        public BloodType Blood { get; set; }
        public FullName Name { get; set; }
    }
}
