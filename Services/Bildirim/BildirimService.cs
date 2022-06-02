using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Authorization;
using KaynakKod.Models.pagenation_request;

namespace qrmenu.Services
{
    public interface IBildirimService
    {
        List<NOTIFICATION_Return_Value> get_All_Notificatons();


        pagination_Request_Result<NOTIFICATION_Return_Value> get_All_Notificatons_With_Pagination(pagenation_request x);
        pagination_Request_Result<NOTIFICATION_Return_Value> get_All_Notificatons_With_Pagination_New(pagenation_request x);

        pagination_Request_Result<NOTIFICATION_Return_Value> For_Exel_Data(pagenation_request x);


        //get_All_Notificatons_With_Pagination_New

    }
    public class BildirimService : IBildirimService
    {


        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public BildirimService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }


        public List<NOTIFICATION_Return_Value> get_All_Notificatons()
        {
            var temp = (from x in _context.NOTIFICATION

                        join _Notification_Order in _context.NOTIFICATION_ORDER
                        on x.NOTIFICATION_ORDER_ID equals _Notification_Order.ID
                        select new
                        {
                            x,
                            _Notification_Order
                        }

            );


            IEnumerable<NOTIFICATION_Return_Value> rv = temp.Select(o => new NOTIFICATION_Return_Value
            {
                // ID = o.x.ID,
                // BILDIRIMID = o.x.BILDIRIMID,
                // NOTIFICATION_ORDER_ID = o.x.NOTIFICATION_ORDER_ID,
                // NOTIFICATION_TYPE = o.x.NOTIFICATION_TYPE,
                // DOCUMENT_DATE = o.x.DOCUMENT_DATE,
                // DOCUMENT_NO = o.x.DOCUMENT_NO,
                // TO_GLN = o.x.TO_GLN,
                // DESCRIPTION = o.x.DESCRIPTION,
                // NOTIFICATION_ORDER = o._Notification_Order,

            });





            return rv.ToList();
        }
        public pagination_Request_Result<NOTIFICATION_Return_Value> get_All_Notificatons_With_Pagination_New(pagenation_request request)
        {
            var temp = (from x in _context.NOTIFICATION_ORDER_STOCK_HISTORY

                        join _Notification_Order in _context.NOTIFICATION_ORDER
                        on x.NOTIFICATION_ORDER_ID equals _Notification_Order.ID

                        join _STOCK in _context.STOCK
                        on x.STOCK_ID equals _STOCK.ID

                        join _CUSTOMER in _context.CUSTOMER
                        on _Notification_Order.CUSTOMER_ID equals _CUSTOMER.ID

                        join _BASE_PRODUCT in _context.BASE_PRODUCT
                        on _Notification_Order.PRODUCT_ID equals _BASE_PRODUCT.ID

                        join _NOTIFICATION_TYPE in _context.NOTIFICATION_TYPE
                        on _Notification_Order.NOTIFICATION_TYPE_ID equals _NOTIFICATION_TYPE.ID

                        where _Notification_Order.DOCUMENT_DATE >= request.Start_Date && _Notification_Order.DOCUMENT_DATE <= request.End_date

                        select new
                        {
                            x,
                            _Notification_Order,
                            _STOCK,
                            _CUSTOMER,
                            _BASE_PRODUCT,
                            _NOTIFICATION_TYPE
                        }

            );
            
            
    


            var skiped_Temp=temp    
            .Skip(Convert.ToInt32(request.offset)).Take(Convert.ToInt32(request.limit))
            .ToList();


            IEnumerable<NOTIFICATION_Return_Value> rv = skiped_Temp.Select(o => new NOTIFICATION_Return_Value
            {
                NOTIFICATION_ORDER_ID = o._Notification_Order.ID,
                NOTIFICATION_TYPE_NAME = o._NOTIFICATION_TYPE.NAME,
                DOCUMENT_NO = o._Notification_Order.DOCUMENT_NO,
                QUANTITY = o._Notification_Order.QUANTITY,
                CUSTOMER_NAME = o._CUSTOMER.NAME,
                BASE_PRODUCT_NAME = o._BASE_PRODUCT.NAME,
                BN = o._STOCK.BN,
                NOTIFICATION_ORDER_DOCUMENT_DATE = Convert.ToDateTime(o._Notification_Order.DOCUMENT_DATE).ToString("yyyy-MM-dd"),
                MD = Convert.ToDateTime(o._STOCK.MD).ToString("yyyy-MM-dd"),
                XD = Convert.ToDateTime(o._STOCK.XD).ToString("yyyy-MM-dd"),
                BOX_SSCC = o._STOCK.BOX_SSCC,
                PALET_SSCC = o._STOCK.PALET_SSCC,


            });





            var Result = new pagination_Request_Result<NOTIFICATION_Return_Value>
            {
                rows = rv.ToList(),
                totalNotFiltered = skiped_Temp.Count(),
                total = temp.Count() // temp.Count()
            };

            return Result;


        }

        public pagination_Request_Result<NOTIFICATION_Return_Value> get_All_Notificatons_With_Pagination(pagenation_request request)
        {
            var temp = (from x in _context.NOTIFICATION

                        join _Notification_Order in _context.NOTIFICATION_ORDER
                        on x.NOTIFICATION_ORDER_ID equals _Notification_Order.ID

                        select new
                        {
                            x,
                            _Notification_Order
                        }

            ).Skip(Convert.ToInt32(request.offset)).Take(Convert.ToInt32(request.limit)).ToList();


            IEnumerable<NOTIFICATION_Return_Value> rv = temp.Select(o => new NOTIFICATION_Return_Value
            {
                //    NOTIFICATION_ORDER_ID=o._Notification_Order.ID,
                //    NOTIFICATION_TYPE_NAME=o.

            });





            var Result = new pagination_Request_Result<NOTIFICATION_Return_Value>
            {
                rows = rv.ToList(),
                totalNotFiltered = temp.Count(),
                total = _context.NOTIFICATION.Count()
            };

            return Result;


        }

        public pagination_Request_Result<NOTIFICATION_Return_Value> For_Exel_Data(pagenation_request request)
        {
             var temp = (from x in _context.NOTIFICATION_ORDER_STOCK_HISTORY

                        join _Notification_Order in _context.NOTIFICATION_ORDER
                        on x.NOTIFICATION_ORDER_ID equals _Notification_Order.ID

                        join _STOCK in _context.STOCK
                        on x.STOCK_ID equals _STOCK.ID

                        join _CUSTOMER in _context.CUSTOMER
                        on _Notification_Order.CUSTOMER_ID equals _CUSTOMER.ID

                        join _BASE_PRODUCT in _context.BASE_PRODUCT
                        on _Notification_Order.PRODUCT_ID equals _BASE_PRODUCT.ID

                        join _NOTIFICATION_TYPE in _context.NOTIFICATION_TYPE
                        on _Notification_Order.NOTIFICATION_TYPE_ID equals _NOTIFICATION_TYPE.ID

                        where _Notification_Order.DOCUMENT_DATE >= request.Start_Date && _Notification_Order.DOCUMENT_DATE <= request.End_date

                        select new
                        {
                            x,
                            _Notification_Order,
                            _STOCK,
                            _CUSTOMER,
                            _BASE_PRODUCT,
                            _NOTIFICATION_TYPE
                        }

            );
            


           


            IEnumerable<NOTIFICATION_Return_Value> rv = temp.Select(o => new NOTIFICATION_Return_Value
            {
                NOTIFICATION_ORDER_ID = o._Notification_Order.ID,
                NOTIFICATION_TYPE_NAME = o._NOTIFICATION_TYPE.NAME,
                DOCUMENT_NO = o._Notification_Order.DOCUMENT_NO,
                QUANTITY = o._Notification_Order.QUANTITY,
                CUSTOMER_NAME = o._CUSTOMER.NAME,
                BASE_PRODUCT_NAME = o._BASE_PRODUCT.NAME,
                BN = o._STOCK.BN,
                NOTIFICATION_ORDER_DOCUMENT_DATE = Convert.ToDateTime(o._Notification_Order.DOCUMENT_DATE).ToString("yyyy-MM-dd"),
                MD = Convert.ToDateTime(o._STOCK.MD).ToString("yyyy-MM-dd"),
                XD = Convert.ToDateTime(o._STOCK.XD).ToString("yyyy-MM-dd"),
                BOX_SSCC = o._STOCK.BOX_SSCC,
                PALET_SSCC = o._STOCK.PALET_SSCC,
                QR_CODE=o._STOCK.QR_CODE


            });





            var Result = new pagination_Request_Result<NOTIFICATION_Return_Value>
            {
                rows = rv.ToList(),
                totalNotFiltered = temp.Count(),
                total = temp.Count() // temp.Count()
            };

            return Result;
        }
    }
}