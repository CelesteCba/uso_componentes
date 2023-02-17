using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace entity_library.Core
{
	public partial class Pelicula
	{
		#region ID
		private long id;
		public virtual long Id
		{
			get { return id; }
			set { id = value; }
		}
		#endregion

		#region EstadoClase
		private entity_library.Estados.EstadoClase estadoClase;
		public virtual entity_library.Estados.EstadoClase EstadoClase
		{
			get { return estadoClase; }
			set { estadoClase = value; }
		}
		#endregion

		#region titulo
		private System.String titulo;
		public virtual System.String Titulo
		{
			get { return titulo; }
			set { titulo = value; }
		}
		#endregion

		#region sinopsis
		private System.String sinopsis;
		public virtual System.String Sinopsis
		{
			get { return sinopsis; }
			set { sinopsis = value; }
		}
		#endregion
		#region genero
		private Genero genero;
		public virtual Genero Genero
		{
			get { return genero; }
			set { genero = value; }
		}
		#endregion
		#region anioEstreno
		private System.Int64 anioEstreno;
		public virtual System.Int64 AnioEstreno
		{
			get { return anioEstreno; }
			set { anioEstreno = value; }
		}
		#endregion
		#region director
		private System.String director;
		public virtual System.String Director
		{
			get { return director; }
			set { director = value; }
		}
		#endregion

		#region elencos
		private IList<entity_library.Core.Elenco> elencos;
		public virtual IList<entity_library.Core.Elenco> Elencos
		{
			get { return elencos; }
			set { elencos = value; }
		}
		#endregion

		#region imagen
		private entity_library.Comun.Imagen imagen;
		public virtual entity_library.Comun.Imagen Imagen
		{
			get { return imagen; }
			set { imagen = value; }
		}
		#endregion

	}
}