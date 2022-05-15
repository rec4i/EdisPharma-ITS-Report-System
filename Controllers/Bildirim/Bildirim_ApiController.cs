using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;
using BCryptNet = BCrypt.Net.BCrypt;
using qrmenu.Services;
using System.Net;
using System.IO;
using KaynakKod.Models.pagenation_request;

namespace qrmenu.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class Bildirim_ApiController : ControllerBase
    {
        private IBildirimService _IBildirimService;
        public Bildirim_ApiController(IBildirimService uyeIslemleriServices)
        {
            _IBildirimService = uyeIslemleriServices;
        }


        [AllowAnonymous]
        [DisableRequestSizeLimit]
        [HttpGet("get_All_Notificatons")]
        public IActionResult get_All_Notificatons()
        {
            var a = _IBildirimService.get_All_Notificatons();
            return Ok(a);
        }



        [AllowAnonymous]
        [DisableRequestSizeLimit]
        [HttpPost("get_All_Notificatons_With_Pagination")]
        public IActionResult get_All_Notificatons_With_Pagination(pagenation_request x)
        {
            var a = _IBildirimService.get_All_Notificatons_With_Pagination(x);
            return Ok(a);
        }


    }
}