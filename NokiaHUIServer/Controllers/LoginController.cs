using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NokiaHUIServer.Models;

namespace NokiaHUIServer.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost("signin")]
        public IActionResult Signin([FromBody] LoginInfo info)
        {
            
            return StatusCode(200); // Sign in is succsessful
        }

        [HttpPost("signup")]
        public IActionResult Singup([FromBody] PersonalInformation info)
        {
            
            return StatusCode(201); // Sign up is succsessful 
        }
    }
}