using System;
using System.Collections.Generic;
using entity_library.Sistema;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace dao_library.Sistema
{
	public partial class DAOUsuario
	{
		public void EliminarUsuario(entity_library.Sistema.Usuario usuario)
		{
			try
			{
				this.session.Delete(usuario);
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Sistema.DAOUsuario.EliminarUsuario(Usuario usuario): Error al eliminar el usuario", ex);
			}
		}

		public Usuario ObtenerUsuario(
			entity_library.Estados.EstadoClase estadoClase, 
			string userName, 
			string password)
        {
            ICriteria lista = this.session.CreateCriteria<entity_library.Sistema.Usuario>("Usuario");

			lista.Add(Restrictions.Eq("Usuario.NombreUsuario", userName));
			lista.Add(Restrictions.Eq("Usuario.Password", password));
			lista.Add(Restrictions.Eq("Usuario.EstadoClase", estadoClase));

			IList<entity_library.Sistema.Usuario> retorno = lista.List<entity_library.Sistema.Usuario>();

			if(retorno != null && retorno.Count > 0)
			{
				return retorno[0];
			}

			return null;
        }
	}
}