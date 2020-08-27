using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieCrusier.Models;

namespace MovieCrusier.Helper
{
	public interface ICustomerDataAccessLayer
	{
		public List<Movies> GetAllActiveMovies();
		public void AddToFavourite(Movies movie);
		public Movies GetMenuMovieAdminById(int? movieId);
		public List<Favourite> GetAllFavouriteMovies();
		public Favourite GetFavouriteMovie(int? favouriteId);
		public void DeleteFavouriteMovie(int favouriteId);
	}
}
