using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xaml.Schema;

namespace ProjetEnnySarahLocationJeux.DAO
{
    internal class PlayerDAO : IDAOInterface<Player>
    {
        //should return a user or an admin or null
        public bool IsUser(string username, string pass)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("connString")))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.player where username=@user and password=@pass", connection);
                cmd.Parameters.AddWithValue("user", username);
                cmd.Parameters.AddWithValue("pass", pass);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player p = new Player();
                        reader.GetInt32(0);
                    }
                }
                return true;
            }
        }

        public Player GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Player t)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("connString")))
            {
                SqlCommand cmd = new SqlCommand("Insert into dbo.player values (@user,@pass,5,GETDATE(),@bdate,@fname,@lname,@email)", connection);
                cmd.Parameters.AddWithValue("user", t.Username);
                cmd.Parameters.AddWithValue("pass", t.Password);
                cmd.Parameters.AddWithValue("bdate", t.BirthDate.ToShortDateString());
                cmd.Parameters.AddWithValue("fname", t.FirstName);
                cmd.Parameters.AddWithValue("lname", t.LastName);
                cmd.Parameters.AddWithValue("email", t.Email);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Player> List()
            {
                throw new NotImplementedException();
            }

            public void Update(Player t)
            {
                throw new NotImplementedException();
            }
    }
}
