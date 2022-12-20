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
    internal class CopyDAO : IDAOInterface<Copy>
    {
        private string connectionString;

        public CopyDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GameSwitchDB"].ConnectionString;
        }

        public Copy GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.copy where id=@id", connection);
                cmd.Parameters.AddWithValue("id", id);
                Copy c = new Copy();
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        c.Id = reader.GetInt32(0);
                        c.IsAvailable = reader.GetBoolean(2);
                    }
                }
            return c;
            }
        }

        public List<Copy> GetByGameId(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.copy where gameid=@id", connection);
                cmd.Parameters.AddWithValue("id", id);
                var list = new List<Copy>();
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Copy c = new Copy();
                        c.Id = reader.GetInt32(0);
                        c.IsAvailable = reader.GetBoolean(2);
                        list.Add(c);
                    }
                }
                return list;
            }
        }

        public bool Insert(Copy t)
        {
            throw new NotImplementedException();
        }

        public List<Copy> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Copy t)
        {
            throw new NotImplementedException();
        }
    }
}
