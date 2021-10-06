using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioTorneo//firmas de los metodos
    {
         bool CrearTorneo(Torneo Torneo);
         Torneo BuscarTorneo(int idTorneo);
         bool EliminarTorneo(int idTorneo);
         bool ActualizarTorneo(Torneo torneo);
         IEnumerable<Torneo> ListarTorneos();
    }
}