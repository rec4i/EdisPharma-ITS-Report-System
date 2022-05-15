using Microsoft.AspNetCore.Mvc;

namespace Kaynak_Kod.Controllers.Eczaneİşlemleri
{
    [Route("/Bildirim")]
    public class BildirimController:Controller
    {
        
        [Route("/Bildirim_Raporlama")]
        public IActionResult Bildirim_Raporlama()
        {
            return View();
        }
    }
}