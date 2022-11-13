using FluentNHibernate.Mapping;

namespace dao_library.Core
{
	public class RolMap : ClassMap<entity_library.Core.Rol>
	{
		public RolMap()
		{
			Table("rol");
			Id(x => x.Id)
				.Column("id_rol")
				.GeneratedBy.Increment();

			References(x => x.EstadoClase, "id_estado_clase");

			Map(x => x.Descripcion)
				.Column("descripcion");

		}
	}
}