using System;
using Microsoft.AspNetCore.Mvc;

namespace CitySecuritySmart.Controllers
{
    public class HakkimizdaController : Controller
    {
        public IActionResult Ekip()
        {
            return View();
        }
    }
}
