using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioDeportista
    {
        // Firmar los metodos
        bool CrearDeportista(Deportista deportista);
        Deportista BuscarDeportista(int idDeportista);
        bool EliminarDeportista(int idDeportista);
        bool ActualizarDeportista(Deportista deportista);
        IEnumerable<Deportista> ListarDeportistas();
    }
}
