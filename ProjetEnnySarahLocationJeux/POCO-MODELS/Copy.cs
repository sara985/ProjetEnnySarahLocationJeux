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
        private Stream image;

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
    }
}
