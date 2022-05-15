using System.Collections.Generic;
using Kaynak_Kod.Models.Users;
using Kaynak_Kod.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using System.Threading.Tasks;


namespace Kaynak_Kod.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EczaneListeOluşturController : ControllerBase
    {
        private IEczaneListeOluşturServices _EczaneListeOluşturServices;
        public EczaneListeOluşturController(IEczaneListeOluşturServices EczaneListeOluşturServices)
        {
            _EczaneListeOluşturServices = EczaneListeOluşturServices;
        }
        
        [AllowAnonymous]
        [HttpPost("Get_Eczane_By_City_Town_Id")]
        public IActionResult Get_Eczane_By_City_Town_Id(StringRequest city , StringRequest town)
        {

            List<City> cities=   JsonConvert.DeserializeObject<List<City>>(city.StringReq);
            List<Town> towns= JsonConvert.DeserializeObject<List<Town>>(town.StringReq);
             var x = _EczaneListeOluşturServices.Get_Eczane_By_City_Town_Id(cities,towns);

            return Ok(x);
        }
    }
}