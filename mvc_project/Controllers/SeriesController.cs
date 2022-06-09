using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Models;
using mvc_project.Models.Login;

namespace mvc_project.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ILogger<SeriesController> _logger;

        public SeriesController(ILogger<SeriesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        
    }
}
