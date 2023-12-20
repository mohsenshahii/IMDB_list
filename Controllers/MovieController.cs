using IMDB_list.DATA;
using IMDB_list.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB_list.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<MoviesModel> movies = new List<MoviesModel>();

            MovieDAO movieDAO = new MovieDAO();

            movies = movieDAO.FetchAll();
            
            return View("Index", movies);
        }
    }
}