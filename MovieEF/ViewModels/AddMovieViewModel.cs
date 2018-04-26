using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieEF.ViewModels
{
    public class AddMovieViewModel
    {
        public string Title { get; set; }
        public DateTime? YearReleased { get; set; }
        public string Tagline { get; set; } = "";
        public int? Rating { get; set; }
        public string Genre { get; set; }
    }
}
