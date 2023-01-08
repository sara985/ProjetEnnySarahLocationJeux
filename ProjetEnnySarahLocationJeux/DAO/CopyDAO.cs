using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using ProjetEnnySarahLocationJeux.POCO_MODELS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ProjetEnnySarahLocationJeux.DAO
{
    public class CopyDAO : IDAOInterface<Copy>
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
                Copy c = new();
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        c.Id = reader.GetInt32(0);
                        c.Owner = new PlayerDAO().GetById(reader.GetInt32(1));
                        c.IsAvailable = reader.GetBoolean(2);
                        //optional image, should go in videogame not copy
                    }
                }
            return c;
            }
        }

        public List<Copy> GetByGameId(int gameId)
        {
            PlayerDAO play = new PlayerDAO();
            BookingDAO booking = new BookingDAO(); 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.copy where gameid=@id", connection);
                cmd.Parameters.AddWithValue("id", gameId);
                var list = new List<Copy>();
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Copy c = new Copy();
                        c.Id = reader.GetInt32(0);
                        c.Owner = new PlayerDAO().GetById(reader.GetInt32(1));
                        c.IsAvailable = reader.GetBoolean(2);
                        c.Bookings = booking.GetBookingsByCopyId(c.Id);
                        list.Add(c);
                    }                            
                }
                return list;
            }
        }

        public Copy GetCopyWithLeastBookings(int gameid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select c.id, count(*) as NumberOfBookings from dbo.copy c join dbo.booking b on b.copyId = c.id " +
                    "where c.gameId = @gameid and b.status='Waiting'" +
                    " group by c.id " +
                    "order by NumberOfBookings", connection);
                cmd.Parameters.AddWithValue("gameid", gameid);
                connection.Open();
                Copy c = new();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        c = GetById(reader.GetInt32(0));
                    }
                }
                return c;
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update dbo.copy set isAvailable = @isAvail where id=@id", connection);
                cmd.Parameters.AddWithValue("isAvail", t.IsAvailable);
                cmd.Parameters.AddWithValue("id", t.Id);
                connection.Open();
                int i = 0;
                try
                {
                    i = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
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




    }
}
