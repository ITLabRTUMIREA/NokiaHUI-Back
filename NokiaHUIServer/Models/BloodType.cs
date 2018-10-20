using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
    public class BloodType
    {
        public enum RhType
        {
            RhPlus,
            RhMinus
        }

        public enum AB0Type
        {
            AB0_1,
            AB0_2,
            AB0_3,
            AB0_4
        }

        public RhType Rh { get; set; }
        public AB0Type AB0 { get; set; }
    }
}
