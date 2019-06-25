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
    public class RoomService : Service, IRoomService
    {
        IRepository<DB.Room> _roomRepo;

        public RoomService()
        {
            _roomRepo = UnitOfWork.GetRepository<DB.Room>();
        }

        public M.Room Create(M.Room model)
        {
            var room = new DB.Room()
            {
                Name = model.Name,
                Status = DB.Enum.RoomStatus.Ready,
                Type = (DB.Enum.RoomType)model.Type
            };

            _roomRepo.Create(room);

            UnitOfWork.SaveChanges();

            model.ID = room.ID;

            return model;
        }

        public void Delete(Guid id)
        {
            _roomRepo.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public List<M.Room> Get(GridSettings settings)
        {
            var list = _roomRepo.GetAll().FullTextSearch(settings.Keyword);

            var retVal = list.OrderBy(settings.OrderBy).Paginate(settings).Select(x => new M.Room()
            {
                ID = x.ID,
                Name = x.Name,
                Status = (M.Enum.RoomStatus)x.Status,
                Type = (M.Enum.RoomType)x.Type
            });

            return retVal.ToList();
        }

        public M.Room Get(Guid id)
        {
            var item = _roomRepo.GetById(id);

            return new M.Room()
            {
                ID = item.ID,
                Name = item.Name,
                Status = (M.Enum.RoomStatus)item.Status,
                Type = (M.Enum.RoomType)item.Type
            };
        }

        public void Update(M.Room model)
        {
            var item = _roomRepo.GetById(model.ID);
            item.Name = model.Name;
            item.Status = (DB.Enum.RoomStatus)model.Status;
            item.Type = (DB.Enum.RoomType)model.Type;
            _roomRepo.Update(item);
            UnitOfWork.SaveChanges();
        }
    }
}
