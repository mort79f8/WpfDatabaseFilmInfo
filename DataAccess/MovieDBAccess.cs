using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDatabaseFilmInfo.Entities;

namespace WpfDatabaseFilmInfo.DataAccess
{
    public class MovieDBAccess : BaseRepository
    {

        public List<Movie> GetAllMovies()
        {
            string sql = "SELECT * FROM Film";
            DataTable dataTable = ExecuteQuery(sql);
            if (dataTable == null)
            {
                throw new InvalidOperationException($"Datatable was null. SQL string is: {sql}");
            }
            return HandleData(dataTable);
        }

        public List<Movie> SearchMovies(string searchstring)
        {
            if (searchstring == "")
            {
                return new List<Movie>();
            }
            else
            { 
                string sql = $"SELECT * FROM Film WHERE {searchstring}";
                DataTable dataTable = ExecuteQuery(sql);
                if (dataTable == null)
                {
                    throw new InvalidOperationException($"Datatable was null. SQL string is: {sql}");
                }
                return HandleData(dataTable);
            }
        }


        private List<Movie> HandleData(DataTable dataTable)
        {
            if (dataTable == null)
                return null;

            List<Movie> movies = new List<Movie>();

            foreach (DataRow row in dataTable.Rows)
            {
                movies.Add(new Movie()
                {
                    Id = (int)row["filmid"],
                    Titel = (string)row["titel"],
                    Land = (string)row["land"],
                    Year = (int)row["year"],
                    Genre = (string)row["genre"],
                    Oscars = (int)row["oscars"]
                });
            }
            return movies;
        }
    }
}
