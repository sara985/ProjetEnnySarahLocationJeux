using ProjetEnnySarahLocationJeux.Functions;
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
        private string connectionString;

        public PlayerDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GameSwitchDB"].ConnectionString;
        }

        public bool IsUsernameAvailable(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Player WHERE Username = @username", connection);
                command.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsEmailAvailable(string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Player WHERE Email = @email", connection);
                command.Parameters.AddWithValue("@email", email);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                return true;
            }
        }

        public Player IsPlayer(string username, string pass)
        {
            //stack FIFO
            //static quand get
            //Insert(this) pour inserer, delete et update
            //pas besoin de updatesourcetrigger quand donnée ne change pas !
            //IOC Inversion of Control
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                        p.Id = reader.GetInt32(0);
                        p.Username = reader.GetString(1);
                        p.Password = string.Empty;
                        p.Balance = reader.GetInt32(3);
                        p.SignUpDate = DateOnly.FromDateTime(reader.GetDateTime(4));
                        p.BirthDate = DateOnly.FromDateTime(reader.GetDateTime(5)); 
                        p.FirstName = reader.GetString(6);
                        p.LastName = reader.GetString(7);
                        p.Email = reader.GetString(8);
                        return p;
                    }
                    return null;
                }              
            }
        }

        public Player GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.player where id=@id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player p = new Player();
                        p.Id = reader.GetInt32(0);
                        p.Username = reader.GetString(1);
                        p.Password = string.Empty;
                        p.Balance = reader.GetInt32(3);
                        p.SignUpDate = DateOnly.FromDateTime(reader.GetDateTime(4));
                        p.BirthDate = DateOnly.FromDateTime(reader.GetDateTime(5));
                        p.FirstName = reader.GetString(6);
                        p.LastName = reader.GetString(7);
                        p.Email = reader.GetString(8);
                        return p;
                    }
                    return null;
                }
            }
        }

        public Player GetByUsername(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.player where username=@user", connection);
                cmd.Parameters.AddWithValue("user", username);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Player p = new Player();
                        p.Id = reader.GetInt32(0);
                        p.Username = reader.GetString(1);
                        p.Password = string.Empty;
                        p.Balance = reader.GetInt32(3);
                        p.SignUpDate = DateOnly.FromDateTime(reader.GetDateTime(4));
                        p.BirthDate = DateOnly.FromDateTime(reader.GetDateTime(5));
                        p.FirstName = reader.GetString(6);
                        p.LastName = reader.GetString(7);
                        p.Email = reader.GetString(8);
                        return p;
                    }
                    return null;
                }
            }
        }

        public bool Insert(Player t)
        {
            //make sure first and last name are "initcap" before submitting values since initcap function is not available on sql server
            t.FirstName = GlobalFunction.InitCap(t.FirstName);
            t.LastName = GlobalFunction.InitCap(t.LastName);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into dbo.player values (@user,@pass,10,GETDATE(),@bdate,@fname,@lname,LOWER(@email))", connection);
                cmd.Parameters.AddWithValue("user", t.Username);
                cmd.Parameters.AddWithValue("pass", t.Password);
                cmd.Parameters.AddWithValue("bdate", t.BirthDate.ToShortDateString());
                cmd.Parameters.AddWithValue("fname", t.FirstName);
                cmd.Parameters.AddWithValue("lname", t.LastName);
                cmd.Parameters.AddWithValue("email", t.Email);
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
                if (i == 1)
                {
                    return true;
                }
                return false;
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
