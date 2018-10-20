using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
    public class PersonalInformation
    {
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        // Optional
        public string OptionalNumber { get; set; }
        public LoginInfo Login { get; set; }
    }
}
