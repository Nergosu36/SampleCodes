using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMOBase.Domain.Models;
using MMOBase.Persistence;

namespace MMOBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private MMOBaseContext db = new MMOBaseContext();

        // GET: api/Account
        [HttpGet]
        public ActionResult<List<Account>> GetAccounts()
        {
            return Ok(db.Accounts.ToList());
        }

        // GET: api/Account/nergosu
        [HttpGet("{login}", Name = "Get")]
        public ActionResult<Account> Get(string login)
        {
            return Ok(db.Accounts.Find(login));
        }

        // POST: api/Account
        [HttpPost]
        public ActionResult<Account> Post([FromBody] Account account)
        {
            account.CreationDate = DateTime.Now;
            db.Accounts.Add(account);
            db.SaveChanges();
            return Ok(account);
        }

        // PUT: api/Account/nergosu
        [HttpPut("{login}")]
        public ActionResult<Account> Put(string login, [FromBody] Account account)
        {
            Account _account = db.Accounts.Find(login);
            if (_account is null)
                return Conflict("Account not found");
            else
            {
                _account = account;
                return Ok(db.SaveChanges());
            }
        }

        // DELETE: api/ApiWithActions/nergosu
        [HttpDelete("{login}")]
        public ActionResult<Account> Delete(string login)
        {
            Account account = db.Accounts.Find(login);
            if (account is null)
                return Conflict("Account not found");
            else
                return Ok(db.Accounts.Remove(account));
            
        }
    }
}
