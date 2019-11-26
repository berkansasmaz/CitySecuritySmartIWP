using Microsoft.AspNetCore.Mvc;

namespace CitySecuritySmart.Web
{
    [Route("api/v1/[controller]")]
    public class ApiController : SecureDbController
    {
        [HttpGet]
        public IActionResult Get(){

            return Json(new
            {
                Success = true,
                Message = "Hi there!"
            });

        }
    }
}