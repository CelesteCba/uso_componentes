using mvc_project.Models.Common;

namespace mvc_project.Models.Pelicula
{
    public class PeliculaModel
    {
        public long id { get; set; }
        public string titulo { get; set; }
        public string sinopsis { get; set; }
        public string anioEstreno{ get; set; }
        public string director{ get; set; }
        public string genero{ get; set; }
        public  CodigosAccion accion { get; set; }
    }
}
