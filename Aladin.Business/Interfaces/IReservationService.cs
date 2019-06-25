using Aladin.Model;
using Framework.ViewModel;
using System;
using System.Collections.Generic;

namespace Aladin.Business.Services
{
    public interface IReservationService
    {
        List<Reservation> Get(GridSettings settings);
        Reservation Get(Guid id);
        Reservation Create(Reservation model);
        void Update(Reservation model);
        void Delete(Guid id);
    }
}