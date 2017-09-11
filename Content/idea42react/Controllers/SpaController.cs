using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplicationBasic.Models;

namespace WebApplicationBasic.Controllers
{
    public class SpaController : Controller
    {
        public readonly AngularAppConfig _config;

        public SpaController(IOptions<AngularAppConfig> options)
        {
            
            _config = options.Value;
        }
        public IActionResult Index()
        {
            ViewBag.AngularAppConfig = _config;
            return View();
        }
    }
}
