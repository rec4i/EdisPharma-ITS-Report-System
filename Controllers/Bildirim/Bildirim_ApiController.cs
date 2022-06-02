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
using OfficeOpenXml;
using System.Drawing;
using OfficeOpenXml.Style;

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
        [AllowAnonymous]
        [DisableRequestSizeLimit]
        [HttpPost("get_All_Notificatons_With_Pagination_New")]
        public IActionResult get_All_Notificatons_With_Pagination_New(pagenation_request x)
        {
            var a = _IBildirimService.get_All_Notificatons_With_Pagination_New(x);
            return Ok(a);
        }


        [AllowAnonymous]
        [DisableRequestSizeLimit]
        [HttpPost("get_Exel_New")]
        public IActionResult get_Exel_New([FromBody]pagenation_request x)
        {
            var users = _IBildirimService.For_Exel_Data(x).rows;

            var stream = new MemoryStream();
            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Users");
                var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                namedStyle.Style.Font.UnderLine = true;
                namedStyle.Style.Font.Color.SetColor(Color.Blue);
                const int startRow = 5;
                var row = startRow;

                //Create Headers and format them
                // worksheet.Cells["A1"].Value = "Sample";
                // using (var r = worksheet.Cells["A1:C1"])
                // {
                //     r.Merge = true;
                //     r.Style.Font.Color.SetColor(Color.White);
                //     r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                //     r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //     r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                // }

                worksheet.Cells["A4"].Value = "BİLDİRİM ID";
                worksheet.Cells["B4"].Value = "BİLDİRİM TÜRÜ";
                worksheet.Cells["C4"].Value = "DÖKÜMAN NO";
                worksheet.Cells["D4"].Value = "MİKTAR";
                worksheet.Cells["E4"].Value = "MÜŞTERİ";
                worksheet.Cells["F4"].Value = "ÜRÜN";
                worksheet.Cells["G4"].Value = "LOT NO";
                worksheet.Cells["H4"].Value = "DÖKÜMAN TARİHİ";
                worksheet.Cells["I4"].Value = "ÜRETİM TARİHİ";
                worksheet.Cells["J4"].Value = "SON KULLANMA TARİHİ";
                worksheet.Cells["K4"].Value = "QR KODU";
                worksheet.Cells["L4"].Value = "BOX SSCC";
                worksheet.Cells["M4"].Value = "PALLET SSCC";



                worksheet.Cells["A4:M4"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A4:M4"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                worksheet.Cells["A4:M4"].Style.Font.Bold = true;

                row = 5;
                foreach (var user in users)
                {
                    worksheet.Cells[row, 1].Value = user.NOTIFICATION_ORDER_ID;
                    worksheet.Cells[row, 2].Value = user.NOTIFICATION_TYPE_NAME;
                    worksheet.Cells[row, 3].Value = user.DOCUMENT_NO;
                    worksheet.Cells[row, 4].Value = user.QUANTITY;
                    worksheet.Cells[row, 5].Value = user.CUSTOMER_NAME;
                    worksheet.Cells[row, 6].Value = user.BASE_PRODUCT_NAME;
                    worksheet.Cells[row, 7].Value = user.BN;
                    worksheet.Cells[row, 8].Value = user.NOTIFICATION_ORDER_DOCUMENT_DATE;
                    worksheet.Cells[row, 9].Value = user.MD;
                    worksheet.Cells[row, 10].Value = user.XD;
                    worksheet.Cells[row, 11].Value = user.QR_CODE;
                    worksheet.Cells[row, 12].Value = user.BOX_SSCC;
                    worksheet.Cells[row, 13].Value = user.PALET_SSCC;





                    row++;
                }

                // set some core property values
                xlPackage.Workbook.Properties.Title = "User List";
                xlPackage.Workbook.Properties.Author = "Mohamad Lawand";
                xlPackage.Workbook.Properties.Subject = "User List";
                // save the new spreadsheet
                xlPackage.Save();
                // Response.Clear();
            }
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "users.xlsx");
        }

    }
}