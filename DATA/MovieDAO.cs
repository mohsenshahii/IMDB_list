using IMDB_list.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IMDB_list.DATA
{
    internal class MovieDAO
    {
        private string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=IMDB_LIST;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        // Fetch all data 
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


        // Fetch one recoed 
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


        // Create new object
        public int CreateOrUpdate(MoviesModel movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";

                if(movie.Index <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.imdb (id, title, description, release_year, runtime, imdb_score) VALUES (@id, @title, @description, @release_year, @runtime, @imdb_score)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.imdb SET id = @id, title = @title, description = @description, release_year = @release_year, runtime = @runtime, imdb_score = @imdb_score WHERE [index] = @index";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@index", System.Data.SqlDbType.Int, 20).Value = movie.Index;
                command.Parameters.Add("@id", System.Data.SqlDbType.VarChar, 20).Value = movie.Id;
                command.Parameters.Add("@title", System.Data.SqlDbType.VarChar, 100).Value = movie.Title;
                command.Parameters.Add("@description", System.Data.SqlDbType.VarChar, 1000).Value = movie.Description;
                command.Parameters.Add("@release_year", System.Data.SqlDbType.Int).Value = movie.Release_year;
                command.Parameters.Add("@runtime", System.Data.SqlDbType.Int).Value = movie.Runtime;
                command.Parameters.Add("@imdb_score", System.Data.SqlDbType.Float).Value = movie.Imdb_score;

                connection.Open();

                int index = command.ExecuteNonQuery();

                return index;
            }
        }

        internal int Delete(int index)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM dbo.imdb WHERE [index] = @index";
                
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@index", System.Data.SqlDbType.Int, 20).Value = index;
            
                connection.Open();

                int deletedId = command.ExecuteNonQuery();

                return deletedId;
            
            }
        }

        internal List<MoviesModel> SearchForName(string searchPhrase)
        {
            List<MoviesModel> returnlist = new List<MoviesModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.imdb WHERE title LIKE @searchForME";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar, 1000).Value = "%"+searchPhrase+"%";

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
    }
}