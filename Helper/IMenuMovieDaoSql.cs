using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieCrusier.Models;

namespace MovieCrusier.Helper
{
	public interface IMenuMovieDaoSql
	{
		public List<Movies> GetMenuMovieListAdmin();
		public void AddMenuMovieAdmin(Movies movies);
		public void ModifyMenuMovieAdmin(Movies movies);
		public void DeleteMenuMovieAdmin(int movieId);
		public Movies GetMenuMovieAdminById(int? movieId);
	}
}
