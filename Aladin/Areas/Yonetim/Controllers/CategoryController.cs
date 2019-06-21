using Aladin.Business.Services;
using Aladin.Controllers;
using Aladin.Model;
using Framework.Core.Extensions;
using Framework.ViewModel;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class CategoryController : AuthenticatedController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Item(Guid? id)
        {
            var _category = id.HasValue ? _categoryService.Get(id.Value) : new Category();

            if (_category == null)
            {
                throw new HttpException(HttpStatusCode.NotFound.ToInt(), Definition.Message.Item.NotFound);
            }

            return View(_category);
        }
    }
}