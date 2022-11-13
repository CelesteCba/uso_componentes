using FluentNHibernate.Mapping;

namespace dao_library.Core
{
	public class ElencoMap : ClassMap<entity_library.Core.Elenco>
	{
		public ElencoMap()
		{
			Table("elenco");
			Id(x => x.Id)
				.Column("id_elenco")
				.GeneratedBy.Increment();

			References(x => x.EstadoClase, "id_estado_clase");

			References(x => x.Rol, "id_rol");

			References(x => x.Persona, "id_persona");

		}
	}
}