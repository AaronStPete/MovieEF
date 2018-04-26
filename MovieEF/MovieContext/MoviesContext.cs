using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MovieEF.Models;

namespace MovieEF.MovieContext
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(): base("name=DefaultConnection")
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
    }
}
