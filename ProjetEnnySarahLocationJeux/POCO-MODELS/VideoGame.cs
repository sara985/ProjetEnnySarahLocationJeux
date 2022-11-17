using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    internal class VideoGame : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private int cost;
        private List<ConsoleAndVersion> versionsAvailable;
        //mieux vaut mettre une taille dans une liste quand on la créé => plus efficace

        public VideoGame()
        {
        }

        public VideoGame(string name, int cost, string console, string version)
        {
            this.name = name;
            this.cost = cost;
            this.versionsAvailable = new List<ConsoleAndVersion>();
        }

        public string Name { get => name; set => name = value; }

        public int Cost
        {
            get => cost;
            set
            {
                cost = value;
                OnPropertyChanged("cost");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }

}
