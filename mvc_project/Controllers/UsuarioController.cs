using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Models;
using mvc_project.Models.Common;
using mvc_project.Models.Login;
using mvc_project.Models.Usuario;

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
            LoginModel loginModel = HttpContext.Session.Get<LoginModel>("UsuarioLogueado");

            if(loginModel == null)
            {
                return Redirect("~/Home/Index");
            }

            return View();
        }

        public IActionResult Nuevo()
        {
            LoginModel loginModel = HttpContext.Session.Get<LoginModel>("UsuarioLogueado");

            if(loginModel == null)
            {
                return Redirect("~/Home/Index");
            }

            UsuarioViewModel usuarioViewModel = new UsuarioViewModel
            {
                apellidoPersona = "",
                id = 0,
                nombrePersona = "",
                nombreUsuario = "",
                accion = CodigosAccion.Nuevo

            };

            return View("~/Views/Usuario/Usuario.cshtml",usuarioViewModel);
        }

        [HttpPost]
        public JsonResult Listar(QueryGridModel queryGridModel)
        {
            List<object> list =  HttpContext.Session.Get<List<object>>("ListaUsuarios");

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
         [HttpPost]
        public JsonResult Guardar(UsuarioModel usuarioModel)
        {
           LoginModel loginModel = HttpContext.Session.Get<LoginModel>("UsuarioLogueado");

            if(loginModel == null)
            {
                return Json (Models.Common.JsonReturn.Redirect("Home/Index"));
            }
            List<object> list =  HttpContext.Session.Get<List<object>>("ListaUsuarios");

            if ( list == null)
            {
                list = new List<object> ();
            }

            list.Add(usuarioModel);

            HttpContext.Session.Set<List<object>>("ListaUsuarios",list);

            return Json(JsonReturn.SuccessWithoutInnerObject());
            
        }
    
    }
}
