using ProjetEnnySarahLocationJeux.Functions;
using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using System.Windows;
using System.Windows.Documents;
using System.Xaml.Schema;

namespace ProjetEnnySarahLocationJeux.DAO
{  
    internal class AdminDao : IDAOInterface<Administrator>
    {
        private string connectionString;

        public AdminDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GameSwitchDB"].ConnectionString;
        }

        public Administrator isAdmin(string username, string pass)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.Admin where username=@user and password=@pass", connection);
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", pass);
                connection.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Administrator a = new Administrator();
                        return a;
                    }
                    return null;
                }
            }
        }

        public Administrator GetByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.Admin where username=@user", connection);
                cmd.Parameters.AddWithValue("user", username);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Administrator a = new Administrator();
                        a.Id = reader.GetInt32(0);
                        a.Username = reader.GetString(1);
                        a.Password = string.Empty;
                        a.Email = reader.GetString(2);
                        return a;
                    }
                    return null;
                }
            }
        }

        public Administrator GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Administrator t)
        {
            throw new NotImplementedException();
        }

        public List<Administrator> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Administrator t)
        {
            throw new NotImplementedException();
        }
    }
}
