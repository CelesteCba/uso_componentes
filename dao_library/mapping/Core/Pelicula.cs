using FluentNHibernate.Mapping;

namespace dao_library.Core
{
	public class PeliculaMap : ClassMap<entity_library.Core.Pelicula>
	{
		public PeliculaMap()
		{
			Table("pelicula");
			Id(x => x.Id)
				.Column("id_pelicula")
				.GeneratedBy.Increment();

			References(x => x.EstadoClase, "id_estado_clase");

			Map(x => x.Titulo)
				.Column("titulo");

			Map(x => x.Sinopsis)
				.Column("sinopsis");

			HasMany(x => x.Elencos)
				.KeyColumn("id_pelicula")
				.Where("id_estado_clase=1")
				.Cascade.All()
				.LazyLoad();

			References(x => x.Imagen, "id_imagen");

		}
	}
}