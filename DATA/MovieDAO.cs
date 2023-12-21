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
                            Index = reader.GetInt32(0),
                            Id = reader.GetString(1),
                            Title = reader.GetString(2),
                            Description = reader.GetString(4),
                            Release_year = reader.GetInt32(5),
                            Runtime = reader.GetInt32(7),
                            Imdb_score = reader.GetDouble(9),
                        };

                        returnlist.Add(movie);
                    }

                }

                return returnlist;
            }
        }



        public MoviesModel FetchOne(int Index)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.imdb WHERE [index] = @Index";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Index", System.Data.SqlDbType.Int).Value = Index;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                MoviesModel movie = new MoviesModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        movie.Index = reader.GetInt32(0);
                        movie.Id = reader.GetString(1);
                        movie.Title = reader.GetString(2);
                        movie.Description = reader.GetString(4);
                        movie.Release_year = reader.GetInt32(5);
                        movie.Runtime = reader.GetInt32(7);
                        movie.Imdb_score = reader.GetDouble(9);
                    }

                }
                return movie;
            }
        }
    }
}