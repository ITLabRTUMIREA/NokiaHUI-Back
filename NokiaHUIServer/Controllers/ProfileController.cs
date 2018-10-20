using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NokiaHUIServer.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        [HttpGet("/medcard/{id}")]
        public IActionResult MedCard(uint id)
        {
            return View();
        }
    }
}