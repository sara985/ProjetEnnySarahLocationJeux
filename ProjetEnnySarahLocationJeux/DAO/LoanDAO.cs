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
    public class LoanDAO : IDAOInterface<Loan>
    {
        private string connectionString;

        public LoanDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GameSwitchDB"].ConnectionString;
        }
        public Loan GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Loan t)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into dbo.loan values (@copyid,@borrowerid,@startdate,@enddate,NULL,@credits,NULL)", connection);
                cmd.Parameters.AddWithValue("copyid", t.Copy.Id);
                cmd.Parameters.AddWithValue("borrowerid", t.Borrower.Id);
                cmd.Parameters.AddWithValue("startdate", t.StartDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("enddate", t.PresumedEndDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("credits", t.VideoGame.Cost);
                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                return true;
            }
        }

        public List<Loan> List()
        {
            PlayerDAO play = new PlayerDAO();
            CopyDAO copyDAO = new CopyDAO();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.loan", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Loan> list = new List<Loan>();
                    while (reader.Read())
                    {
                        Loan l = new Loan();
                        l.Id = reader.GetInt32(0);
                        l.Copy = copyDAO.GetById(reader.GetInt32(1));
                        l.Borrower = play.GetById(reader.GetInt32(2));
                        l.StartDate = DateOnly.FromDateTime(reader.GetDateTime(3));
                        l.PresumedEndDate = DateOnly.FromDateTime(reader.GetDateTime(4));
                        l.EffectiveEndDate = reader.IsDBNull(5) ? (DateOnly?)null : DateOnly.FromDateTime(reader.GetDateTime(5));
                        l.CreditsValued = reader.GetInt32(6);
                        l.Total = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7);
                        list.Add(l);
                    }
                    return list;
                }
            }
        }

        public void Update(Loan t)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update dbo.loan set effectiveEndDate=@effectiveEndDate, total=@total where id=@id", connection);
                cmd.Parameters.AddWithValue("effectiveEndDate", t.EffectiveEndDate.HasValue ? t.EffectiveEndDate.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("total", t.Total);
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
