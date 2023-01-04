using ProjetEnnySarahLocationJeux.DAO;
using ProjetEnnySarahLocationJeux.Viewmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.POCO
{
    public class VideoGame
    {
        private int _id;
        private int _year;
        private string _name;
        private int _cost;
        private string _consoleAndVersion;
        List<Copy> copies;
        bool hasCopiesAvailable;
        //private List<ConsoleAndVersion> versionsAvailable;
        //mieux vaut mettre une taille dans une liste quand on la créé => plus efficace

        public VideoGame()
        {
            RentGameCommand = new ViewModelCommand(ExecuteRentGame);
        }

        public VideoGame(int id, int year, string name, int cost, string consoleAndVersion, List<Copy> copies)
        {
            RentGameCommand = new ViewModelCommand(ExecuteRentGame);
            Id = id;
            Year = year;
            _name = name;
            Cost = cost;
            ConsoleAndVersion = consoleAndVersion;
            Copies = copies;
            hasCopiesAvailable = HasCopyAvailable();
        }
        public ICommand RentGameCommand { get; set; }

        public int Id { get => _id; set => _id = value; }
        public int Year { get => _year; set => _year = value; }
        public string Name { get => _name; set => _name = value; }
        public int Cost { get => _cost; set => _cost = value; }
        public string ConsoleAndVersion { get => _consoleAndVersion; set => _consoleAndVersion = value; }
        public List<Copy> Copies { get => copies;
            set { 
                copies = value;
                hasCopiesAvailable = HasCopyAvailable();
            }
        }
        public bool HasCopiesAvailable { get => hasCopiesAvailable; set => hasCopiesAvailable = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void ExecuteRentGame(object obj)
        {
            //actually rent the game for the user in here; for now it seems good
            MessageBox.Show(HasCopyAvailable().ToString());
        }

        public static List<VideoGame> GetAll()
        {
            VideoGameDAO dao = new VideoGameDAO();
            return dao.List(); 
        }

        public static List<VideoGame> GetGamesByConsoleVersion(int versionId)
        {
            return new VideoGameDAO().GetGamesByConsoleVersion(versionId);
        }

        public bool HasCopyAvailable()
        {
            foreach(Copy copy in Copies)
            {
                if (copy.IsAvailable)
                {
                    return true;
                }
            }
            return false;
        }


        //update 20 12 22
        public bool Insert()
        {
            VideoGameDAO dao = new VideoGameDAO();
            return dao.Insert(this);
        }

        public bool UpdateCredit()
        {
            VideoGameDAO dao = new VideoGameDAO();
            return dao.UpdateCredit(this);
        }
    }

}
