using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.POCO_MODELS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    public class Copy
    {
        private int id;
        private Player owner;
        private bool isAvailable;
        private VideoGame _game;
        List<Booking> _bookings;

        public Copy()
        {
        }

        public Copy(int id, bool isAvailable)
        {
            this.id = id;
            this.isAvailable = isAvailable;
        }


        public int Id { get => id; set => id = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
        public Player Owner { get => owner; set => owner = value; }
        public List<Booking> Bookings { get => _bookings; set => _bookings = value; }
        public VideoGame Game { get => _game; set => _game = value; }

        public static Copy getCopyOfAGameWithLeastActiveBookings(int gameId)
        {
            return new CopyDAO().GetCopyWithLeastBookings(gameId);
        }
    }
}
