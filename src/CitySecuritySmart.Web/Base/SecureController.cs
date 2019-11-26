using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CitySecuritySmart.Web
{
    [Authorize]
    public class SecureController : Controller
    {
        
    }
}