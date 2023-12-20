using IMDB_list.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IMDB_list.DATA
{
    internal class MovieDAO
    {
        private string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=IMDB_LIST;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<MoviesModel> FetchAll()
        {
            List<MoviesModel> returnlist = new List<MoviesModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.imdb";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        MoviesModel movie = new MoviesModel
                        {
                            index = reader.GetInt32(0),
                            id = reader.GetString(1),
                            title = reader.GetString(2),
                            description = reader.GetString(4),
                            release_year = reader.GetInt32(5),
                            runtime = reader.GetInt32(7),
                            imdb_score = reader.GetDouble(9),
                        };

                        returnlist.Add(movie);
                    }

                }

                return returnlist;
            }
        }
    }
}