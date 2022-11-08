using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    abstract class User
    {
        private string username;
        private string password;

        public abstract User Login(string email, string password);
    }
}
