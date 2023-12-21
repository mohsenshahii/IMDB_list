using IMDB_list.DATA;
using IMDB_list.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace IMDB_list.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            MovieDAO movieDAO = new MovieDAO();

            List<MoviesModel> movies = movieDAO.FetchAll();
            
            return View("Index", movies);
        }

        public ActionResult Details(int index)
        {
            MovieDAO movieDAO = new MovieDAO();

            MoviesModel movie = movieDAO.FetchOne(index);

            return View("Details", movie);

        }


        public ActionResult Create() 
        {
            return View("MovieForm");
        }

        public ActionResult ProcessCreate(MoviesModel movie) 
        {
            MovieDAO movieDAO = new MovieDAO();
            movieDAO.Create(movie);
            return View("Details", movie);
        }
    }
}