using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Models;
using mvc_project.Models.Common;
using mvc_project.Models.Login;

namespace mvc_project.Controllers
{
    public class SerieController : Controller
    {
        private readonly ILogger<SerieController> _logger;

        public SerieController(ILogger<SerieController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            

            return View();
        }

        [HttpPost]
        public JsonResult Listar(QueryGridModel queryGridModel)
        {
            List<object> list = HttpContext.Session.Get<List<object>>("ListaSeries");

            if ( list == null)
            {
                list = new List<object> ();
            }

            return Json(JsonReturn.SuccessWithInnerObject(new
            {
                draw = queryGridModel.draw,
                recordsFiltered = 2,
                recordsTotal = 2,
                data = list
            }));
        }

        
    }
}
