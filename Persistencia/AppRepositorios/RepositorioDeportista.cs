using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;


namespace Persistencia
{
    public class RepositorioDeportista:IRepositorioDeportista
    {
        // Atributos 
        private readonly AppContext _appContext;
        
        //Metodos
        //Constructor por defecto
        public RepositorioDeportista(AppContext appContext)
        {
            _appContext=appContext;
        }

        bool IRepositorioDeportista.CrearDeportista(Deportista deportista)
        {
            bool creado=false;
            bool existe=ValidarNombre(deportista);
            if(!existe)
            {
                try
                {
                    _appContext.Deportistas.Add(deportista);
                    _appContext.SaveChanges();
                    creado= true;
                    
                }
                catch (System.Exception)
                {
                    //Console.WriteLine(e.ToString());
                    return creado;               
                }

            }            
            return creado;
        }
        Deportista IRepositorioDeportista.BuscarDeportista(int idDeportista)
        {
            /*var deportista=_appContext.Deportistas.Find(iddeportista);
            return deportista;*/
            return _appContext.Deportistas.Find(idDeportista);
        }
        bool IRepositorioDeportista.EliminarDeportista(int idDeportista)
        {
            bool eliminado=false;
            var deportista=_appContext.Deportistas.Find(idDeportista);
            if(deportista!=null)
            {
                try
                {
                     _appContext.Deportistas.Remove(deportista);
                     _appContext.SaveChanges();
                     eliminado=true;
                }
                catch (System.Exception)
                {
                   return eliminado;
                }
            }
            return eliminado;
        }

        bool IRepositorioDeportista.ActualizarDeportista(Deportista deportista)
        {
            bool actualizado= false;
            var mun=_appContext.Deportistas.Find(deportista.Id);
            if(mun!=null)
            {
                try
                {
                     mun.Nombre=deportista.Nombre;
                     _appContext.SaveChanges();
                     actualizado=true;
                }
                catch (System.Exception)
                {
                    
                   return actualizado;
                }
            }
            return actualizado;
        }
        IEnumerable<Deportista> IRepositorioDeportista.ListarDeportistas()
        {
            return _appContext.Deportistas;
        }
        // metodo que verifica la existencia de un nombre antes de guardarlo
        bool ValidarNombre(Deportista deportista)
        {
            bool existe=false;
            var mun=_appContext.Deportistas.FirstOrDefault(m=>m.Nombre==deportista.Nombre);
            if(mun!=null)
            {
                existe=true;
            }
            return existe;
        }

    }
}
