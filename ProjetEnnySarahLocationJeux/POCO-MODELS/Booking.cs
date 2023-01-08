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
        VideoGame _game;
        Status status;
        int duration;
        DateOnly _bookingDate;

        public Booking() { }

        public Booking(Player booker, DateOnly bookingDate)
        {
            _booker = booker;
            _bookingDate = bookingDate;
        }

        public int Id { get => _id; set => _id = value; }
        public Player Booker { get => _booker; set => _booker = value; }
        public Status Status { get => status; set => status = value; }
        public int Duration { get => duration; set => duration = value; }
        public DateOnly BookingDate { get => _bookingDate; set => _bookingDate = value; }
        public VideoGame Game { get => _game; set => _game = value; }

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

        public override bool Equals(object? obj)
        {
            //A booking is equal to another one if the booker has the same birthday, the same balance and the same signupdate and also if the booking date is the same
            if (obj is null || this == null) return false;
            if (obj is Booking b)
            {
                return b.Booker.BirthDate.Equals(this.Booker.BirthDate) && b.Booker.Balance == this.Booker.Balance && b.Booker.SignUpDate.Equals(this.Booker.SignUpDate) && b.BookingDate.Equals(this.BookingDate);
            }
            return false;
        }
    }
}
