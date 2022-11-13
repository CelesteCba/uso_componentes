using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace entity_library.Entidad
{
	public partial class Persona
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

		#region nombreCompleto
		private System.String nombreCompleto;
		public virtual System.String NombreCompleto
		{
			get { return nombreCompleto; }
			set { nombreCompleto = value; }
		}
		#endregion

	}
}