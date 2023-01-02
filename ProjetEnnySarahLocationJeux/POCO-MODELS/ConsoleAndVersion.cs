using ProjetEnnySarahLocationJeux.DAO;
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
        private int versionId;
        private string version;

        public ConsoleAndVersion()
        {
        }

        public ConsoleAndVersion(string console)
        {
            this.console = console;
        }

        public ConsoleAndVersion(string version, int idConsole)
        {
            this.version=version;
            this.idConsole = idConsole;
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

        public override string? ToString()
        {
            return console;
        }


        public int VersionId { get => versionId; set => versionId = value; }

        public static List<ConsoleAndVersion> GetAllConsoles()
        {
            var list = new ConsoleAndVersionDAO().List().GroupBy(c => c.IdConsole);
            var finalList = new List<ConsoleAndVersion>();
            foreach (var item in list)
            {
                string consoleName="";
                System.Console.WriteLine(item.Key);
                foreach(ConsoleAndVersion c in item)
                {
                    consoleName = c.Console;
                }
                finalList.Add(new ConsoleAndVersion(item.Key,consoleName, null));

            }
            return finalList;
        }
        //todo: uncomment -> comment just to make the programme work
        public static List<ConsoleAndVersion> GetVersionsByConsole(int consoleId)
        {
            return new ConsoleAndVersionDAO().List().Where(x => x.IdConsole == consoleId).ToList();
            
        }

        
        public bool InsertConsole()
        {
            ConsoleAndVersionDAO dao = new ConsoleAndVersionDAO();
            return dao.InsertNewConsole(this);
        }

        public bool InsertVersion()
        {
            
            ConsoleAndVersionDAO dao = new ConsoleAndVersionDAO();
            return dao.InsertNewVersion(this);
        }


        
    }
}
