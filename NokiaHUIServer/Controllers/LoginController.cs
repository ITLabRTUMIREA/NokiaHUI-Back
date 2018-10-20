using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NokiaHUIServer.Models;

namespace NokiaHUIServer.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private PacientProfileContext _profileDb;
		private ILogger<LoginController> _logger;

        public LoginController(PacientProfileContext profileDb, ILogger<LoginController> logger)
        {
            _profileDb = profileDb;
			_logger = logger;

		}

        [HttpPost("signin")]
        public IActionResult Signin([FromBody] SigninModel info)
        {
            bool signinSuccs = false;
            
			if (_profileDb.PacientProfiles.Any<PacientProfile>(p => (p.Email == info.Email && p.Passw == info.Passw)))
			{
				signinSuccs = true;
			}

            if (signinSuccs)
            {
                return StatusCode(200); // Sign in is succsessful
            }
            else
            {
                return StatusCode(401); // Sign in is unsuccsessful
            }
        }

        [HttpPost("signup")]
        public IActionResult Singup([FromBody] SignupModel info)
        {
			bool signupSuccs = true;
			if (_profileDb.PacientProfiles.Any<PacientProfile>(p => p.Email == info.Email))
			{
				signupSuccs = false;
			}
			// Find existed profile

			if (signupSuccs)
			{
				_profileDb.PacientProfiles.Add(new PacientProfile(info));
				_profileDb.SaveChanges();
				return StatusCode(201); // Sign up is succsessful
			}
			else
			{
				return StatusCode(406); // Sign up is unsuccsessful
			}
		}

		[HttpGet("signup/test/{id}")]
		public ActionResult<bool> TEST_SignUpTest(uint id)
		{
			bool result = false;
			if (_profileDb.PacientProfiles.Any(p => p.PacientProfileId == id))
			{
				result = true;
			}

			return result;
		}
	}
}