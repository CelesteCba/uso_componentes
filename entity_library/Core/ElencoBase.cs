using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace entity_library.Core
{
	public partial class Elenco
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

		#region rol
		private entity_library.Core.Rol rol;
		public virtual entity_library.Core.Rol Rol
		{
			get { return rol; }
			set { rol = value; }
		}
		#endregion

		#region persona
		private entity_library.Entidad.Persona persona;
		public virtual entity_library.Entidad.Persona Persona
		{
			get { return persona; }
			set { persona = value; }
		}
		#endregion

	}
}