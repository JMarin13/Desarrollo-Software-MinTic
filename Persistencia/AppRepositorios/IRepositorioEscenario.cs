using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEscenario
    {
        // Firmar los metodos
        bool CrearEscenario(Escenario escenario);
        Escenario BuscarEscenario(int idEscenario);
        bool EliminarEscenario(int idEscenario);
        bool ActualizarEscenario(Escenario escenario);
        IEnumerable<Escenario> ListarEscenarios();
    }
}
