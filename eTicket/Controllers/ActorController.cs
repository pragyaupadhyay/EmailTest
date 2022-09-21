using eTicket.Data;
using eTicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eTicket.Controllers
{
    [Authorize(Roles=UserRoles.Admin)]
    [Authorize]
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ActorController(AppDbContext db)
        {
            _db = db;
        }
        //Get the records from API
        [HttpGet]
        public IEnumerable<Actor> GetActor(string likeName)
        {
            if (string.IsNullOrEmpty(likeName))
                return _db.Actors.ToList();
            else
                return _db.Actors.Where(x => x.FullName.Contains(likeName)).ToList();
        }
        [HttpGet("{Id}")]
        public Actor GetbyId(int Id)
        {
            return _db.Actors.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]
        public Actor PostActor(Actor a)
        {
            _db.Actors.Add(a);
            _db.SaveChanges();
            return _db.Actors.FirstOrDefault(x => x.Id == a.Id);
        }
        [HttpDelete("{Id}")]
        public Actor Delete(int Id)
        {
            var a = _db.Actors.Find(Id);
            _db.Actors.Remove(a);
            _db.SaveChanges();
            return a;
        }

        [HttpPut("{Id}")]
        public Actor Put(int Id, Actor a)
        {
            _db.Entry(a).State = EntityState.Modified;
            _db.SaveChanges();
            return a;
        }
    }
}
