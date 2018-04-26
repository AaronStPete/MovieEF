using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieEF.Models;
using MovieEF.MovieContext;

namespace MovieEF.Controllers
{
    public class MoviesController : ApiController
    {
        private MoviesContext db = new MoviesContext();

        // GET: api/Movies
        [HttpGet, Route("API/Movies")]
        public IQueryable<Movie> GetMovies()
        {
            return db.Movies;
        }


        // GET: api/Movies/Search?id=5
        [HttpGet, Route("API/Movies/Search")]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        //GET: api/Movies/Search?title=Jurassic
        [HttpGet, Route("API/Movies/Search")]
        ///TODO


        // PUT: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PutMovie([FromUri]int id, [FromBody]Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(movie);
        }

        // POST: api/Movies

        [HttpPost]
        [Route("API/Movies")]
        public IHttpActionResult AddMovie([FromBody]Movie movie)
        {
            using (var db = new MoviesContext())
            {
                var movieQuery = db.Movies;
                movieQuery.Add(movie);
                db.SaveChanges();
                var response = movie;
                return Ok(response);
            }
        }

        //JSON EXAMPLE
    //    {
    //    "Title": "Jurassic Park",
    //    "YearReleased": "1993-01-01T00:00:00",
    //    "Tagline": "Scary Dinos",
    //    "Rating": 10,
    //    "Genre": "Fantasy/Science fiction"
    //}


    //[ResponseType(typeof(Movie))]
    //public IHttpActionResult PostMovie(Movie movie)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    db.Movies.Add(movie);
    //    db.SaveChanges();

    //    return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
    //}

    // DELETE: api/Movies/5
    [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }
    }
}