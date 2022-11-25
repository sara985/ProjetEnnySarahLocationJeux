using ProjetEnnySarahLocationJeux.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjetEnnySarahLocationJeux.POCO
{
    internal class Player : User
    {
        //Question peut-on ajouter une instance de DAO afin de ne pas avoir à l'instancier à chaque fois ?
        private int id;
        private string firstName;
        private string lastName;
        private DateOnly birthDate;
        private DateOnly signUpDate;
        private string email;
        private int balance;

        //TODO ask question to teacher
        public Player(string username, string password)
        {
            base.Password = password;
            base.Username = username;
            base.CalculateSHA256();
        }

        public Player()
        {
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateOnly BirthDate { get => birthDate; set => birthDate = value; }
        public DateOnly SignUpDate { get => signUpDate; set => signUpDate = value; }
        public string Email { get => email; set => email = value; }
        public int Balance { get => balance; set => balance = value; }

        public override User Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        //public static List<Player> GetPlayers()
        //{
        //    PlayerDAO dao = new PlayerDAO();
        //    //return db.GetMovies();
        //    // return dao.Get ;
        //}
        public bool Insert()
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.Insert(this);
        }

        public static Player GetPlayerByUsername(string username)
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.GetByUsername(username);
        }
    }
}
