using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    public class VideoGame
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
            Id = id;
            Year = year;
            _name = name;
            Cost = cost;
            ConsoleAndVersion = consoleAndVersion;
        }

        public int Id { get => _id; set => _id = value; }
        public int Year { get => _year; set => _year = value; }
        public string Name { get => _name; set => _name = value; }
        public int Cost { get => _cost; set => _cost = value; }
        public ConsoleAndVersion ConsoleAndVersion { get => _consoleAndVersion; set => _consoleAndVersion = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }

}
