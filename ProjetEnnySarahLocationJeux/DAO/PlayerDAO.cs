using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.DAO
{
    //TODO must be changed to player but for now is good
    internal class PlayerDAO : IDAOInterface<User>
    {
        //TODO return a user or false
        public bool IsUser(string username, string pass)
        {
            return true;
        }
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User t)
        {
            throw new NotImplementedException();
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
