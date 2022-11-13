using FluentNHibernate.Mapping;

namespace dao_library.Core
{
	public class ValoracionMap : ClassMap<entity_library.Core.Valoracion>
	{
		public ValoracionMap()
		{
			Table("valoracion");
			Id(x => x.Id)
				.Column("id_valoracion")
				.GeneratedBy.Increment();

			References(x => x.EstadoClase, "id_estado_clase");

			Map(x => x.Puntaje)
				.Column("puntaje");

			Map(x => x.Vista)
				.Column("vista");

			References(x => x.Pelicula, "id_pelicula");

			References(x => x.Usuario, "id_usuario");

		}
	}
}