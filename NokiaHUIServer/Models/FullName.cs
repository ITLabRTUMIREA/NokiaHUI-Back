using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NokiaHUIServer.Models
{
    public class FullName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Optional
        public string Patronymic { get; set; }
    }
}
