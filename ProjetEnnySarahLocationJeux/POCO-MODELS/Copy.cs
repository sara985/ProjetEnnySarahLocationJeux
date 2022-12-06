using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    internal class Copy
    {
        private int id;
        private VideoGame game;
        private Player owner;
        private bool isAvailable;
        private Stream image;

        public Copy(int id, VideoGame game, bool isAvailable)
        {
            this.id = id;
            this.game = game;
            this.isAvailable = isAvailable;
        }


        public int Id { get => id; set => id = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }

        //TODO owner encapsulation
        public VideoGame Game { get => game; set => game = value; }
    }
}
