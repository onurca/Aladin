using Aladin.Model;
using Framework.ViewModel;
using System;
using System.Collections.Generic;

namespace Aladin.Business.Services
{
    public interface IRoomService
    {
        List<Room> Get(GridSettings settings);
        Room Get(Guid id);
        Room Create(Room model);
        void Update(Room model);
        void Delete(Guid id);
    }
}