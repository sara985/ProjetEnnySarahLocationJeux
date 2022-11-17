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
        private DateOnly birthDate;
        private string email;

        public override User Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
