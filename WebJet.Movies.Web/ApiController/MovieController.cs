using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebJet.Movies.Library;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebJet.Movies.Web
{
  [Route("api/[controller]")]
  public class MovieController : Controller
  {
    private readonly IMovieService _movieService;
    public MovieController(IMovieService movieService)
    {
      _movieService = movieService;
    }

    [HttpGet("[action]", Name = "GetMovies")]
    public async Task<JsonResult> GetMovies()
    {
      var movies = await _movieService.GetMovies();
      return Json(movies);
    }

    [HttpGet("[action]/{movieId}", Name = "GetMovieWithBestPrice")]
    public async Task<JsonResult> GetMovieWithBestPrice(string movieId)
    {
      var movie = await _movieService.GetMovieWithBestPrice(movieId);
      return Json(movie);
    }

  }
}
