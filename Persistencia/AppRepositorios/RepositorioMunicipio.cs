using System.Collections.Generic;
using Dominio;
using System.Linq;

namespace Persistencia 
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        // Atributos
        private readonly AppContext _appContext;

        /* Métodos */ 

        // Constructor por defecto
        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext = appContext;
        }

        // Crear un Municipio
        bool IRepositorioMunicipio.CrearMunicipio(Municipio municipio)
        {
            bool creado = false;
            bool existeMunicipio = ValidarNombre(municipio);

            if (!existeMunicipio)
            {
                try
                {
                    _appContext.Municipios.Add(municipio);
                    _appContext.SaveChanges();
                    creado = true;
                }
                catch (System.Exception)
                {
                    return creado;
                }
            }
            return creado;
        }

        // Buscar un Municipio
        Municipio IRepositorioMunicipio.BuscarMunicipio(int idMunicipio)
        {
            return _appContext.Municipios.Find(idMunicipio);
        }

        // Eliminar un Municipio
        bool IRepositorioMunicipio.EliminarMunicipio(int idMunicipio)
        {
            bool eliminado = false;
            var municipio = _appContext.Municipios.Find(idMunicipio);
            if (municipio != null)
            {
                try
                {
                    _appContext.Municipios.Remove(municipio);
                    _appContext.SaveChanges();
                    eliminado = true;
                }
                catch (System.Exception)
                {
                    return eliminado;
                }
            }
            return eliminado;
        }

        // Actualizar un Municipio
        bool IRepositorioMunicipio.ActualizarMunicipio(Municipio municipio)
        {
            bool actualizado = false;
            var muni = _appContext.Municipios.Find(municipio.Id);
            if (muni != null)
            {
                try
                {
                    muni.Nombre = municipio.Nombre;
                    _appContext.SaveChanges();
                    actualizado = true;
                }
                catch (System.Exception)
                {
                    return actualizado;
                }
            }
            return actualizado;
        }

        // Listar Municipios
        IEnumerable<Municipio> IRepositorioMunicipio.ListarMunicipios()
        {
            return _appContext.Municipios;
        }

        // Método para verificar la existencia de un nombre antes de guardarlo.
        bool ValidarNombre(Municipio municipio)
        {
            bool existe = false;
            var nombreMunicipio = _appContext.Municipios.FirstOrDefault(m => m.Nombre == municipio.Nombre);
            if (nombreMunicipio != null)
            {
                existe = true;
            }
            return existe;
        }
    }  
}