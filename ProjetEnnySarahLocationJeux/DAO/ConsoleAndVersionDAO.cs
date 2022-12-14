using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public bool InsertNewConsole(ConsoleAndVersion c)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insert into dbo.Console values (@name)", connection);
                cmd.Parameters.AddWithValue("name", c.Console);
                connection.Open();
                int i = 0;

                try
                {
                    i = cmd.ExecuteNonQuery();
                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                connection.Close();
                if (i == 1) { return true; }
                return false;

            }
        }

        internal bool InsertNewVersion(ConsoleAndVersion v)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("insert into dbo.Version values ( @consoleID, @version)", connection);
                
                cmd.Parameters.AddWithValue("consoleId", v.IdConsole);
                cmd.Parameters.AddWithValue("version", v.Version);
                connection.Open();
                int i = 0;

                try
                {
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                connection.Close();
                if (i == 1) { return true; }
                return false;

            }
        }

        public bool Insert(ConsoleAndVersion t)
        {
            throw new NotImplementedException();
        }

        public List<ConsoleAndVersion> List()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.console c join dbo.version v on c.Id = v.consoleId", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ConsoleAndVersion> list = new List<ConsoleAndVersion>();
                    while (reader.Read())
                    {
                        ConsoleAndVersion result = new ConsoleAndVersion();
                        result.IdConsole = reader.GetInt32(0);
                        result.Console = reader.GetString(1);
                        result.Version = reader.GetString(4);
                        result.VersionId = reader.GetInt32(2);
                        list.Add(result);
                    }
                    return list;
                }
                connection.Close();
            }
        }

        public List<ConsoleAndVersion> ListConsole()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.console", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<ConsoleAndVersion> listConsole = new List<ConsoleAndVersion>();
                    while (reader.Read())
                    {
                        ConsoleAndVersion result = new ConsoleAndVersion();
                        result.IdConsole = reader.GetInt32(0);
                        result.Console = reader.GetString(1);
                        listConsole.Add(result);
                    }
                    return listConsole;
                }
                connection.Close();
            }
        }

        public void Update(ConsoleAndVersion t)
        {
            throw new NotImplementedException();
        }

       
    }
}
