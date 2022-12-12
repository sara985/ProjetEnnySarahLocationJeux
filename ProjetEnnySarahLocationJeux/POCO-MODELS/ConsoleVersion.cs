using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.POCO
{
    //TODO maybe add user,console and version list in VideoGame
    public class ConsoleAndVersion
    {
        private int idConsole;
        private string console;
        private string version;

        public ConsoleAndVersion()
        {
        }

        public ConsoleAndVersion(int idConsole, string console, string version)
        {
            this.idConsole = idConsole;
            this.console = console;
            this.version = version;
        }

        public int IdConsole { get { return idConsole; }
            set { idConsole = value; }
        }

        public string Console { get { return console; }
            set { console = value; }
        }

        public string Version { get { return version; }
            set { version = value; }
        }
    }
}
