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
                ID = o.x.ID,
                BILDIRIMID = o.x.BILDIRIMID,
                NOTIFICATION_ORDER_ID = o.x.NOTIFICATION_ORDER_ID,
                NOTIFICATION_TYPE = o.x.NOTIFICATION_TYPE,
                DOCUMENT_DATE = o.x.DOCUMENT_DATE,
                DOCUMENT_NO = o.x.DOCUMENT_NO,
                TO_GLN = o.x.TO_GLN,
                DESCRIPTION = o.x.DESCRIPTION,
                NOTIFICATION_ORDER = o._Notification_Order,

            });





            return rv.ToList();
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
                ID = o.x.ID,
                BILDIRIMID = o.x.BILDIRIMID,
                NOTIFICATION_ORDER_ID = o.x.NOTIFICATION_ORDER_ID,
                NOTIFICATION_TYPE = o.x.NOTIFICATION_TYPE,
                DOCUMENT_DATE = o.x.DOCUMENT_DATE,
                DOCUMENT_NO = o.x.DOCUMENT_NO,
                TO_GLN = o.x.TO_GLN,
                DESCRIPTION = o.x.DESCRIPTION,
                NOTIFICATION_ORDER = o._Notification_Order,

            });





            var Result = new pagination_Request_Result<NOTIFICATION_Return_Value>
            {
                rows = rv.ToList(),
                totalNotFiltered = temp.Count(),
                total = _context.NOTIFICATION.Count()
            };

            return Result;


        }
    }
}