using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NokiaHUIServer.Models;

namespace NokiaHUIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
		private readonly PacientProfileContext _profileDb;

		public ProfileController(PacientProfileContext profileDb)
		{
			_profileDb = profileDb;
		}

		[HttpGet("info")]
		public IActionResult ProfileGet()
		{
			var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
			if (email == null)
			{
				var jsonErr = new JsonResult(new
				{
					Err = "User email in claim doesn't found"
				});

				jsonErr.StatusCode = 404;
				return jsonErr;
			}

			PacientProfile profile = _profileDb.PacientProfiles.FirstOrDefault(p => p.Email == email.Value);
			if (profile == null)
			{
				var jsonErr = new JsonResult(new
				{
					Err = "User email in db doesn't found"
				});

				jsonErr.StatusCode = 404;
				return jsonErr;
			}

			JsonResult jsonResult = new JsonResult(profile) { StatusCode = 200 };
			return jsonResult;
		}

		[HttpPost("info")]
		public IActionResult ProfilePost(PacientProfile reqProfile) {
			var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
			if (email == null)
			{
				var jsonErr = new JsonResult(new
				{
					Err = "User email in claim doesn't found"
				});

				jsonErr.StatusCode = 404;
				return jsonErr;
			}

			PacientProfile profile = _profileDb.PacientProfiles.FirstOrDefault(p => p.Email == email.Value);
			if (profile != null)
			{
				var jsonErr = new JsonResult(new
				{
					Err = "User email in db doesn't found"
				});

				jsonErr.StatusCode = 404;
				return jsonErr;
			}

			profile = reqProfile;

			return StatusCode(200);
		}

		[HttpPut("info")]
		public IActionResult ProfilePut(PacientProfile reqProfile)
		{
			return ProfilePost(reqProfile);
		}

		[HttpGet("medcard")]
		public IActionResult MedCardGet()
		{
			var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
			if (email == null)
			{
				var jsonErr = new JsonResult(new
				{
					Err = "User email in claim doesn't found"
				});

				jsonErr.StatusCode = 404;
				return jsonErr;
			}

			PacientProfile profile = _profileDb.PacientProfiles.FirstOrDefault(p => p.Email == email.Value);
			if (profile == null)
			{
				var jsonErr = new JsonResult(new
				{
					Err = "User email in db doesn't found"
				});

				jsonErr.StatusCode = 404;
				return jsonErr;
			}
			
			JsonResult jsonResult = new JsonResult(profile.MedCard) { StatusCode = 200 };
			return jsonResult;
		}

		[HttpPost("medcard")]
		public async Task<IActionResult> MedCardPost(MedCard reqMedCard)
		{
			var email = User.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
			if (email == null)
			{
				var jsonErr = new JsonResult(new
				{
					Err = "User email in claim doesn't found"
				});

				jsonErr.StatusCode = 404;
				return jsonErr;
			}

			PacientProfile profile = _profileDb.PacientProfiles.FirstOrDefault(p => p.Email == email.Value);
			if (profile != null)
			{
				var jsonErr = new JsonResult(new
				{
					Err = "User email in db doesn't found"
				});

				jsonErr.StatusCode = 404;
				return jsonErr;
			}


			profile.MedCard = reqMedCard;
			await _profileDb.SaveChangesAsync();

			return StatusCode(200);
		}

		[HttpPut("medcard")]
		public async Task<IActionResult> MedCardPut(MedCard reqMedCard)
		{
			var value = await MedCardPost(reqMedCard);
			return value;
		}
		
	}
}