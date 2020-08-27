using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCrusier.Helper;
using MovieCrusier.Models;

namespace MovieCrusier.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMenuMovieDaoSql imenuMovieDaoSql;
        public AdminController(IMenuMovieDaoSql imenuMovieDaoSql)
        {
            this.imenuMovieDaoSql = imenuMovieDaoSql;
        }
        public IActionResult Index()
        {
            try
            {
                List<Movies> movieList = new List<Movies>();
                movieList = imenuMovieDaoSql.GetMenuMovieListAdmin().ToList();
                return View(movieList);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult AddNewMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewMovie(Movies movies)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    imenuMovieDaoSql.AddMenuMovieAdmin(movies);
                    return RedirectToAction("Index");
                }
               return View(movies);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ModifyMenuMovieAdmin(int? id)
        {
            Movies movie = imenuMovieDaoSql.GetMenuMovieAdminById(id);
            return View(movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifyMenuMovieAdmin(int id,Movies movies)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    imenuMovieDaoSql.ModifyMenuMovieAdmin(movies);
                    return RedirectToAction("Index");
                }
                return View(movies);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetMenuMovieAdminById(int? id)
        {
            try
            {
                Movies movie = imenuMovieDaoSql.GetMenuMovieAdminById(id);
                return View(movie);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult DeleteMenuMovieAdmin(int? id)
        {
            return View(imenuMovieDaoSql.GetMenuMovieAdminById(id));
        }
        [HttpPost,ActionName("DeleteMenuMovieAdmin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMenuMovieAdmin(int id)
        {
            imenuMovieDaoSql.DeleteMenuMovieAdmin(id);
            return RedirectToAction("Index");
        }
    }
}