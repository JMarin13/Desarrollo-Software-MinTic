using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioTorneo : IRepositorioTorneo
    {
        private readonly AppContext _appContext;
    
        public RepositorioTorneo(AppContext appContext)
        {
            _appContext=appContext;
        }

        bool IRepositorioTorneo.CrearTorneo(Torneo torneo)// metodo crear torneo
        {
            bool creado=false;
            bool existe=ValidarNombre(torneo);// se llama el metodo validar con el objeto "torneo" y se guarda en bool
            if(!existe) // si no existe
            {
                try
                {
                    _appContext.Torneos.Add(torneo);
                    _appContext.SaveChanges();
                    creado= true;

                }
                catch (System.Exception)
                {
                    return creado;               
                }
            }
            return creado;
        }
        Torneo IRepositorioTorneo.BuscarTorneo(int idTorneo)
        {
            return _appContext.Torneos.Find(idTorneo);
        }
        bool IRepositorioTorneo.EliminarTorneo(int idTorneo)
        {
            bool eliminado=false;
            var torneo=_appContext.Torneos.Find(idTorneo);
            if(torneo!=null)
            {
                try
                {
                     _appContext.Torneos.Remove(torneo);
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

        bool IRepositorioTorneo.ActualizarTorneo(Torneo torneo)
        {
            bool actualizado= false;
            var tor=_appContext.Torneos.Find(torneo.Id);
            if(tor!=null)
            {
                try
                {
                     tor.Nombre=torneo.Nombre;
                     tor.Categoria=torneo.Categoria;
                     tor.FechaInicio=torneo.FechaInicio;
                     tor.FechaFinal=torneo.FechaFinal;
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
        IEnumerable<Torneo> IRepositorioTorneo.ListarTorneos()
        {
            return _appContext.Torneos;
        }
         //metodo que verifica la existencia de un nombre antes de guardarlo 
        bool ValidarNombre(Torneo torneo)// recibe de tipo "Torneo" un torneo con miniscula
        {
            bool existe=false;
            var tor=_appContext.Torneos.FirstOrDefault(t=>t.Nombre==torneo.Nombre);//recorre toda la lista "torneos", se crea un objeto anonimo sin tipo (t) y una anotacion landa (=>), se pregunta si ese nombre del torneo es igual al nombre del "torneo" que esta lleganf.
            if(tor!=null)            //FirstOrDefault es qeu se detenga cuando encuentre un resultado true
            {// cuando tor es diferente de null(nulo), es por que existe
                existe=true;
            }
            return existe;
        }

    }
}