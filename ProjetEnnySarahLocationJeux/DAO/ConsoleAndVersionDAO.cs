using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.DAO
{
    internal class ConsoleAndVersionDAO : IDAOInterface<ConsoleAndVersion>
    {
        private string connectionString;

        public ConsoleAndVersionDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GameSwitchDB"].ConnectionString;
        }
        public ConsoleAndVersion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ConsoleAndVersion t)
        {
            throw new NotImplementedException();
        }

        public List<ConsoleAndVersion> List()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.console", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ConsoleAndVersion> list = new List<ConsoleAndVersion>();
                    while (reader.Read())
                    {
                        ConsoleAndVersion result = new ConsoleAndVersion();
                        result.IdConsole = reader.GetInt32(0);
                        result.Console = reader.GetString(1);
                        list.Add(result);
                    }
                    return list;
                }
            }
        }

        public List<ConsoleAndVersion> GetVersionsByConsole(int consoleId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.version where consoleId = @id", connection);
                cmd.Parameters.AddWithValue("id", consoleId);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ConsoleAndVersion> list = new List<ConsoleAndVersion>();
                    while (reader.Read())
                    {
                        ConsoleAndVersion result = new ConsoleAndVersion();
                        result.VersionId = reader.GetInt32(0);
                        result.Version = reader.GetString(2);
                        list.Add(result);
                    }
                    return list;
                }
            }
        }

        public void Update(ConsoleAndVersion t)
        {
            throw new NotImplementedException();
        }
    }
}
