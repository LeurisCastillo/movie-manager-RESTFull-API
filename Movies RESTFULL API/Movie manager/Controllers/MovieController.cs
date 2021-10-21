using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_manager.Data;
using Movie_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviesDbContext db;

        public MovieController(MoviesDbContext db)
        {
            this.db = db;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetMovies()
        {
            //var list = db.Movie.OrderBy(m => m.Tittle).ToList();
            var list = db.Movies.Include(m => m.Actors_Movies).ThenInclude(m => m.Actor).ToList();

            return Ok(list);
        }

        //[Authorize]
        [HttpPost]
        public ActionResult PostMovies([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (movie == null)
            {
                return BadRequest(ModelState);
            }

            db.Add(movie);
            db.SaveChanges();

            return Ok();
        }

        //[Authorize]
        [HttpDelete]
        public ActionResult DeleteMovie(int id)
        {
            var movie = db.Movies.First(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            db.Remove(movie);
            db.SaveChanges();

            return Ok();
        }

        //[Authorize]
        [HttpPut]
        public ActionResult ModifyMovie(int id, Movie movie)
        {

            if (id != movie.Id)
            {
                return NotFound();
            }

            var modifiedMovie = db.Movies.First(m => m.Id == movie.Id);

            if(modifiedMovie != null)
            {
                modifiedMovie.Tittle = movie.Tittle;
                modifiedMovie.YearPublication = movie.YearPublication;
                modifiedMovie.Rating = movie.Rating;

                db.SaveChanges();
            }

                return Ok();
        }
    }
}
