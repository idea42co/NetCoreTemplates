using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplicationBasic.Models;

namespace WebApplicationBasic.Controllers
{
    public class AngularController : Controller
    {
        public readonly AngularAppSettings _config;

        public AngularController(IOptions<AngularAppSettings> options)
        {   
            _config = options.Value;
        }
        public IActionResult Index()
        {
            ViewBag.AngularAppSettings = _config;
            return View();
        }
    }
}
