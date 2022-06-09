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
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            LoginModel loginModel = HttpContext.Session.Get<LoginModel>(
                                "UsuarioLogueado");

            if(loginModel == null)
            {
                return Redirect("~/Home/Index");
            }

            return View();
        }

        [HttpPost]
        public JsonResult ListarUsuarios(QueryGridModel queryGridModel)
        {
            List<object> list =  HttpContext.Session.Get<List<object>>("ListarUsuarios");

            if (list==null)
            {
                list= new List<object>();
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
