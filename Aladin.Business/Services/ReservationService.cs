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
    public class ReservationService : Service, IReservationService
    {
        IRepository<DB.Reservation> _reservationRepo;
        IRepository<DB.Room> _roomRepo;

        public ReservationService()
        {
            _reservationRepo = UnitOfWork.GetRepository<DB.Reservation>();
        }

        public M.Reservation Create(M.Reservation model)
        {
            var reservation = new DB.Reservation()
            {
                CustomerID = model.CustomerID,
                RoomID = model.RoomID,
                Departure = model.Departure,
                Entry = model.Entry,
                Paid = model.Paid,
                PaymentMethod = (DB.Enum.PaymentMethod)model.PaymentMethod,
                Status = (DB.Enum.ReservationStatus)model.Status,
                Fee = model.Fee
            };

            var room = _roomRepo.GetById(model.RoomID);
            room.Status = DB.Enum.RoomStatus.Dirty;
            _roomRepo.Update(room);

            _reservationRepo.Create(reservation);

            UnitOfWork.SaveChanges();

            model.ID = reservation.ID;

            return model;
        }

        public void Delete(Guid id)
        {
            _reservationRepo.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public List<M.Reservation> Get(GridSettings settings)
        {
            var list = _reservationRepo.GetAll().FullTextSearch(settings.Keyword);

            var retVal = list.OrderBy(settings.OrderBy).Paginate(settings).Select(x => new M.Reservation()
            {
                CustomerID = x.CustomerID,
                RoomID = x.RoomID,
                Departure = x.Departure,
                Entry = x.Entry,
                Paid = x.Paid,
                PaymentMethod = (M.Enum.PaymentMethod)x.PaymentMethod,
                Status = (M.Enum.ReservationStatus)x.Status,
                Fee = x.Fee,
                ID = x.ID
            });

            return retVal.ToList();
        }

        public M.Reservation Get(Guid id)
        {
            var item = _reservationRepo.GetById(id);

            return new M.Reservation()
            {
                CustomerID = item.CustomerID,
                RoomID = item.RoomID,
                Departure = item.Departure,
                Entry = item.Entry,
                Paid = item.Paid,
                PaymentMethod = (M.Enum.PaymentMethod)item.PaymentMethod,
                Status = (M.Enum.ReservationStatus)item.Status,
                Fee = item.Fee
            };
        }

        public void Update(M.Reservation model)
        {
            var item = _reservationRepo.GetById(model.ID);
            item.CustomerID = model.CustomerID;
             item.RoomID = model.RoomID;
            item.Departure = model.Departure;
            item.Entry = model.Entry;
            item.Paid = model.Paid;
            item.PaymentMethod = (DB.Enum.PaymentMethod)model.PaymentMethod;
            item.Status = (DB.Enum.ReservationStatus)model.Status;
            item.Fee = model.Fee;
            _reservationRepo.Update(item);
            UnitOfWork.SaveChanges();
        }
    }
}
