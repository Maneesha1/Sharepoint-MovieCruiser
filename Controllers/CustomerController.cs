using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCrusier.Helper;
using MovieCrusier.Models;

namespace MovieCrusier.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerDataAccessLayer customerDataAccessLayer;
        public CustomerController(ICustomerDataAccessLayer customerDataAccessLayer)
        {
            this.customerDataAccessLayer = customerDataAccessLayer;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllActiveMovies()
        {
            try
            {
                List<Movies> movieList = new List<Movies>();
                movieList = customerDataAccessLayer.GetAllActiveMovies().ToList();
                return View(movieList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Favourite(int? id)
        {
            try
            {
                Movies movie = customerDataAccessLayer.GetMenuMovieAdminById(id);
                customerDataAccessLayer.AddToFavourite(movie);
                return View(movie);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllFavouriteMovies()
        {
            try
            {
                return View(customerDataAccessLayer.GetAllFavouriteMovies());
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult DeleteFavouriteMovie(int? id)
        {
            return View(customerDataAccessLayer.GetFavouriteMovie(id));
        }
        [HttpPost, ActionName("DeleteFavouriteMovie")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFavouriteMovie(int id)
        {
            customerDataAccessLayer.DeleteFavouriteMovie(id);
            return RedirectToAction("GetAllFavouriteMovies");
        }
    }
}