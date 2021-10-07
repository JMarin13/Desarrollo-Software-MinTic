using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;


namespace Persistencia
{
    public class RepositorioCancha:IRepositorioCancha
    {
        // Atributos 
        private readonly AppContext _appContext;
        
        //Metodos
        //Constructor por defecto
        public RepositorioCancha(AppContext appContext)
        {
            _appContext=appContext;
        }

        bool IRepositorioCancha.CrearCancha(Cancha cancha)
        {
            bool creado=false;
            bool existe=ValidarNombre(cancha);
            if(!existe)
            {
                try
                {
                    _appContext.Canchas.Add(cancha);
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
        Cancha IRepositorioCancha.BuscarCancha(int idCancha)
        {
            /*var Cancha=_appContext.Canchas.Find(idCancha);
            return Cancha;*/
            return _appContext.Canchas.Find(idCancha);
        }
        bool IRepositorioCancha.EliminarCancha(int idCancha)
        {
            bool eliminado=false;
            var cancha=_appContext.Canchas.Find(idCancha);
            if(cancha!=null)
            {
                try
                {
                     _appContext.Canchas.Remove(cancha);
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

        bool IRepositorioCancha.ActualizarCancha(Cancha cancha)
        {
            bool actualizado= false;
            var mun=_appContext.Canchas.Find(cancha.Id);
            if(mun!=null)
            {
                try
                {
                     mun.Nombre=cancha.Nombre;
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
        IEnumerable<Cancha> IRepositorioCancha.ListarCanchas()
        {
            return _appContext.Canchas;
        }
        // metodo que verifica la existencia de un nombre antes de guardarlo
        bool ValidarNombre(Cancha cancha)
        {
            bool existe=false;
            var mun=_appContext.Canchas.FirstOrDefault(m=>m.Nombre==cancha.Nombre);
            if(mun!=null)
            {
                existe=true;
            }
            return existe;
        }

    }
}
