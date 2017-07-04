using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBasic.Controllers
{
    public class SpaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
