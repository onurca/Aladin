using Framework.Core.Extensions;
using Framework.Model.Authentication;
using Framework.ViewModel;
using Aladin.Controllers;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aladin.Business.Services;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class ReservationController : AuthenticatedController
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Item(Guid? id)
        {
            var reservation = id.HasValue ? _reservationService.Get(id.Value) : new Model.Reservation();

            if (reservation == null)
            {
                throw new HttpException(HttpStatusCode.NotFound.ToInt(), Definition.Message.Item.NotFound);
            }

            return View(reservation);
        }
    }
}