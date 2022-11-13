using FluentNHibernate.Mapping;

namespace dao_library.Core
{
	public class GeneroMap : ClassMap<entity_library.Core.Genero>
	{
		public GeneroMap()
		{
			Table("genero");
			Id(x => x.Id)
				.Column("id_genero")
				.GeneratedBy.Increment();

			References(x => x.EstadoClase, "id_estado_clase");

			Map(x => x.Descripcion)
				.Column("descripcion");

		}
	}
}