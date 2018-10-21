using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NokiaHUIServer.Models;

namespace NokiaHUIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
		private readonly ProfileContext _profileDb;
		public DoctorController(ProfileContext doctorProfileDb)
		{
			_profileDb = doctorProfileDb;
		}

		[Authorize]
		[HttpGet("occupations")]
		public IActionResult OccupationsGet()
		{
			string[] occupationList = Enum.GetNames(typeof(Occupation));

			var jsonResult = new JsonResult(occupationList);			
			return jsonResult;
		}

		[Authorize]
		[HttpGet]
		public IActionResult DoctorGet(string hospitalName, Occupation occupation)
		{
			DoctorProfile docProfile = _profileDb.DoctorProfiles.FirstOrDefault(
				d => d.HospitalName == hospitalName && d.Occupation == occupation);

			var jsonResult = new JsonResult(new
			{
				docProfile.FirstName,
				docProfile.LastName,
				docProfile.HospitalName,
				Occupation = docProfile.Occupation.ToString(),
				docProfile.Experience
			}) { StatusCode = docProfile == null ? 404 : 200 };
			return jsonResult;
		}
	}
}