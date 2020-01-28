using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfDatabaseFilmInfo.DataAccess;
using WpfDatabaseFilmInfo.Entities;

namespace WpfDatabaseFilmInfo.Biz
{
    public class ClassBiz
    {
        private List<Movie> movies = new List<Movie>();
        MovieDBAccess movieDB = new MovieDBAccess();

        public Movie GetFirstMovie()
        {
            List<Movie> movies = new List<Movie>();
            movies = movieDB.GetAllMovies();
            return movies[0];
        }

        public string MovieToTextString(TextBlock textBlock, Movie movie )
        {            
            return $"id: {movie.Id} \ntitel: {movie.Titel} \nland: {movie.Land} \når: {movie.Year} \ngenre: {movie.Genre} \noscars: {movie.Oscars}";
        }

        public void MoviesToTextBlock(TextBlock textBlock, List<Movie> movies)
        {
            string TextToDisplay = "";
            textBlock.Text = TextToDisplay;
                
            foreach (Movie movie in movies)
            {
                TextToDisplay = TextToDisplay + MovieToTextString(textBlock, movie) + "\n";
            }

            textBlock.Text = TextToDisplay;
        }

        public List<Movie> SearchDB(TextBox titel, TextBox land, TextBox year, TextBox genre, TextBox oscars)
        {
            string searchString ="";

            searchString = SearchStringFill(titel, searchString, "titel");
            searchString = SearchStringFill(land, searchString, "land");
            searchString = SearchStringFill(year, searchString, "year");
            searchString = SearchStringFill(genre, searchString, "genre");
            searchString = SearchStringFill(oscars, searchString, "oscars");

            return movieDB.SearchMovies(searchString);
        }

        private string SearchStringFill(TextBox textBlock, string searchString, string nameOfSearch)
        {
            if (textBlock.Text != "" && searchString != "")
            {
                searchString = searchString + $" AND ({nameOfSearch} = '{textBlock.Text}')";
            }
            else if (textBlock.Text != "")
            {
                searchString = searchString + $" ({nameOfSearch} = '{textBlock.Text}')";
            }
            else
            {
                return searchString;
            }

            return searchString;
        }
    }
}
