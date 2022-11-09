using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    //TODO maybe add user,console and version list in VideoGame
    internal class ConsoleAndVersion
    {
        private int idConsole;
        private string console;
        private List<string> versions;

        public ConsoleAndVersion(int idConsole, string console, List<string> versions)
        {
            this.idConsole = idConsole;
            this.console = console;
            this.versions = versions;
        }

        public int IdConsole { get { return idConsole; }
            set { idConsole = value; }
        }

        public string Console { get { return console; }
            set { console = value; }
        }

        public List<string> Versions { get { return versions; }
            set { versions = value; }
        }
    }
}
