using eTicket.Models;
using eTicket.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using eTicket.Data;


namespace eTicket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;



        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;


        }
        public async Task<ViewResult>Index()
        
        
        {
            UserEmailOptions options = new UserEmailOptions
            {

                 PlaceHolders = new List<KeyValuePair<string, string>>()
                 {
                    new KeyValuePair<string, string>("{{UserName}}","pragyaupad")
                 }
                
            };


             await _emailService.SendEmailTemplate(options);

             return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
