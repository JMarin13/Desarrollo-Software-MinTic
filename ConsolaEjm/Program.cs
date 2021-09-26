using System;
using Dominio;
using Persistencia;
using System.Collections.Generic;

namespace ConsolaEjm
{
    class Program
    {

        private static IRepositorioMunicipio _repositorioMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        
        static void Main(string[] args)
        {
            
            // Probar el método para crear un municipio
            bool siFunciona = crearMunicipio();
            if (siFunciona)
            {
                Console.WriteLine("Municipio creado correctamente...");
            }else {
                Console.WriteLine("Se ha presentado un error al crear el Municipio...");
            } 
            

            /* 
            // Probar el método para buscar un municipio
            buscarMunicipio(); 
            */

            /* 
            // Probar el método para eliminar un municipio
            bool siFunciona = eliminarMunicipio();
            if (siFunciona)
            {
                Console.WriteLine("Municipio eliminado correctamente...");
            }else {
                Console.WriteLine("Se ha presentado un error al eliminar el Municipio...");
            } 
            */

            /* 
            // Probar el método para actualizar un municipio
            bool siFunciona = actualizarMunicipio();
            if (siFunciona)
            {
                Console.WriteLine("Municipio actualizado correctamente...");
            }else {
                Console.WriteLine("Se ha presentado un error al actualizar el Municipio...");
            }
            */
            
            // Probar el método para listar los municipios
            listarMunicipios();
            
        }

        private static bool crearMunicipio()
        {
            var municipio = new Municipio();
            Console.WriteLine("Ingrese el nombre del municipio: ");
            municipio.Nombre = Console.ReadLine();
            bool funciona = _repositorioMunicipio.CrearMunicipio(municipio);

            return funciona;
        }

        private static void buscarMunicipio()
        {
            var municipio = _repositorioMunicipio.BuscarMunicipio(2);
            if (municipio != null)
            {
                Console.WriteLine(municipio.Id);
                Console.WriteLine(municipio.Nombre);
            }else {
                Console.WriteLine("No se encontró el municipio");
            }
        }

        private static bool eliminarMunicipio()
        {
            bool funciona = _repositorioMunicipio.EliminarMunicipio(2);
            return funciona;
        }

        private static bool actualizarMunicipio()
        {
            var muni = new Municipio
            {
                Id = 1,
                Nombre = "Victoria"
            };

            bool funciona = _repositorioMunicipio.ActualizarMunicipio(muni);
            return funciona;
        }

        private static void listarMunicipios()
        {
            IEnumerable<Municipio> municipios = _repositorioMunicipio.ListarMunicipios();
            foreach (var muni in municipios)
            {
                Console.WriteLine(muni.Id + " " + muni.Nombre);
            }
        }
    }
}