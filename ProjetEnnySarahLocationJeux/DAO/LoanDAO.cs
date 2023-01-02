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
                cmd.Parameters.AddWithValue("startdate", t.StartDate.ToShortDateString());
                cmd.Parameters.AddWithValue("enddate", t.PresumedEndDate.ToShortDateString());
                cmd.Parameters.AddWithValue("credits", t.VideoGame.Cost);
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
                if (i == 1)
                {
                    return true;
                }
                return false;
            }
        }

        public List<Loan> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Loan t)
        {
            throw new NotImplementedException();
        }
    }
}
