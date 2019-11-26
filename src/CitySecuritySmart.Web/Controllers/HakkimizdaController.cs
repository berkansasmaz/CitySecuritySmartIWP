
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CitySecuritySmart.Web.Controllers
{

    [Authorize]
    public class HakkimizdaController : Controller
    {
        public IActionResult Ekip()
        {
            return View();
        }
    }
}