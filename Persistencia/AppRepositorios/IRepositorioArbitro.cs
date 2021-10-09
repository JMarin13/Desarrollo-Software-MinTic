using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioArbitro
    {
        // Firmar los metodos
        bool CrearArbitro(Arbitro arbitro);
        Arbitro BuscarArbitro(int idArbitro);
        bool EliminarArbitro(int idArbitro);
        bool ActualizarArbitro(Arbitro arbitro);
        IEnumerable<Arbitro> ListarArbitros();
    }
}
