using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDatabaseFilmInfo.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Land { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Oscars { get; set; }

    }
}
