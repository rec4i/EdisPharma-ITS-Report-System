using Microsoft.AspNetCore.Mvc;

namespace Kaynak_Kod.Controllers.Eczaneİşlemleri
{
    [Route("/Eczaneİşlemleri")]
    public class EczaneİşlemleriController:Controller
    {
        
        [Route("/EczaneListesiOluştur")]
        public IActionResult EczaneListeOluştur()
        {
            return View();
        }
    }
}