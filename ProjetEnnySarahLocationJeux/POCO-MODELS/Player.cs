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
    public class Player : User
    {
        //Question peut-on ajouter une instance de DAO afin de ne pas avoir à l'instancier à chaque fois ?
        private int id;
        private string firstName;
        private string lastName;
        private DateOnly birthDate;
        private DateOnly signUpDate;
        private string email;
        private int balance;
        private int nbr;

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
        public int Nbr { get => nbr; set => nbr = value; }

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

        public bool IsPasswordUpdated()
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.UpdatePassword(this);
        }

        public bool DeleteCopy(int idreceived)
        {
            CopyDAO copyDAO = new CopyDAO();
            return copyDAO.DeleteCopy(idreceived);
        }

        public static Player GetPlayerById(int id)
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.GetById(id);
        }

        public int NbrGamesRented()
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.NbrGamesBrwd(this);
        }

        public int NbrGamesImRtng()
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.NbrGamesIamRenting(this);
        }

        public bool IsEmailUpdated()
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.UpdateEmail(this);
            
        }


        public bool IsUserNameUpdated()
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.UpdateUserName(this);
        }

        public bool DeletePlayer()
        {
            PlayerDAO dao = new PlayerDAO();
            return dao.DeletePlayer(this);
        }


    }
}
