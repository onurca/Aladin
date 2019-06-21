using Aladin.Business.Services.Common;
using Framework;
using Framework.Core;
using Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using DB = Aladin.Data;
using M = Aladin.Model;

namespace Aladin.Business.Services
{
    public class CategoryService : Service, ICategoryService
    {
        IRepository<DB.Category> _categoryRepo;

        public CategoryService()
        {
            _categoryRepo = UnitOfWork.GetRepository<DB.Category>();
        }

        public M.Category Create(M.Category model)
        {
            var category = new DB.Category()
            {
                Name = model.Name
            };

            _categoryRepo.Create(category);

            UnitOfWork.SaveChanges();

            model.ID = category.ID;

            return model;
        }

        public void Delete(Guid id)
        {
            _categoryRepo.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public List<M.Category> Get(GridSettings settings)
        {
            var list = _categoryRepo.GetAll().FullTextSearch(settings.Keyword);

            var retVal = list.OrderBy(settings.OrderBy).Paginate(settings).Select(x => new M.Category()
            {
                ID = x.ID,
                Name = x.Name
            });

            return retVal.ToList();
        }

        public M.Category Get(Guid id)
        {
            var item = _categoryRepo.GetById(id);

            return new M.Category()
            {
                ID = item.ID,
                Name = item.Name
            };
        }

        public void Update(M.Category model)
        {
            var item = _categoryRepo.GetById(model.ID);
            item.Name = model.Name;
            _categoryRepo.Update(item);
            UnitOfWork.SaveChanges();
        }
    }
}
