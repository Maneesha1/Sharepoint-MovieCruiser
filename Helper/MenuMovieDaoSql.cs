using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MovieCrusier.Models;

namespace MovieCrusier.Helper
{
	public class MenuMovieDaoSql : IMenuMovieDaoSql
	{
		string connectionString= "Data Source = MANU\\SQLEXPRESS; Initial Catalog = MovieCruiser; Integrated Security = True; Trusted_Connection=True;";
		public void AddMenuMovieAdmin(Movies movies)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Movies(MovieName,BoxOffice,Active,Genre,HasTeaser,DateOfLaunch) Values(@MovieName,@BoxOffice,@Active,@Genre,@HasTeaser,@DateOfLaunch)", con);
				cmd.Parameters.AddWithValue("@MovieName",movies.MovieName);
				cmd.Parameters.AddWithValue("@BoxOffice", movies.BoxOffice);
				cmd.Parameters.AddWithValue("@Active", movies.Active);
				cmd.Parameters.AddWithValue("@Genre", movies.Genre);
				cmd.Parameters.AddWithValue("@HasTeaser", movies.HasTeaser);
				cmd.Parameters.AddWithValue("@DateOfLaunch", movies.DateOfLaunch);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
		public void DeleteMenuMovieAdmin(int movieId)
		{
			using(SqlConnection con=new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Movies WHERE MovieId=@MovieId", con);
				cmd.Parameters.AddWithValue("@Movieid", movieId);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
		public Movies GetMenuMovieAdminById(int? movieId)
		{
			Movies movie = new Movies();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Movies WHERE MovieId= " + movieId;
				SqlCommand cmd = new SqlCommand(sqlQuery,con);
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
		public List<Movies> GetMenuMovieListAdmin()
		{
			List<Movies> movieList = new List<Movies>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Movies", con);
				//cmd.ExecuteNonQuery();
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

		public void ModifyMenuMovieAdmin(Movies movies)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("UPDATE Movies SET MovieName=@MovieName,BoxOffice=@BoxOffice,Active=@Active,Genre=@Genre,HasTeaser=@HasTeaser,DateOfLaunch=@DateOfLaunch WHERE MovieId=@MovieId", con);
				cmd.Parameters.AddWithValue("@MovieId", movies.MovieId);
				cmd.Parameters.AddWithValue("@MovieName", movies.MovieName);
				cmd.Parameters.AddWithValue("@BoxOffice", movies.BoxOffice);
				cmd.Parameters.AddWithValue("@Active", movies.Active);
				cmd.Parameters.AddWithValue("@Genre", movies.Genre);
				cmd.Parameters.AddWithValue("@HasTeaser", movies.HasTeaser);
				cmd.Parameters.AddWithValue("@DateOfLaunch", movies.DateOfLaunch);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}

		}
	}
}
