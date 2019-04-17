using System;
using System.Collections.Generic;
using System.Text;

namespace WebJet.Movies.Library
{
    public class MovieList
    {

        public List<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public decimal Price { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string RunTime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Wroter { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string MetaScore { get; set; }
        public string Rating { get; set; }
        public string FormattedID { get { return ID.Remove(0, 2); } }
        public string Provider { get;set;}
    }
}
