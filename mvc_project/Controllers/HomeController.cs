using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc_project.Models;
using mvc_project.Models.Login;

namespace mvc_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            LoginViewModel loginViewModel =
                new LoginViewModel
            {
                isLogged = true,
                message = "",
                userName = ""
            };

            return View(loginViewModel);
        }

        public IActionResult Login(LoginModel loginModel)
        {
            LoginViewModel loginViewModel =
                new LoginViewModel();

            if(string.IsNullOrEmpty(loginModel.userName) ||
                string.IsNullOrEmpty(loginModel.password))
            {
                loginViewModel.isLogged = false;
                loginViewModel.message = "Debe ingresar un nombre de usuario o password";
                loginViewModel.userName = string.IsNullOrEmpty(loginModel.userName) ? "" : loginModel.userName;
                return View("~/Views/Home/Index.cshtml", loginViewModel);
            }
            
            using(dao_library.DAOFactory df = new dao_library.DAOFactory())
            {
                entity_library.Estados.EstadoClase activo =
                    df.DAOEstadoClase.ObtenerEstadoClase(entity_library.Comun.CodigoEstadoClase.Activo);

                entity_library.Sistema.Usuario usuario = df.DAOUsuario.ObtenerUsuario(
                    activo, 
                    loginModel.userName, 
                    loginModel.password);

                if(usuario == null)
                {
                    loginViewModel.isLogged = false;
                    loginViewModel.message = "Nombre de usuario o contraseña incorrecto";
                    loginViewModel.userName = loginModel.userName;
                    return View("~/Views/Home/Index.cshtml", loginViewModel);
                }

                loginModel.IdUsuario = usuario.Id;
            }

            HttpContext.Session.Set<LoginModel>(
                "UsuarioLogueado",
                loginModel);

            return Redirect("~/Panel/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
