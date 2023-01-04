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

namespace ProjetEnnySarahLocationJeux.DAO
{
    public class BookingDAO : IDAOInterface<Booking>
    {
        private string connectionString;

        public BookingDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GameSwitchDB"].ConnectionString;
        }
        public Booking GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.Booking where id = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                return (Booking)cmd.ExecuteScalar();

            }
        }
        /*    select c.id, count(*) as co from [GameSwitch].[dbo].[Copy] c join [GameSwitch].[dbo].[Booking] b on b.copyId = c.id
              where (c.id=2 or c.id=3) and b.status='0'
              group by c.id
              order by co
        */
        public bool Insert(Booking t)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into dbo.booking values (@borrowerid,@copyid,@status,@duration,@bookingDate)", connection);
                cmd.Parameters.AddWithValue("copyid", t.Copy.Id);
                cmd.Parameters.AddWithValue("borrowerid", t.Booker.Id);
                cmd.Parameters.AddWithValue("status", t.Status.ToString());
                cmd.Parameters.AddWithValue("duration", t.Duration);
                cmd.Parameters.AddWithValue("bookingDate", t.BookingDate.ToShortDateString());
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                return true;
            }
        }

        public List<Booking> List()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PlayerDAO play = new PlayerDAO();
                CopyDAO copyDAO = new CopyDAO();
                SqlCommand cmd = new SqlCommand("select * from dbo.Booking", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Booking> list = new List<Booking>();
                    while (reader.Read())
                    {
                        Booking b = new Booking();
                        b.Id = reader.GetInt32(0);
                        b.Booker = play.GetById(reader.GetInt32(1));
                        b.Copy = copyDAO.GetById(reader.GetInt32(2));
                        b.Status = (Status)Enum.Parse(typeof(Status), reader.GetString(3));
                        b.Duration = reader.GetInt32(4);
                        b.BookingDate = DateOnly.FromDateTime(reader.GetDateTime(5));
                        list.Add(b);
                    }
                    return list;
                }
            }
        }

        public List<Booking> GetBookingsByCopyId(int copyid)
        {
            PlayerDAO play = new PlayerDAO();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from dbo.booking where copyId = @copyid", connection);
                    cmd.Parameters.AddWithValue("copyid", copyid);
                    connection.Open();
                    List<Booking> bookings = new List<Booking>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking b = new Booking();
                            b.Id = reader.GetInt32(0);
                            b.Booker = play.GetById(reader.GetInt32(1));
                            b.Copy = new Copy();
                            //b.Status = reader.GetString(3);
                            b.Duration = reader.GetInt32(4);
                            b.BookingDate = DateOnly.FromDateTime(reader.GetDateTime(5));
                            bookings.Add(b);
                        }
                    }
                    return bookings;
                }              
        }

        public void Update(Booking t)
        {
            throw new NotImplementedException();
        }
    }
}
