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

namespace ProjetEnnySarahLocationJeux.DAO
{
    internal class PlayerDAO : IDAOInterface<Player>
    {
        //TODO return a user or false //this works
        //public bool IsUser(string username, string pass)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("connString")))
        //    {
        //        SqlCommand cmd = new SqlCommand("Select * from dbo.player", connection);
        //        connection.Open();
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                id = reader.GetInt32(0);
        //            }
        //        }
        //        return true;
        //    }
        //}
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
            throw new NotImplementedException();
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
