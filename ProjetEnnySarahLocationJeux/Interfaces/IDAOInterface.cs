using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.Interfaces
{
    internal interface IDAOInterface<T>
    {
        bool Insert(T t);

        void Update(T t);

        List<T> List();

        T GetById(int id);
    }
}
