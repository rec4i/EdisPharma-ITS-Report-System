using Microsoft.AspNetCore.Mvc;

namespace Kaynak_Kod.Controllers.Eczaneİşlemleri
{
    [Route("/İş_Emirleri")]
    public class İş_EmirleriController:Controller
    {
        
        [Route("/İş_Emirleri_Raporlama")]
        public IActionResult İş_Emirleri_Raporlama()
        {
            return View();
        }
    }
}