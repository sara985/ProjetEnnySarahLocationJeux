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
        private int _id;
        private int _year;
        private string _name;
        private int _cost;
        private ConsoleAndVersion _consoleAndVersion;
        //private List<ConsoleAndVersion> versionsAvailable;
        //mieux vaut mettre une taille dans une liste quand on la créé => plus efficace

        public VideoGame()
        {
        }

        public VideoGame(int id, int year, string name, int cost, ConsoleAndVersion consoleAndVersion)
        {
            _id = id;
            _year = year;
            _name = name;
            _cost = cost;
            _consoleAndVersion = consoleAndVersion;
        }

        public string Name { get => _name; set => _name = value; }

        public int Cost
        {
            get => _cost;
            set
            {
                _cost = value;
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
