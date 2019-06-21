using Aladin.Model;
using Framework.ViewModel;
using System;
using System.Collections.Generic;

namespace Aladin.Business.Services
{
    public interface ICategoryService
    {
        List<Category> Get(GridSettings settings);
        Category Get(Guid id);
        Category Create(Category model);
        void Update(Category model);
        void Delete(Guid id);
    }
}