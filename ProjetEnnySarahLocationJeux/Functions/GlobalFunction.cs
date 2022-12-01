using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.Functions
{
    internal class GlobalFunction
    {
        //only works for a single word
        public static string InitCap(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
