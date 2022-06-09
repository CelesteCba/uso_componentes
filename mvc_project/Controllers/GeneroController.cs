using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Models;
using mvc_project.Models.Login;

namespace mvc_project.Controllers
{
    public class GeneroController : Controller
    {
        private readonly ILogger<GeneroController> _logger;

        public GeneroController(ILogger<GeneroController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        
    }
}
