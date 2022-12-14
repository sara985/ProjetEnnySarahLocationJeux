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
    public class VideoGameDAO : IDAOInterface<VideoGame>
    {
        private string connectionString;

        public VideoGameDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GameSwitchDB"].ConnectionString;
        }

        public VideoGame GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                CopyDAO copyDAO = new CopyDAO();
                SqlCommand cmd = new SqlCommand("select * from dbo.Game where id=@id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    VideoGame v = new VideoGame();
                    while (reader.Read())
                    {
                        v.Id = reader.GetInt32(0);
                        v.Name = reader.GetString(1);
                        v.Year = reader.GetInt32(2);
                        v.Cost = reader.GetInt32(3);
                        v.ConsoleAndVersion = reader.GetString(4);
                        v.Copies = copyDAO.GetByGameId(reader.GetInt32(0));
                    }
                    return v;
                }
                connection.Close();
            }
        }

        public bool Insert(VideoGame t)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into dbo.Game values (@name,@year,@creditsValued,@consoleAndVersion)", connection);
                cmd.Parameters.AddWithValue("name", t.Name);
                cmd.Parameters.AddWithValue("year", t.Year);
                cmd.Parameters.AddWithValue("creditsValued", t.Cost);
                cmd.Parameters.AddWithValue("consoleAndVersion", t.ConsoleAndVersion);
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
                connection.Close();
                if (i == 1) { return true; }
                
                return false;
            }

        }

        public List<VideoGame> List()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                CopyDAO copyDAO = new CopyDAO();
                SqlCommand cmd = new SqlCommand("select * from dbo.Game g", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<VideoGame> list = new List<VideoGame>();
                    while (reader.Read())
                    {
                        VideoGame v = new VideoGame();
                        v.Id = reader.GetInt32(0);
                        v.Name = reader.GetString(1);
                        v.Year = reader.GetInt32(2);
                        v.Cost = reader.GetInt32(3);
                        v.ConsoleAndVersion = reader.GetString(4);
                        v.Copies = copyDAO.GetByGameId(reader.GetInt32(0));
                        list.Add(v);
                    }
                    connection.Close();
                    return list;
                }
            }
        }

        public List<VideoGame> GetGamesByConsoleVersion(int versionId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.Game g join dbo.Version v on g.versionId=v.id join dbo.Console c on c.id = v.consoleId where versionId=@versionId", connection);
                cmd.Parameters.AddWithValue("versionId", versionId);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<VideoGame> list = new List<VideoGame>();
                    while (reader.Read())
                    {
                        VideoGame v = new VideoGame();
                        v.Id = reader.GetInt32(0);
                        v.Name = reader.GetString(1);
                        v.Year = reader.GetInt32(2);
                        v.Cost = reader.GetInt32(3);
                        v.ConsoleAndVersion = reader.GetString(4);
                        list.Add(v);
                    }
                    connection.Close();
                    return list;
                }
            }
        }

        public bool UpdateCredit(VideoGame g)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("update dbo.Game set creditsValued=@cost where id=@id", connection);
                cmd.Parameters.AddWithValue("cost", g.Cost);
                cmd.Parameters.AddWithValue("id",g.Id);

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
                finally
                {
                    connection.Close();
                }
                return i == 1;
            }
        }


        public void Update(VideoGame t)
        {
            throw new NotImplementedException();
        }

        public List<VideoGame> NonusedGames()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.Game where not exists(select * from dbo.Copy where dbo.Game.id=dbo.Copy.gameId)", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<VideoGame> list = new List<VideoGame>();
                    while (reader.Read())
                    {
                        VideoGame goodtogo = new VideoGame();
                        goodtogo.Id = reader.GetInt32(0);
                        goodtogo.Name = reader.GetString(1);
                        goodtogo.Year = reader.GetInt32(2);
                        goodtogo.Cost = reader.GetInt32(3);
                        goodtogo.ConsoleAndVersion = reader.GetString(4);
                        list.Add(goodtogo);
                    }
                    connection.Close();
                    return list;
                }
            }


        }
        public bool DeleteNonusedGame(VideoGame v)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("delete from dbo.Game where id=@id", connection);
                cmd.Parameters.AddWithValue("id", v.Id);
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
                finally
                {
                    connection.Close();
                }
                return i == 1;
            }
        }
    }
}
