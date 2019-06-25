using Aladin.Controllers;
using Aladin.Model;
using Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class ReservationController : AuthenticatedController
    {
        [HttpPost]
        public JsonResult Get(GridSettings settings)
        {
            List<Reservation> retVal = _reservationService.Get(settings);

            return Result(new GridResult<List<Reservation>>(retVal, retVal.Count()));
        }

        [HttpPost]
        public JsonResult Create(Reservation category)
        {
            _reservationService.Create(category);

            return Result(new Result<Reservation>(category, Definition.Message.Created));
        }

        [HttpPost]
        public JsonResult Update(Reservation category)
        {
            _reservationService.Update(category);

            return Result(new Result(Definition.Message.Updated));
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            _reservationService.Delete(id);

            return Result(new Result(Definition.Message.Deleted));
        }
    }
}