using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEntrenador
    {
        // Firmar los metodos
        bool CrearEntrenador(Entrenador entrenador);
        Entrenador BuscarEntrenador(int idEntrenador);
        bool EliminarEntrenador(int idEntrenador);
        bool ActualizarEntrenador(Entrenador entrenador);
        IEnumerable<Entrenador> ListarEntrenador();
    }
//flata crear la interface de las otras clases 

}