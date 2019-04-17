using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebJet.Movies.Library;
using System.Net.Http;

namespace WebJet.Movies.Library
{
    public class MovieClient : IMovieClient
    {

        public const string ApiUrl = "http://webjetapitest.azurewebsites.net/";
        public string _token;

        public MovieClient(string token)
        {
            _token = token;
        }

        public async Task<List<Movie>> GetCinemaWorldMoviesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-access-token", _token);
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/cinemaworld/movies");
                if (response.IsSuccessStatusCode)
                {
                    var movies = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<MovieList>(movies)?.Movies;
                 }
                return null;

            }
            

        }

        public async Task<List<Movie>> GetFilmWorldMoviesAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-access-token", _token);
                HttpResponseMessage response = await client.GetAsync("api/cinemaworld/movies");
                if (response.IsSuccessStatusCode)
                {
                    var movies = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<MovieList>(movies)?.Movies;
                }
                return null;

            }

        }

        public async Task<Movie> GetFilmWorldMovieByIdAsync(string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-access-token", _token);
                HttpResponseMessage response = await client.GetAsync(String.Concat("api/filmworld/movie/", Id));
                if (response.IsSuccessStatusCode)
                {
                    var movie = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Movie>(movie);
                }
            }
            return null;

        }

        public async Task<Movie> GetCinemaWorldMovieByIdAsync(string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-access-token", _token);
                HttpResponseMessage response = await client.GetAsync(String.Concat("api/cinemaworld/movie/", Id));
                if (response.IsSuccessStatusCode)
                {
                    var movie = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Movie>(movie);

                }
            }
            return null;

        }

    }
}
