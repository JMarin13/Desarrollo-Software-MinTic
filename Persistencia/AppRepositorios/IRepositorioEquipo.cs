//es una clase especial que define un contrato 
using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEquipo
    {
        //firmar los metodos, son como las clausulas del contrato
        bool CrearEquipo(Equipo equipo);
        Equipo BuscarEquipo(int idEquipo);
        bool EliminarEquipo(int idEquipo);
        bool ActualizarEquipo(Equipo equipo);
        IEnumerable<Equipo> ListarEquipo();

    }
}