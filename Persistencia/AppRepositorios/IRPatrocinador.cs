using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRPatrocinador
    {
        // Firmar los metodos
        bool CrearPatrocinador(Patrocinador patrocinador);
        Patrocinador BuscarPatrocinador(int idPatrocinador);
        bool EliminarPatrocinador(int idPatrocinador);
        bool ActualizarPatrocinador(Patrocinador patrocinador);
        IEnumerable<Patrocinador> ListarPatrocinadores();
        List<Patrocinador> ListarPatrocinadores1();
    }
}
