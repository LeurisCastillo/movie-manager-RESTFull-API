using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AccountsController : ControllerBase
    {
        private readonly MoviesDbContext db;

        public AccountsController(MoviesDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult GetAccount()
        {
            var list = db.Accounts.OrderBy(ac => ac.Username).ToString();

            return Ok(list);
        }

        [HttpPost]
        public ActionResult PostAccount([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (account == null)
            {
                return BadRequest(ModelState);
            }

            db.Add(account);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteAccount(int id)
        {
            var account = db.Accounts.First(ac => ac.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            db.Remove(account);
            db.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult ModifyAccount(int id, Account account)
        {

            if (id != account.Id)
            {
                return NotFound();
            }

            var modifiedAccount = db.Accounts.First(ac => ac.Id == account.Id);

            if (modifiedAccount != null)
            {
                modifiedAccount.Username = account.Username;
                modifiedAccount.Email = account.Email;
                modifiedAccount.Password = account.Password;

                db.SaveChanges();
            }

            return Ok();
        }
    }
}
