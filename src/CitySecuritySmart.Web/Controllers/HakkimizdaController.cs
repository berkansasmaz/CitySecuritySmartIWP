
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CitySecuritySmart.Web.Controllers
{

 
    public class HakkimizdaController : SecureController
    {
        public IActionResult Ekip()
        {
            return View();
        }
    }
}