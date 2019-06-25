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
    public partial class RoomController : AuthenticatedController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Item(Guid? id)
        {
            var room = id.HasValue ? _roomService.Get(id.Value) : new Model.Room();

            if (room == null)
            {
                throw new HttpException(HttpStatusCode.NotFound.ToInt(), Definition.Message.Item.NotFound);
            }

            return View(room);
        }
    }
}