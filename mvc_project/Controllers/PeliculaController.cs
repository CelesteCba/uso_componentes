using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Models;
using mvc_project.Models.Common;
using mvc_project.Models.Login;
using mvc_project.Models.Pelicula;

namespace mvc_project.Controllers
{
    public class PeliculaController : Controller
    {
        private readonly ILogger<PeliculaController> _logger;

        public PeliculaController(ILogger<PeliculaController> logger)
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


            PeliculaViewModel peliculaViewModel = new PeliculaViewModel
            {
               nombrePelicula = "",
                id = 0,
               descripcionPelicula = "",
               linkPelicula = "",
               duracionPelicula = "",
               directorPelicula="",
               generoPelicula="",
               añoPelicula ="",
               calificacionPelicula="",
               vistoPelicula="",
               accion = CodigosAccion.Nuevo

            };

            return View("~/Views/Pelicula/Pelicula.cshtml", peliculaViewModel);
        }

        [HttpPost]
        public JsonResult Listar(QueryGridModel queryGridModel)
        {
            List<object> list = HttpContext.Session.Get<List<object>>("ListaPeliculas");

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
