using eTicket.Data;
using eTicket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class ProducersController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProducersController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Producer> GetProducers(string likeName)
        {
            if (string.IsNullOrEmpty(likeName))
                return _db.Producers.ToList();
            else
                return _db.Producers.Where(x => x.FullName.Contains(likeName)).ToList();
        }

        [HttpGet("{Id}")]

        public Producer GetbyId(int Id)
        {
            return _db.Producers.FirstOrDefault(x => x.Id == Id);
        }
    }
}
