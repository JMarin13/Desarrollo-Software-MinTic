using System.Collections.Generic;
using Dominio;

namespace Persistencia 
{
    public interface IRepositorioMunicipio
    {
        // Firmar los métodos
        bool CrearMunicipio(Municipio municipio);
        Municipio BuscarMunicipio(int idMunicipio);
        bool EliminarMunicipio(int idMunicipio);
        bool ActualizarMunicipio(Municipio municipio);
        IEnumerable<Municipio> ListarMunicipios();
    }
}