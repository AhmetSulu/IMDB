using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB
{
    class Movie
    {
        // Movie sınıfı için propertyler
        public double ImdbRating { get; set; }
        public string FilmName { get; set; }

        // Kurucu metod (Constructor)
        public Movie(double imdbRating, string filmName)
        {
            ImdbRating = imdbRating;
            FilmName = filmName;
        }

        // Movie nesnesinin bilgilerini döndüren method
        public override string ToString()
        {
            // Movie nesnesinin bilgilerini formatlı bir şekilde döndürür
            return $"Film Name: {FilmName}, IMDB Rating: {ImdbRating}";
        }
    }
}