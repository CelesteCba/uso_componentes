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
using entity_library.Core;

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
                id = 0,
                titulo="",
                sinopsis="",
                anioEstreno="",
                director="",
                genero="",
                accion = CodigosAccion.Nuevo

            };

            return View("~/Views/Pelicula/Pelicula.cshtml", peliculaViewModel);
        }
         public IActionResult Editar(long idPelicula)
        {
            using(DAOFactory df=new DAOFactory())
            {
               Pelicula pelicula = df.DAOPelicula.ObtenerPelicula(idPelicula);
            

                PeliculaViewModel peliculaViewModel = new PeliculaViewModel
                {
                    id = pelicula.Id,
                    titulo=pelicula.Titulo,
                    sinopsis=pelicula.Sinopsis,
                    anioEstreno=pelicula.AnioEstreno.ToString(),
                    director=pelicula.Director,
                    genero=pelicula.Genero.Descripcion,
                    accion = CodigosAccion.Editar

                };

                return View("~/Views/Pelicula/Pelicula.cshtml", peliculaViewModel);
            }
        }
         public IActionResult Ver(long idPelicula)
        {
            using(DAOFactory df=new DAOFactory())
            {
               Pelicula pelicula = df.DAOPelicula.ObtenerPelicula(idPelicula);
            

                PeliculaViewModel peliculaViewModel = new PeliculaViewModel
                {
                    id = pelicula.Id,
                    titulo=pelicula.Titulo,
                    sinopsis=pelicula.Sinopsis,
                    anioEstreno=pelicula.AnioEstreno.ToString(),
                    director=pelicula.Director,
                    genero=pelicula.Genero.Descripcion,
                    accion = CodigosAccion.Ver

                };

                return View("~/Views/Pelicula/Pelicula.cshtml", peliculaViewModel);
            }
        }
        
        [HttpPost]
        public JsonResult Eliminar(long id){
            using(DAOFactory df=new DAOFactory())
            {
               Pelicula pelicula = df.DAOPelicula.ObtenerPelicula(id);
               df.BeginTrans();
               pelicula.EstadoClase=df.DAOEstadoClase.ObtenerEstadoClase(entity_library.Comun.CodigoEstadoClase.Baja);
               df.DAOPelicula.Guardar(pelicula);
               df.Commit();
               return Json(JsonReturn.SuccessWithoutInnerObject());
            }
        }
         [HttpPost]
        public JsonResult Guardar(PeliculaModel peliculaModel)
        {
            LoginModel loginModel = HttpContext.Session.Get<LoginModel>("UsuarioLogueado");

            if(loginModel == null)
            {
                return Json(Models.Common.JsonReturn.Redirect("Home/Index"));
            }

            try
            {
                using (DAOFactory df = new DAOFactory())
                {
                    entity_library.Core.Pelicula pelicula = df.DAOPelicula.ObtenerPelicula(peliculaModel.id);
                    
                    entity_library.Estados.EstadoClase activo =
                        df.DAOEstadoClase.ObtenerEstadoClase(entity_library.Comun.CodigoEstadoClase.Activo);

                    if(pelicula == null)
                    {
                        pelicula = new entity_library.Core.Pelicula();
                        pelicula.EstadoClase = activo;
                    }
                    pelicula.Titulo = peliculaModel.titulo;
                    pelicula.Sinopsis = peliculaModel.sinopsis;
                    pelicula.AnioEstreno = long.Parse(peliculaModel.anioEstreno);
                    pelicula.Director = peliculaModel.director;
                    pelicula.Genero = df.DAOGenero.ObtenerGenero(1);

                    df.BeginTrans();
                    df.DAOPelicula.Guardar(pelicula);
                    df.Commit();

                    return Json(JsonReturn.SuccessWithoutInnerObject());
                }
            }
            catch (System.Exception)
            {
                return Json(JsonReturn.ErrorWithSimpleMessage("Hubo un error"));
            }
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
                            sinopsis = pelicula.Sinopsis,
                            anioEstreno = pelicula.AnioEstreno.ToString(),
                            director = pelicula.Director,
                            genero= pelicula.Genero.Descripcion
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
            atributosBusqueda.Add(new AtributoBusqueda
            {
                NombreAtributo = "Genero.Descripcion",
                TipoDato = TipoDato.String
            });
            atributosBusqueda.Add(new AtributoBusqueda
            {
                NombreAtributo = "Pelicula.AnioEstreno",
                TipoDato = TipoDato.Int64
            });

            atributosBusqueda.Add(new AtributoBusqueda
            {
                NombreAtributo = "Pelicula.Director",
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
                else if(col == "anioEstreno") col = "Pelicula.AnioEstreno";
                else if(col == "director") col = "Pelicula.Director";
                else if(col == "genero") col = "Genero.Descripcion";
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
            asociaciones.Add(new Asociacion{
                Alias="Genero",
                RutaDeAsociacion="Pelicula.Genero",
                TipoJoin= TipoJoin.InnerJoin
            });

            return asociaciones;
        }
    }
}
