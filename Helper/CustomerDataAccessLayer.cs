using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MovieCrusier.Models;

namespace MovieCrusier.Helper
{
	public class CustomerDataAccessLayer : ICustomerDataAccessLayer
	{
		string connectionString =  "Data Source = MANU\\SQLEXPRESS; Initial Catalog = MovieCruiser; Integrated Security = True; Trusted_Connection=True;";

		public void AddToFavourite(Movies movies)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Favourite(MovieName,BoxOffice,Active,Genre,HasTeaser,MovieId,DateOfLaunch) Values(@MovieName,@BoxOffice,@Active,@Genre,@HasTeaser,@MovieId,@DateOfLaunch)", con);
				cmd.Parameters.AddWithValue("@MovieName", movies.MovieName);
				cmd.Parameters.AddWithValue("@BoxOffice", movies.BoxOffice);
				cmd.Parameters.AddWithValue("@Active", movies.Active);
				cmd.Parameters.AddWithValue("@Genre", movies.Genre);
				cmd.Parameters.AddWithValue("@HasTeaser", movies.HasTeaser);
				cmd.Parameters.AddWithValue("@MovieId", movies.MovieId);
				cmd.Parameters.AddWithValue("@DateOfLaunch", movies.DateOfLaunch);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void DeleteFavouriteMovie(int favouriteId)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Favourite WHERE FavouriteId=@FavouriteId", con);
				cmd.Parameters.AddWithValue("@Favouriteid",favouriteId);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public List<Movies> GetAllActiveMovies()
		{
			List<Movies> movieList = new List<Movies>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Movies Where Active=@Active", con);
				cmd.Parameters.AddWithValue("@Active", "Yes");
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Movies movie = new Movies();
					movie.MovieId = Convert.ToInt32(rdr["MovieId"]);
					movie.MovieName = rdr["MovieName"].ToString();
					movie.BoxOffice = rdr["BoxOffice"].ToString();
					movie.Active = rdr["Active"].ToString();
					movie.Genre = rdr["Genre"].ToString();
					movie.HasTeaser = rdr["HasTeaser"].ToString();
					movie.DateOfLaunch = Convert.ToDateTime(rdr["DateOfLaunch"]);
					movieList.Add(movie);
				}
				con.Close();
			}
			return movieList;
		}

		public List<Favourite> GetAllFavouriteMovies()
		{
			List<Favourite> cartList = new List<Favourite>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Favourite", con);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Favourite favourite = new Favourite();
					favourite.FavouriteId = Convert.ToInt32(rdr["FavouriteId"]);
					favourite.MovieId = Convert.ToInt32(rdr["MovieId"]);
					favourite.MovieName = rdr["MovieName"].ToString();
					favourite.BoxOffice = rdr["BoxOffice"].ToString();
					favourite.Active = rdr["Active"].ToString();
					favourite.Genre = rdr["Genre"].ToString();
					favourite.HasTeaser = rdr["HasTeaser"].ToString();
					favourite.DateOfLaunch = Convert.ToDateTime(rdr["DateOfLaunch"]);
					cartList.Add(favourite);
				}
				con.Close();
			}
			return cartList;
		}

		public Favourite GetFavouriteMovie(int? favouriteId)
		{
			Favourite favourite = new Favourite();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Favourite WHERE FavouriteId= " + favouriteId;
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					favourite.FavouriteId = Convert.ToInt32(rdr["FavouriteId"]);
					favourite.MovieName = rdr["MovieName"].ToString();
					favourite.BoxOffice = rdr["BoxOffice"].ToString();
					favourite.Active = rdr["Active"].ToString();
					favourite.Genre = rdr["Genre"].ToString();
					favourite.HasTeaser = rdr["HasTeaser"].ToString();
					favourite.MovieId = Convert.ToInt32(rdr["MovieId"]);
					favourite.DateOfLaunch = Convert.ToDateTime(rdr["DateOfLaunch"]);
				}
				con.Close();
			}
			return favourite;
		}

		public Movies GetMenuMovieAdminById(int? movieId)
		{
			Movies movie = new Movies();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Movies WHERE MovieId= " + movieId;
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					movie.MovieId = Convert.ToInt32(rdr["MovieId"]);
					movie.MovieName = rdr["MovieName"].ToString();
					movie.BoxOffice = rdr["BoxOffice"].ToString();
					movie.Active = rdr["Active"].ToString();
					movie.Genre = rdr["Genre"].ToString();
					movie.HasTeaser = rdr["HasTeaser"].ToString();
					movie.DateOfLaunch = Convert.ToDateTime(rdr["DateOfLaunch"]);
				}
				con.Close();
			}
			return movie;
		}
	}
}
