using Aladin.Controllers;
using Aladin.Model;
using Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class RoomController : AuthenticatedController
    {
        [HttpPost]
        public JsonResult Get(GridSettings settings)
        {
            List<Room> retVal = _roomService.Get(settings);

            return Result(new GridResult<List<Room>>(retVal, retVal.Count()));
        }

        [HttpPost]
        public JsonResult Create(Room category)
        {
            _roomService.Create(category);

            return Result(new Result<Room>(category, Definition.Message.Created));
        }

        [HttpPost]
        public JsonResult Update(Room category)
        {
            _roomService.Update(category);

            return Result(new Result(Definition.Message.Updated));
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            _roomService.Delete(id);

            return Result(new Result(Definition.Message.Deleted));
        }
    }
}