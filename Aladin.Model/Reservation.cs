using Aladin.Model.Enum;
using System;

namespace Aladin.Model
{
    public class Reservation : Base
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
