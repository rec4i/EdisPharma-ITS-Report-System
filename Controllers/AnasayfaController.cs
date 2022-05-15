using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("/Anasayfa")]
    public class AnasayfaController : Controller
    {
        
        public IActionResult Anasayfa()
        {
            return View();
        }
       
       
 

    }
}
