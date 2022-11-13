using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace entity_library.Core
{
	public partial class Valoracion
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

		#region puntaje
		private Int32 puntaje;
		public virtual Int32 Puntaje
		{
			get { return puntaje; }
			set { puntaje = value; }
		}
		#endregion

		#region vista
		private Boolean vista;
		public virtual Boolean Vista
		{
			get { return vista; }
			set { vista = value; }
		}
		#endregion

		#region pelicula
		private entity_library.Core.Pelicula pelicula;
		public virtual entity_library.Core.Pelicula Pelicula
		{
			get { return pelicula; }
			set { pelicula = value; }
		}
		#endregion

		#region usuario
		private entity_library.Sistema.Usuario usuario;
		public virtual entity_library.Sistema.Usuario Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
		#endregion

	}
}