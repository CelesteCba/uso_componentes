using System;
using System.Collections.Generic;
using entity_library.Comun;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace dao_library.Estados
{
	public partial class DAOEstadoClase
	{
		public entity_library.Estados.EstadoClase ObtenerEstadoClase(CodigoEstadoClase codigoEstadoClase)
		{
			try
			{
				ICriteria c = session.CreateCriteria<entity_library.Estados.EstadoClase>();

				c.Add(Restrictions.Eq("CodigoSistema", (long)codigoEstadoClase));

				IList<entity_library.Estados.EstadoClase> lista = 
					c.List<entity_library.Estados.EstadoClase>();
				
				if(lista != null && lista.Count > 0)
				{
					return lista[0];
				}

				return null;
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Estados.DAOEstadoClase.ObtenerEstadoClase(codigoEstadoClase): Error al obtener el item con codigoEstadoClase = " + codigoEstadoClase.ToString(), ex);
			}
		}
	}
}