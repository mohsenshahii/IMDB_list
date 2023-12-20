using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB_list.Models
{
    public class MoviesModel
    {
        public int index { get; set; }
        public string id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public int release_year { get; set; }

        public int runtime { get; set; }

        public double imdb_score { get; set; }

        public MoviesModel()
        {
            index = -1;
            id = "nothing";
            title = "nothing";
            description = "nothing yet";
            release_year = 0;
            runtime = 0;
            imdb_score = 0.0;            
        }

        public MoviesModel(int index, string id, string title, string description, int release_year, int runtime, double imdb_score)
        {
            index = index;
            id = id;
            title = title;
            description = description;
            release_year = release_year;
            runtime = runtime;
            imdb_score = imdb_score;
        }
    }
}