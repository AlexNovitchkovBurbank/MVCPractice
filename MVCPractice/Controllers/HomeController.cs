using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVCPractice.Mappers;
using MVCPractice.Models;
using MVCPractice.Models.dbContext;
using MVCPractice.Processors;
using MVCPractice.Storers;
using MVCPractice.Utilities;
using MVCPractice.Validators;
using System.Diagnostics;

namespace MVCPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecordPosterProcessor recordPosterProcessor;

        public HomeController(ILogger<HomeController> logger, IRecordPosterProcessor recordPosterProcessor)
        {
            _logger = logger;
            this.recordPosterProcessor = recordPosterProcessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            ViewData["id"] = id;
            
            return View();
        }

        [HttpPost]
        public IActionResult PostUserRecord(string name)
        {
            recordPosterProcessor.Process(name);
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
