using FluentNHibernate.Mapping;

namespace dao_library.Estados
{
	public class EstadoClaseMap : ClassMap<entity_library.Estados.EstadoClase>
	{
		public EstadoClaseMap()
		{
			Table("estado_clase");
			Id(x => x.Id)
				.Column("id_estado_clase")
				.GeneratedBy.Increment();

			Map(x => x.CodigoSistema)
				.Column("codigo_sistema");

			Map(x => x.Descripcion)
				.Column("descripcion");

		}
	}
}