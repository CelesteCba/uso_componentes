using FluentNHibernate.Mapping;

namespace dao_library.Entidad
{
	public class PersonaMap : ClassMap<entity_library.Entidad.Persona>
	{
		public PersonaMap()
		{
			Table("persona");
			Id(x => x.Id)
				.Column("id_persona")
				.GeneratedBy.Increment();

			References(x => x.EstadoClase, "id_estado_clase");

			Map(x => x.NombreCompleto)
				.Column("nombre_completo");

		}
	}
}