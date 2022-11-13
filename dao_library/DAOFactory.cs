using System;
using NHibernate;

namespace dao_library
{
	public class DAOFactory : IDisposable
	{
		#region atributos privados
		private ISession session = null;
		private ITransaction transaction = null;
		#endregion

		#region Constructor
		public DAOFactory()
		{
			this.session = Database.Instance.SessionFactory.OpenSession();
		}
		#endregion

		#region métodos de la base de datos
		public bool BeginTrans()
		{
			try
			{
				this.transaction = this.session.BeginTransaction();
				return true;
			}
			catch (System.Exception e)
			{
				throw new System.Exception(
					"dao_library.NHibernateDAOFactory.BeginTrans()",
					e);
			}
		}
		public bool Commit()
		{
			try
			{
				this.transaction.Commit();

				this.transaction = null;

				return true;
			}
			catch (System.Exception e)
			{
				throw new System.Exception(
					"dao_library.NHibernateDAOFactory.Commit()",
					e);
			}
		}

		public void Rollback()
		{
			try
			{
				if (this.transaction == null || !this.transaction.IsActive) return;

				this.transaction.Rollback();

				this.transaction = null;
			}
			catch (System.Exception e)
			{
				throw new System.Exception("dao_library.NHibernateDAOFactory.Rollback()", e);
			}
		}

		public void Close()
		{
			try
			{
				if (this.transaction != null && this.transaction.IsActive)
				{
					this.transaction.Rollback();
				}

				this.session.Close();
			}
			catch (System.Exception e)
			{
				throw new System.Exception("dao_library.NHibernateDAOFactory.Close()", e);
			}
		}

		public void Dispose()
		{
			try
			{
				this.Close();
			}
			catch (System.Exception e)
			{
				throw new System.Exception("dao_library.NHibernateDAOFactory.Dispose()", e);
			}
		}
		#endregion

		#region DAOs: Agregar los DAOs de ustedes
		private dao_library.Core.DAORol daoRol = null;
		public dao_library.Core.DAORol DAORol
		{
			get
			{
				if (this.daoRol == null)
				{
					this.daoRol = new dao_library.Core.DAORol(this.session);
				}

				return daoRol;
			}
		}

		private dao_library.Entidad.DAOPersona daoPersona = null;
		public dao_library.Entidad.DAOPersona DAOPersona
		{
			get
			{
				if (this.daoPersona == null)
				{
					this.daoPersona = new dao_library.Entidad.DAOPersona(this.session);
				}

				return daoPersona;
			}
		}

		private dao_library.Core.DAOElenco daoElenco = null;
		public dao_library.Core.DAOElenco DAOElenco
		{
			get
			{
				if (this.daoElenco == null)
				{
					this.daoElenco = new dao_library.Core.DAOElenco(this.session);
				}

				return daoElenco;
			}
		}

		private dao_library.Comun.DAOImagen daoImagen = null;
		public dao_library.Comun.DAOImagen DAOImagen
		{
			get
			{
				if (this.daoImagen == null)
				{
					this.daoImagen = new dao_library.Comun.DAOImagen(this.session);
				}

				return daoImagen;
			}
		}

		private dao_library.Core.DAOGenero daoGenero = null;
		public dao_library.Core.DAOGenero DAOGenero
		{
			get
			{
				if (this.daoGenero == null)
				{
					this.daoGenero = new dao_library.Core.DAOGenero(this.session);
				}

				return daoGenero;
			}
		}

		private dao_library.Sistema.DAOUsuario daoUsuario = null;
		public dao_library.Sistema.DAOUsuario DAOUsuario
		{
			get
			{
				if (this.daoUsuario == null)
				{
					this.daoUsuario = new dao_library.Sistema.DAOUsuario(this.session);
				}

				return daoUsuario;
			}
		}

		private dao_library.Core.DAOPelicula daoPelicula = null;
		public dao_library.Core.DAOPelicula DAOPelicula
		{
			get
			{
				if (this.daoPelicula == null)
				{
					this.daoPelicula = new dao_library.Core.DAOPelicula(this.session);
				}

				return daoPelicula;
			}
		}

		private dao_library.Core.DAOValoracion daoValoracion = null;
		public dao_library.Core.DAOValoracion DAOValoracion
		{
			get
			{
				if (this.daoValoracion == null)
				{
					this.daoValoracion = new dao_library.Core.DAOValoracion(this.session);
				}

				return daoValoracion;
			}
		}

		private dao_library.Estados.DAOEstadoClase daoEstadoClase = null;
		public dao_library.Estados.DAOEstadoClase DAOEstadoClase
		{
			get
			{
				if (this.daoEstadoClase == null)
				{
					this.daoEstadoClase = new dao_library.Estados.DAOEstadoClase(this.session);
				}

				return daoEstadoClase;
			}
		}

		#endregion
	}
}