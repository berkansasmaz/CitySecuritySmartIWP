using System.Collections.Generic;
using CitySecuritySmart.Entity;
using CitySecuritySmart.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CitySecuritySmart.Web
{
    [Route("api/v1/[controller]")]
    public class ApiController : SecureDbController
    {
      private UserManager<CSSUser> _userManager;
        public UserManager<CSSUser> UserManager => _userManager ?? (UserManager<CSSUser>)HttpContext?.RequestServices.GetService(typeof(UserManager<CSSUser>));
		public IActionResult Success(string message = default(string), object data = default(object), int code = 200){
			return Ok(
				new CSSReturn(){
					Success = true,
					Message = message,
					Data = data,
					Code = code
				}
			); //Burada JSON' da dönebilirdim farketmez zaten döneceğim datadan o bunu anlıycak.
		}

		public IActionResult Error(string message = default(string), string internalMessage = default(string), object data = default(object), int code = 400, List<CSSReturnError> errorMessage = null){
			var rv = new CSSReturn(){
					Success = false,
					//User Message
					Message = message,
					//API User Message
					InternalMessage = internalMessage,
					Data = data,
					Code = code
				};
				
			if(code == 500)
				return StatusCode(500,rv);
			if(code == 401)
				return Unauthorized();
			if(code == 403)
				return Forbid();

			return BadRequest(rv); 
		}
    }
}