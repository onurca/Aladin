using Aladin.Data.Enum;
using Framework.Model;
using System;

namespace Aladin.Data
{
    public class Reservation : AuditableEntity
    {
        public Guid RoomID { get; set; }
        public Guid CustomerID { get; set; }
        public bool IsPaid { get; set; }
        public ReservationStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public double Fee { get; set; }
        public double Paid { get; set; }
        public double Balance
        {
            get
            {
                return Fee - Paid;
            }
        }
        public DateTime Entry { get; set; }
        public DateTime Departure { get; set; }
    }
}
