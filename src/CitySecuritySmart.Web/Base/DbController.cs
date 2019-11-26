using  CitySecuritySmart.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CitySecuritySmart.Web
{
    public class DbController : Controller
    {
        private CSSDBContext _db;
        public CSSDBContext Db => _db ?? (CSSDBContext)HttpContext?.RequestServices.GetService(typeof(CSSDBContext));
        //Db, db null değilse _db' yi ver eğer db null ise git HttpContext? üstünden RequestServices bölümünden GetService kullanarak bana KTDBContext tipteki servisi ver.
        //HttpContext?.RequestServices.GetService(typeof(KTDBContext)) object veri döndüğü için KTDBContext cast ettim
        //Artık bu kontrolleri inheritance alanlar DB nesnesini erişime sahip olucaklar ve işlemleri gerçekleştirebilecekler.
    }
}