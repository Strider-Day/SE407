using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster
{
    public static class BasicFunctions
    {
        public static Movie? GetMovieById(int movieId)
        {
            using(var context = new Se407BlockBusterContext())
            {
                return context.Movies.Find(movieId);
            }
        }

        public static Movie GetFullMovieById(int id)
        {
            using (var db = new Se407BlockBusterContext())
            {
                var movie = db.Movies
                    .Include(movies => movies.Director)
                    .Include(movies => movies.Genre)
                    .Where(movies => movies.MovieId == id)
                    .FirstOrDefault();

                return movie;
            }
        }

        public static List<Movie> GetAllMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Movies.ToList();
            }
        }

        public static List<Movie> GetAllMoviesFull() 
        {
            using (var db = new Se407BlockBusterContext())
            {
                var movies = db.Movies
                    .Include(movies => movies.Director)
                    .Include(movies => movies.Genre)
                    .ToList();

                return movies;
            }
        }

        public static List<Movie> GetCheckedOutMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Transactions.Where(t => t.CheckedIn.Equals("N")).Join
                    (
                        context.Movies,
                        t => t.MovieId,
                        m => m.MovieId,
                        (t, m) => m
                    ).ToList();
            }
        }

        public static List<Movie> GetMoviesbyGenre(String genre)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Genres.Where(g => g.GenreDescr.Equals(genre)).Join
                    (
                        context.Movies,
                        t => t.GenreId,
                        m => m.GenreId,
                        (t, m) => m
                    )
                    .ToList();
            }
        }

        public static List<Movie> GetMoviesbyDirector(String last)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Directors.Where(l => l.LastName.Equals(last)).Join
                    (
                        context.Movies,
                        t => t.DirectorId,
                        m => m.DirectorId,
                        (t, m) => m
                    ).ToList();
            }
        }

        public static List<Genre> GetAllGenres() 
        { 
            using (var db = new Se407BlockBusterContext())
            {
                return db.Genres.ToList();
            }
        }

        public static List<Director> GetAllDirectors()
        {
            using (var db = new Se407BlockBusterContext())
            {
                return db.Directors.ToList();
            }
        }
    }
}

