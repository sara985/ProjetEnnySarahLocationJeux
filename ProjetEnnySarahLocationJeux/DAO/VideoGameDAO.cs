using ProjetEnnySarahLocationJeux.Interfaces;
using ProjetEnnySarahLocationJeux.POCO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetEnnySarahLocationJeux.DAO
{
    internal class VideoGameDAO : IDAOInterface<VideoGame>
    {
        private string connectionString;

        public VideoGameDAO()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["GameSwitchDB"].ConnectionString;
        }

        public VideoGame GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(VideoGame t)
        {
            throw new NotImplementedException();
        }

        public List<VideoGame> List()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from dbo.Game g join dbo.Version v on g.versionId=v.id join dbo.Console c on c.id = v.consoleId", connection);
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
                        v.ConsoleAndVersion = new ConsoleAndVersion(reader.GetInt32(5), reader.GetString(9), reader.GetString(7));
                        list.Add(v);
                    }
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
                        v.ConsoleAndVersion = new ConsoleAndVersion(reader.GetInt32(5), reader.GetString(9), reader.GetString(7));
                        list.Add(v);
                    }
                    return list;
                }
            }
        }

        public void Update(VideoGame t)
        {
            throw new NotImplementedException();
        }
    }
}
