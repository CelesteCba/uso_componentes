using FluentNHibernate.Mapping;

namespace dao_library.Sistema
{
	public class UsuarioMap : ClassMap<entity_library.Sistema.Usuario>
	{
		public UsuarioMap()
		{
			Table("usuario");
			Id(x => x.Id)
				.Column("id_usuario")
				.GeneratedBy.Increment();

			References(x => x.EstadoClase, "id_estado_clase");

			Map(x => x.NombreUsuario)
				.Column("nombre_usuario");

			Map(x => x.Password)
				.Column("password");

			Map(x => x.NombreCompleto)
				.Column("nombre_completo");

		}
	}
}