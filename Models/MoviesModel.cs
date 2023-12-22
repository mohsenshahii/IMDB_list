using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB_list.Models
{
    public class MoviesModel
    {
        public int Index { get; set; }

        [Required]
        public string Id { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Year of release")]
        public int Release_year { get; set; }


        public int Runtime { get; set; }

        
        public double Imdb_score { get; set; }

        public MoviesModel()
        {
            Index = -1;
            Id = "nothing";
            Title = "nothing";
            Description = "nothing yet";
            Release_year = 0;
            Runtime = 0;
            Imdb_score = 0.0;            
        }

        public MoviesModel(int index, string id, string title, string description, int release_year, int runtime, double imdb_score)
        {
            Index = index;
            Id = id;
            Title = title;
            Description = description;
            Release_year = release_year;
            Runtime = runtime;
            Imdb_score = imdb_score;
        }
    }
}