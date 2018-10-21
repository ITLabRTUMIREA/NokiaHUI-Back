using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NokiaHUIServer.Models;

namespace NokiaHUIServer.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ProfileContext _profileDb;
		private readonly ILogger<LoginController> logger;

        public LoginController(ProfileContext profileDb, ILogger<LoginController> logger)
        {
            _profileDb = profileDb;
			this.logger = logger;
		}

        [HttpPost("signin")]
		public async Task<IActionResult> Signin([FromBody] SigninModel info)
        {
            bool signinSuccs = false;
            PacientProfile pacient = await _profileDb.PacientProfiles.FirstOrDefaultAsync(p => (p.Email == info.Email && p.Passw == info.Passw));
			
			if (pacient != null)
			{

				signinSuccs = true;
			}
			
			if (signinSuccs)
			{
				await Authenticate(info.Email); // аутентификация
				return StatusCode(200); // Sign in is succsessful
            }
            else
            {
                return StatusCode(401); // Sign in is unsuccsessful
            }
        }

		[HttpPost("signout")]
		public async void Signout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}

		[HttpPost("signup")]
		public async Task<IActionResult> Singup([FromBody] SignupModel info)
        {
			bool signupSuccs = false;
			PacientProfile pacient = await _profileDb.PacientProfiles.FirstOrDefaultAsync(p => p.Email == info.Email);
			if (pacient == null)
			{
				signupSuccs = true;
			}

			if (signupSuccs)
			{
				// Add new profile into db
				_profileDb.PacientProfiles.Add(new PacientProfile(info));
				await _profileDb.SaveChangesAsync();

				await Authenticate(info.Email);

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

		private async Task Authenticate(string userName)
		{
			// создаем один claim
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
			};
			// создаем объект ClaimsIdentity
			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			// установка аутентификационных куки
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
		}
	}
}