using Aladin.Controllers;
using Aladin.Model;
using Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Aladin.Areas.Yonetim.Controllers
{
    public partial class CategoryController : AuthenticatedController
    {
        [HttpPost]
        public JsonResult Get(GridSettings settings)
        {
            List<Category> retVal = _categoryService.Get(settings);

            return Result(new GridResult<List<Category>>(retVal, retVal.Count()));
        }

        [HttpPost]
        public JsonResult Create(Category category)
        {
            _categoryService.Create(category);

            return Result(new Result<Category>(category, Definition.Message.Created));
        }

        [HttpPost]
        public JsonResult Update(Category category)
        {
            _categoryService.Update(category);

            return Result(new Result(Definition.Message.Updated));
        }

        [HttpPost]
        public JsonResult Delete(Guid id)
        {
            _categoryService.Delete(id);

            return Result(new Result(Definition.Message.Deleted));
        }
    }
}