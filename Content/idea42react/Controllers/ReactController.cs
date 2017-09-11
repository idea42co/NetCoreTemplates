using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplicationBasic.Models;

namespace WebApplicationBasic.Controllers
{
    public class ReactController : Controller
    {
        public readonly ReactAppSettings _config;

        public ReactController(IOptions<ReactAppSettings> options)
        {   
            _config = options.Value;
        }
        public IActionResult Index()
        {
            ViewBag.ReactAppConfig = _config;
            return View();
        }
    }
}
