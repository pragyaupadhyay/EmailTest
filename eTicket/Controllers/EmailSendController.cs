using eTicket.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Controllers
{
    [Route("api/registration/[controller]")]
    [ApiController]
    public class EmailSendController : ControllerBase
    {
        private readonly EmailService;

        public EmailSendController()
        {
            var detail = _emilService.Get();
        }

    }
}
