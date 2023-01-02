using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO_MODELS
{
    public class Booking
    {
        int _id;
        Player _booker;
        Copy _copy;
        string status;
        int duration;
        DateOnly _bookingDate;

        public Booking() { }

        public int Id { get => _id; set => _id = value; }
        public Player Booker { get => _booker; set => _booker = value; }
        public Copy Copy { get => _copy; set => _copy = value; }
        public string Status { get => status; set => status = value; }
        public int Duration { get => duration; set => duration = value; }
        public DateOnly BookingDate { get => _bookingDate; set => _bookingDate = value; }
    }
}
