using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicket.Data;
using eTicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Authorize]
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly AppDbContext _db;
        public CinemaController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<Cinema> GetCinema(string likeName)
        {
            if (string.IsNullOrEmpty(likeName))
                return _db.Cinemas.ToList();
            else
                return _db.Cinemas.Where(x => x.Name.Contains(likeName)).ToList();
        }

        [HttpGet("{Id}")]
        public Cinema GtbyId(int Id)
        {
            return _db.Cinemas.FirstOrDefault(x => x.Id == Id);
        }

        [HttpPost]

        public Cinema Post(Cinema a)
        {
            _db.Cinemas.Add(a);
            _db.SaveChanges();
            return _db.Cinemas.FirstOrDefault(x => x.Id == a.Id);
        }
        [HttpDelete("{Id}")]

        public Cinema Delete(int Id)
        {
            var a = _db.Cinemas.Find(Id);
            _db.Cinemas.Remove(a);
            _db.SaveChanges();
            return a;
        }

        [HttpPut("{Id}")]

        public Cinema Put(int Id, Cinema a)
        {
            _db.Entry(a).State = EntityState.Modified;
            _db.SaveChanges();
            return a;
        }
    }
}