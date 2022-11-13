using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace entity_library.Comun
{
	public partial class Imagen
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

		#region nombreImagen
		private System.String nombreImagen;
		public virtual System.String NombreImagen
		{
			get { return nombreImagen; }
			set { nombreImagen = value; }
		}
		#endregion

		#region path
		private System.String path;
		public virtual System.String Path
		{
			get { return path; }
			set { path = value; }
		}
		#endregion

		#region url
		private System.String url;
		public virtual System.String Url
		{
			get { return url; }
			set { url = value; }
		}
		#endregion

	}
}