using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMOBase.Domain.Models;
using MMOBase.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MMOBase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionController : ControllerBase
    {
        private readonly MMOBaseContext db = new MMOBaseContext();

        // GET: api/Champion
        [HttpGet]
        public ActionResult<List<Champion>> GetChampions()
        {
            return Ok(db.Champions.ToList());
        }

        // GET: api/Champion/5
        [HttpGet("{id}")]
        public ActionResult<Champion> Get(int id)
        {
            return Ok(db.Champions.Find(id));
        }

        // POST: api/Champion
        [HttpPost]
        public ActionResult<Champion> Post([FromBody] Champion Champion)
        {
            db.Champions.Add(Champion);
            db.SaveChanges();
            return Ok(Champion);
        }

        // PUT: api/Champion/5
        [HttpPut("{id}")]
        public ActionResult<Champion> Put(int id, [FromBody] Champion Champion)
        {
            Champion _Champion = db.Champions.Find(id);
            if (_Champion is null)
                return Conflict("Champion not found");
            else
            {
                _Champion = Champion;
                return Ok(db.SaveChanges());
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Champion> Delete(int id)
        {
            Champion Champion = db.Champions.Find(id);
            if (Champion is null)
                return Conflict("Champion not found");
            else
                return Ok(db.Champions.Remove(Champion));

        }
    }
}
