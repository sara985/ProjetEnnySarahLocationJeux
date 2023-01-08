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
                connection.Close();
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
                connection.Close();
                return true;
            }
        }

        public Player IsPlayer(string username, string pass)
        {
            //stack FIFO
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
                        p.HadBirthdayCredit = reader.GetBoolean(9);
                        return p;
                    }
                    return null;
                }
                connection.Close();
            }
        }

        internal bool UpdatePassword(Player player)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("update dbo.Player set password=@pass where id=@playerId", connection);
                cmd.Parameters.AddWithValue("pass", player.Password);
                cmd.Parameters.AddWithValue("playerId", player.Id);
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
                if (i == 1) { return true; }

                return false;
            }
        }

        public bool DeleteCopy(int idreceived)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Copy where ownerId= @idreceived", connection);
                cmd.Parameters.AddWithValue("idreceived", idreceived);
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
                if (i == 1) { return true; }
                return false;

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
                        p.HadBirthdayCredit = reader.GetBoolean(9);
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
                        p.HadBirthdayCredit = reader.GetBoolean(9);
                        return p;
                    }
                    return null;
                }
                connection.Close();
            }
        }

        public bool Insert(Player t)
        {
            //make sure first and last name are "initcap" before submitting values since initcap function is not available on sql server
            if(t.FirstName is not null && t.LastName is not null)
            {
                t.FirstName = GlobalFunction.InitCap(t.FirstName);
                t.LastName = GlobalFunction.InitCap(t.LastName);
            }
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into dbo.player values (@user,@pass,@balance,@signupDate,@bdate,@fname,@lname,LOWER(@email),@hadCredit)", connection);
                cmd.Parameters.AddWithValue("user", t.Username);
                cmd.Parameters.AddWithValue("pass", t.Password);
                cmd.Parameters.AddWithValue("balance", t.Balance);
                cmd.Parameters.AddWithValue("signupdate", t.SignUpDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("bdate", t.BirthDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("fname", t.FirstName);
                cmd.Parameters.AddWithValue("lname", t.LastName);
                cmd.Parameters.AddWithValue("email", t.Email);
                cmd.Parameters.AddWithValue("hadCredit", t.HadBirthdayCredit);
                connection.Open();
                int i = 0;
                try
                {
                    i = cmd.ExecuteNonQuery();
                } catch (Exception e)
                {
                    return false;
                }
                connection.Close();
                return i == 1;
            }
        }

        public List<Player> List()
        {
            throw new NotImplementedException();
        }


        public int NbrGamesBrwd(Player p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from dbo.Copy where ownerId=@ownerid AND isAvailable=0", connection);
                cmd.Parameters.AddWithValue("ownerid", p.Id);
                connection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }

        public int NbrGamesIamRenting(Player p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from dbo.Loan where borrowerId = @borrowerid AND effectiveEndDate>(SELECT CAST( GETDATE() AS Date ))", connection);
                cmd.Parameters.AddWithValue("borrowerid", p.Id);
                connection.Open();
                int result = (int)cmd.ExecuteScalar();
                return result;
            }
        }


        public bool UpdateEmail(Player p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE dbo.player SET email=@email where id=@id", connection);
                cmd.Parameters.AddWithValue("email", p.Email);
                cmd.Parameters.AddWithValue("id", p.Id);
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
                if (i == 1) { return true; }

                return false;
            }
        }

        public bool UpdateUserName(Player p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE dbo.player SET username=@usname where id=@id", connection);
                cmd.Parameters.AddWithValue("usname", p.Username);
                cmd.Parameters.AddWithValue("id", p.Id);
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
                if (i == 1) { return true; }

                return false;
            }
        }


        public bool DeletePlayer(Player p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Player WHERE id = @id AND NOT EXISTS (SELECT * FROM dbo.Booking WHERE borrowerId = id) AND NOT EXISTS (SELECT * FROM dbo.Copy WHERE ownerId = id AND isAvailable = 0) AND NOT EXISTS (SELECT * FROM dbo.Loan WHERE borrowerId = Player.id)", connection);
                cmd.Parameters.AddWithValue("id", p.Id);
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
                if (i == 1) { return true; }
                return false;
            }
        }



        public void Update(Player t)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update dbo.player set balance=@balance, hadBirthdayCredit=@hadCredit where id=@id", connection);
                cmd.Parameters.AddWithValue("balance", t.Balance);
                cmd.Parameters.AddWithValue("hadCredit", t.HadBirthdayCredit);
                cmd.Parameters.AddWithValue("id", t.Id);
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
