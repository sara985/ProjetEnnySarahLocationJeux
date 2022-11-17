using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    internal class Player : User
    {
        private int id;
        private string firstName;
        private string lastName;
        private string username;
        private DateOnly birthDate;
        private DateOnly signUpDate;
        private string email;
        private string password;
        private int balance;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public DateOnly BirthDate { get => birthDate; set => birthDate = value; }
        public DateOnly SignUpDate { get => signUpDate; set => signUpDate = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Balance { get => balance; set => balance = value; }

        public override User Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
