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

        public bool CrearEscenario(Escenario obj)
        {
            bool creado=false;
            bool existe=ValidarNombre(obj);
            if(!existe)
            {
                try
                {
                    _appContext.Escenarios.Add(obj);
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
        public Escenario BuscarEscenario(int id)
        {
            return _appContext.Escenarios.Find(id);
        }
        public bool EliminarEscenario(int id)
        {
            bool eliminado=false;
            var esc=_appContext.Escenarios.Find(id);
            if(esc!=null)
            {
                try
                {
                     _appContext.Escenarios.Remove(esc);
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

        public bool ActualizarEscenario(Escenario obj)
        {
            bool actualizado= false;
            var esc=_appContext.Escenarios.Find(obj.Id);
            if(esc!=null)
            {
                try
                {
                     esc.Nombre=obj.Nombre;
                     esc.Direccion=obj.Direccion;
                     esc.Telefono=obj.Telefono;
                     esc.TorneoId=obj.TorneoId;
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
        public IEnumerable<Escenario> ListarEscenarios()
        {
            return _appContext.Escenarios;
            
        }
        public List<Escenario> ListarEscenarios1()
        {
            return _appContext.Escenarios.ToList();
        }
        // metodo que verifica la existencia de un nombre antes de guardarlo
        bool ValidarNombre(Escenario obj)
        {
            bool existe=false;
            var esc=_appContext.Escenarios.FirstOrDefault(e=>e.Nombre==obj.Nombre);
            if(esc!=null)
            {
                existe=true;
            }
            return existe;
        }

    }
}
