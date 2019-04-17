using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebJet.Movies.Library
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovieWithBestPrice(string movieId);
    }
}
