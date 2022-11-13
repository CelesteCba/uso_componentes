using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace dao_library.Core
{
	public partial class DAORol
	{
		private ISession session;

		public DAORol(ISession session)
		{
			this.session = session;
		}

		public entity_library.Core.Rol ObtenerRol(long id)
		{
			try
			{
				return this.session.Get<entity_library.Core.Rol>(id);
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Core.DAORol.ObtenerRol(long id): Error al obtener el item con id = " + id.ToString(), ex);
			}
		}

		public IList<entity_library.Core.Rol> ObtenerListaRol(entity_library.Estados.EstadoClase estadoClase, string col, string sort)
		{
			try
			{
				ICriteria c = session.CreateCriteria<entity_library.Core.Rol>();

				c.Add(Restrictions.Eq("EstadoClase", estadoClase));

				if(sort.Trim().ToUpper() == "ASC") c.AddOrder(Order.Asc(col));
				else c.AddOrder(Order.Desc(col));

				return c.List<entity_library.Core.Rol>();
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Core.DAORol.ObtenerListaRol: Error al obtener el listado", ex);
			}
		}

		public IList<entity_library.Core.Rol> ObtenerListaRol(
			entity_library.Estados.EstadoClase estadoClase,
			string query,
			List<dao_library.Utils.AtributoBusqueda> queryCols,
			dao_library.Utils.Paginado paginado,
			dao_library.Utils.Ordenamiento ordenamiento,
			out long cantidadTotal)
		{
			try
			{
				ICriteria lista = this.session.CreateCriteria<entity_library.Core.Rol>("Rol");
				ICriteria cantidad = this.session.CreateCriteria<entity_library.Core.Rol>("Rol");

//				dao_library.Utils.UtilidadesNHibernate.CrearAsociaciones(asociaciones, lista);
//				dao_library.Utils.UtilidadesNHibernate.CrearAsociaciones(asociaciones, cantidad);

				dao_library.Utils.UtilidadesNHibernate.AgregarCriteriosDeBusqueda(queryCols, query, lista);
				dao_library.Utils.UtilidadesNHibernate.AgregarCriteriosDeBusqueda(queryCols, query, cantidad);

				lista.Add(Restrictions.Eq("Rol.EstadoClase", estadoClase));
				cantidad.Add(Restrictions.Eq("Rol.EstadoClase", estadoClase));

				dao_library.Utils.UtilidadesNHibernate.AgregarOrdenamiento(ordenamiento, lista);
				dao_library.Utils.UtilidadesNHibernate.AgregarPaginado(paginado, lista);

				cantidadTotal = dao_library.Utils.UtilidadesNHibernate.ObtenerCantidad(cantidad);

				IList<entity_library.Core.Rol> retorno = lista.List<entity_library.Core.Rol>();

				return retorno;
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Core.DAORol.ObtenerListaRol: Error al obtener el listado de items", ex);
			}
		}

		public IList<entity_library.Core.Rol> ObtenerListaRol(
			entity_library.Estados.EstadoClase estadoClase,
			string query,
			List<dao_library.Utils.AtributoBusqueda> queryCols,
			dao_library.Utils.Paginado paginado,
			dao_library.Utils.Ordenamiento ordenamiento,
			List<dao_library.Utils.Asociacion> asociaciones,
			out long cantidadTotal)
		{
			try
			{
				ICriteria lista = this.session.CreateCriteria<entity_library.Core.Rol>("Rol");
				ICriteria cantidad = this.session.CreateCriteria<entity_library.Core.Rol>("Rol");

				dao_library.Utils.UtilidadesNHibernate.CrearAsociaciones(asociaciones, lista);
				dao_library.Utils.UtilidadesNHibernate.CrearAsociaciones(asociaciones, cantidad);

				dao_library.Utils.UtilidadesNHibernate.AgregarCriteriosDeBusqueda(queryCols, query, lista);
				dao_library.Utils.UtilidadesNHibernate.AgregarCriteriosDeBusqueda(queryCols, query, cantidad);

				lista.Add(Restrictions.Eq("Rol.EstadoClase", estadoClase));
				cantidad.Add(Restrictions.Eq("Rol.EstadoClase", estadoClase));

				dao_library.Utils.UtilidadesNHibernate.AgregarOrdenamiento(ordenamiento, lista);
				dao_library.Utils.UtilidadesNHibernate.AgregarPaginado(paginado, lista);

				cantidadTotal = dao_library.Utils.UtilidadesNHibernate.ObtenerCantidad(cantidad);

				IList<entity_library.Core.Rol> retorno = lista.List<entity_library.Core.Rol>();

				return retorno;
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Core.DAORol.ObtenerListaRol: Error al obtener el listado de items", ex);
			}
		}

		public void Guardar(entity_library.Core.Rol item)
		{
			try
			{
				this.session.Save(item);
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Core.DAORol.Guardar: Error al guardar el item.", ex);
			}
		}

		public bool Existe(entity_library.Estados.EstadoClase estadoClase, string propiedad, object query)
		{
			try
			{
				ICriteria cantidad = session.CreateCriteria<entity_library.Core.Rol>();

				cantidad.Add(Restrictions.Eq(propiedad, query));
				cantidad.Add(Restrictions.Eq("EstadoClase", estadoClase));

				cantidad.SetProjection(Projections.RowCount());

				return ((int)cantidad.UniqueResult() > (int)0);
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Core.DAORol.Existe: Error al preguntar si existe un item con la propiedad " + propiedad + " con el valor " + query.ToString(), ex);
			}
		}

		public long ObtenerCantidad(entity_library.Estados.EstadoClase estadoClase, string propiedad, object query)
		{
			try
			{
				ICriteria cantidad = session.CreateCriteria<entity_library.Core.Rol>();
				cantidad.Add(Restrictions.Eq(propiedad, query));

				cantidad.Add(Restrictions.Eq("EstadoClase", estadoClase));

				cantidad.SetProjection(Projections.RowCount());
				return ((long)((int)cantidad.UniqueResult()));
			}
			catch (Exception ex)
			{
				throw new Exception("dao_library.Core.DAORol.Existe: Error al preguntar la cantidad de items con la propiedad " + propiedad + " que tengan el valor " + query.ToString(), ex);
			}
		}
	}
}