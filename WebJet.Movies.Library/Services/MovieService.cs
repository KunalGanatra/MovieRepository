using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebJet.Movies.Library;
using System.Linq;

namespace WebJet.Movies.Library
{
    public class MovieService : IMovieService
    {
        IMovieClient _movieClient;

        private const string CinemaWorldAbbreviation= "cw";
        private const string FilWorldAbbreviation= "fw";
        private const string CinemaWorld = "CinemaWorld";
        private const string FilmWorld = "FilmWorld";

        public MovieService(IMovieClient movieClient)
        {
            _movieClient = movieClient;
        }

        public async Task<List<Movie>> GetMovies()
        {
            var cinemaWorldMovies = await _movieClient.GetCinemaWorldMoviesAsync();

            var filmWorldMovies = await _movieClient.GetFilmWorldMoviesAsync();

            if (cinemaWorldMovies?.Count > 0)
            {
                if (filmWorldMovies?.Count > 0)
                {
                    var excludedMovies = filmWorldMovies.Where(x => !cinemaWorldMovies.Any(y => y.FormattedID == x.FormattedID))?.ToList();
                    return cinemaWorldMovies.Union(excludedMovies).OrderByDescending(x=>x.Year).ToList();
                }
                return cinemaWorldMovies.OrderByDescending(x=>x.Year).ToList();
            }
            return filmWorldMovies?.OrderByDescending(x => x.Year).ToList();
        }

        public async Task<Movie> GetMovieWithBestPrice(string movieId)
        {
            var cinemaWorldMovie = await _movieClient.GetCinemaWorldMovieByIdAsync(string.Concat(CinemaWorldAbbreviation,movieId));
            
            var filmWorldMovie = await _movieClient.GetFilmWorldMovieByIdAsync(string.Concat(FilWorldAbbreviation, movieId));

            if (cinemaWorldMovie != null)
            {
                cinemaWorldMovie.Provider = CinemaWorld;
                if (filmWorldMovie != null)
                {
                    filmWorldMovie.Provider = FilmWorld;
                    filmWorldMovie.Poster = cinemaWorldMovie.Poster;
                    return cinemaWorldMovie.Price < filmWorldMovie.Price ? cinemaWorldMovie : filmWorldMovie;
                }
                return cinemaWorldMovie;
            }
            return filmWorldMovie;

        }
    }
}
