using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    internal class Administrator : User 
    {
        private int id;
        private string email;

        public Administrator() { }
        public Administrator(string username, string password)
        {
            base.Username = username;
            base.Password = password;

        }

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }

        public override User Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        
    }
}
