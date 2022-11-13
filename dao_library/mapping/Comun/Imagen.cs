using FluentNHibernate.Mapping;

namespace dao_library.Comun
{
	public class ImagenMap : ClassMap<entity_library.Comun.Imagen>
	{
		public ImagenMap()
		{
			Table("imagen");
			Id(x => x.Id)
				.Column("id_imagen")
				.GeneratedBy.Increment();

			References(x => x.EstadoClase, "id_estado_clase");

			Map(x => x.NombreImagen)
				.Column("nombre_imagen");

			Map(x => x.Path)
				.Column("path");

			Map(x => x.Url)
				.Column("url");

		}
	}
}