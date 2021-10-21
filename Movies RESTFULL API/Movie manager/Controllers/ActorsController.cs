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
    public class ActorsController : ControllerBase
    {
       // Init 
        private readonly MoviesDbContext db;

        public ActorsController(MoviesDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult GetActors()
        {
            var list = db.Actors.Include(m => m.Actors_Movies).ThenInclude(m => m.Movie).ToList();

            return Ok(list);
        }

        [HttpPost]
        public ActionResult PostActors([FromBody] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (actor == null)
            {
                return BadRequest(ModelState);
            }

            db.Add(actor);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteActor(int id)
        {
            var actor = db.Actors.First(a => a.Id == id);

            if(actor == null)
            {
                return NotFound();
            }

            db.Remove(actor);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyActor(int id, Actor actor)
        {
            if(id != actor.Id)
            {
                return NotFound();
            }

            var modifiedActor = db.Actors.First(a => a.Id == actor.Id);

            if (modifiedActor != null)
            {
                modifiedActor.Name = actor.Name;
                modifiedActor.Popularity = actor.Popularity;
                //modifiedActor.Movies = actor.Movies;

                db.SaveChanges();
            }

            return Ok();
        }
    }
}
