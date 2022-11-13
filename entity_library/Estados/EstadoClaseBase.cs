using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace entity_library.Estados
{
	public partial class EstadoClase
	{
		#region ID
		private long id;
		public virtual long Id
		{
			get { return id; }
			set { id = value; }
		}
		#endregion

		#region codigoSistema
		private Int64 codigoSistema;
		public virtual Int64 CodigoSistema
		{
			get { return codigoSistema; }
			set { codigoSistema = value; }
		}
		#endregion

		#region descripcion
		private System.String descripcion;
		public virtual System.String Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}
		#endregion

	}
}