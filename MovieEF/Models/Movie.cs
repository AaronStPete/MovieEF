using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieEF.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? YearReleased { get; set; }
        public string Tagline { get; set; } = "";
        public int? Rating { get; set; }
        public string Genre { get; set; }
    }
}