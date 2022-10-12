using mvc_project.Models.Common;

namespace mvc_project.Models.Pelicula
{
    public class PeliculaModel
    {
        public long id { get; set; }
        public string nombrePelicula { get; set; }

        public string descripcionPelicula { get; set; }

        public string linkPelicula { get; set; }
        public string directorPelicula { get; set; }
        public string generoPelicula { get; set; }
        public string calificacionPelicula { get; set; }
        public string vistoPelicula { get; set; }
        
        public string duracionPelicula { get; set; }
        public string añoPelicula { get; set; }

    }
}
