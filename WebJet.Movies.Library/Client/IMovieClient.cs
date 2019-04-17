using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebJet.Movies.Library;

namespace WebJet.Movies.Library
{
    public interface IMovieClient
    {
        Task<List<Movie>> GetCinemaWorldMoviesAsync();

        Task<List<Movie>> GetFilmWorldMoviesAsync();

        Task<Movie> GetFilmWorldMovieByIdAsync(string Id);

        Task<Movie> GetCinemaWorldMovieByIdAsync(string Id);
    }
}
