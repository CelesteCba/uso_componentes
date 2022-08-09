using mvc_project.Models.Common;

namespace mvc_project.Models.Pelicula
{
    public class PeliculaViewModel
    {
        public long id { get; set; }
        public string nombrePelicula { get; set; }

        public string descripcionPelicula { get; set; }

        public string imagenPelicula { get; set; }

        public string duracionPelicula { get; set; }

        public string añoPelicula { get; set; }
        public  CodigosAccion accion { get; set; }

      
    }
}
