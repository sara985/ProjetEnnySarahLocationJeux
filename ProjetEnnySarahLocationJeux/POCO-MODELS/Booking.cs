using ProjetEnnySarahLocationJeux.DAO;
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
        Status status;
        int duration;
        DateOnly _bookingDate;

        public Booking() { }

        public int Id { get => _id; set => _id = value; }
        public Player Booker { get => _booker; set => _booker = value; }
        public Copy Copy { get => _copy; set => _copy = value; }
        public Status Status { get => status; set => status = value; }
        public int Duration { get => duration; set => duration = value; }
        public DateOnly BookingDate { get => _bookingDate; set => _bookingDate = value; }

        public bool Insert()
        {
            return new BookingDAO().Insert(this);
        }

        public static List<Booking> GetBookedCopiesForUser(int id)
        {
            return new BookingDAO().List().Where(b => b.Booker.Id == id).ToList();
        }

        public static List<Booking> GetBookingsByStatusAndUser(Status s, string username)
        {
            return new BookingDAO().List().Where(b => b.Booker.Username.Equals(username) && b.Status.Equals(s)).ToList();
        }

        public void UpdateStatus()
        {
            new BookingDAO().Update(this);
        }
    }
}
