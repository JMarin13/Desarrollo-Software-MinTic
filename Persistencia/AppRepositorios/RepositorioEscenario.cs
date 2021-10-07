using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;


namespace Persistencia
{
    public class RepositorioEscenario:IRepositorioEscenario
    {
        // Atributos 
        private readonly AppContext _appContext;
        
        //Metodos
        //Constructor por defecto
        public RepositorioEscenario(AppContext appContext)
        {
            _appContext=appContext;
        }

        bool IRepositorioEscenario.CrearEscenario(Escenario escenario)
        {
            bool creado=false;
            bool existe=ValidarNombre(escenario);
            if(!existe)
            {
                try
                {
                    _appContext.Escenarios.Add(escenario);
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
        Escenario IRepositorioEscenario.BuscarEscenario(int idEscenario)
        {
            /*var escenario=_appContext.Escenarios.Find(idescenario);
            return escenario;*/
            return _appContext.Escenarios.Find(idEscenario);
        }
        bool IRepositorioEscenario.EliminarEscenario(int idEscenario)
        {
            bool eliminado=false;
            var escenario=_appContext.Escenarios.Find(idEscenario);
            if(escenario!=null)
            {
                try
                {
                     _appContext.Escenarios.Remove(escenario);
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

        bool IRepositorioEscenario.ActualizarEscenario(Escenario escenario)
        {
            bool actualizado= false;
            var mun=_appContext.Escenarios.Find(escenario.Id);
            if(mun!=null)
            {
                try
                {
                     mun.Nombre=escenario.Nombre;
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
        IEnumerable<Escenario> IRepositorioEscenario.ListarEscenarios()
        {
            return _appContext.Escenarios;
        }
        // metodo que verifica la existencia de un nombre antes de guardarlo
        bool ValidarNombre(Escenario escenario)
        {
            bool existe=false;
            var mun=_appContext.Escenarios.FirstOrDefault(m=>m.Nombre==escenario.Nombre);
            if(mun!=null)
            {
                existe=true;
            }
            return existe;
        }

    }
}
