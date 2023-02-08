using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Models;
using mvc_project.Models.Common;
using mvc_project.Models.Login;
using mvc_project.Models.Pelicula;
using dao_library.Utils;
using dao_library;

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
            LoginModel loginModel = HttpContext.Session.Get<LoginModel>("UsuarioLogueado");

            if(loginModel == null)
            {
                return Json(Models.Common.JsonReturn.Redirect("Home/Index"));
            }

            try
            {
                long cantidadTotal = 0;

                //Inicializar la lista vacia.
                List<PeliculaModel> listaPeliculas = new List<PeliculaModel>();

                using (DAOFactory df = new DAOFactory())
                {
                    List<AtributoBusqueda> atributosBusqueda = obtenerAtributosBusqueda();
                    Ordenamiento ordenamiento = obtenerOrdenamiento(queryGridModel);
                    List<Asociacion> asociaciones = obtenerAsociaciones();
                    
                    Paginado paginado = new Paginado
                    {
                        Comienzo = queryGridModel.start,
                        Cantidad = queryGridModel.length
                    };

                    entity_library.Estados.EstadoClase activo = 
                        df.DAOEstadoClase.ObtenerEstadoClase(entity_library.Comun.CodigoEstadoClase.Activo);

                    IList<entity_library.Core.Pelicula> peliculas = df.DAOPelicula.ObtenerListaPelicula(
                        activo,
                        queryGridModel.search != null ? queryGridModel.search.value : "",
                        atributosBusqueda,
                        paginado,
                        ordenamiento,
                        asociaciones,
                        out cantidadTotal);

                    foreach (entity_library.Core.Pelicula pelicula in peliculas)
                    {
                        listaPeliculas.Add(new PeliculaModel
                        {
                            id = pelicula.Id,
                            titulo = pelicula.Titulo,
                            sinopsis = pelicula.Sinopsis
                        });
                    }

                    return Json(JsonReturn.SuccessWithInnerObject(new
                    {
                        draw = queryGridModel.draw,
                        recordsFiltered = cantidadTotal,
                        recordsTotal = cantidadTotal,
                        data = listaPeliculas
                    }));
                }
            }
            catch (System.Exception ex)
            {
                return Json(JsonReturn.ErrorWithSimpleMessage("Hubo un error"));
            }
        }
        
        private static List<AtributoBusqueda> obtenerAtributosBusqueda()
        {
            List<AtributoBusqueda> atributosBusqueda = new List<AtributoBusqueda>();

            atributosBusqueda.Add(new AtributoBusqueda
            {
                NombreAtributo = "Pelicula.Titulo",
                TipoDato = TipoDato.String
            });

            atributosBusqueda.Add(new AtributoBusqueda
            {
                NombreAtributo = "Pelicula.Sinopsis",
                TipoDato = TipoDato.String
            });

            return atributosBusqueda;
        }

        private static Ordenamiento obtenerOrdenamiento(
            QueryGridModel modeloConsulta)
        {
            Ordenamiento ordenamiento = new Ordenamiento
            {
                Atributo = "Pelicula.Titulo",
                Direccion = "asc"
            };

            if (modeloConsulta.order != null &&
                modeloConsulta.order.Count > 0)
            {
                int columnIndex = modeloConsulta.order[0].column;
                string col = modeloConsulta.columns[columnIndex].data;

                if (col == "titulo") col = "Pelicula.Titulo";
                else if(col == "sinopsis") col = "Pelicula.Sinopsis";
                else col = "Pelicula.Titulo";

                ordenamiento.Atributo = col;
                ordenamiento.Direccion =
                    modeloConsulta.order[0].dir == DirectionModel.desc ? "desc" : "asc";
            }

            return ordenamiento;
        }

        private static List<Asociacion> obtenerAsociaciones()
        {
            List<Asociacion> asociaciones = new List<Asociacion>();

            return asociaciones;
        }
    }
}
