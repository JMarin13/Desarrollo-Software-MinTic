using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;

namespace Persistencia
{
    public class RepositorioPatrocinador : IRepositorioPatrocinador
    {
        private readonly AppContext _appContext;
    
        public RepositorioPatrocinador(AppContext appContext)
        {
            _appContext=appContext;
        }

        bool IRepositorioPatrocinador.CrearPatrocinador(Patrocinador patrocinador)
        {
            bool creado=false;
            try
            {
                _appContext.Patrocinadores.Add(patrocinador);
                _appContext.SaveChanges();
                creado= true;
                 
            }
            catch (System.Exception)
            {
                return creado;               
            }
            return creado;
        }
        Patrocinador IRepositorioPatrocinador.BuscarPatrocinador(int idPatrocinador)
        {
            return _appContext.Patrocinadores.Find(idPatrocinador);
        }
        bool IRepositorioPatrocinador.EliminarPatrocinador(int idPatrocinador)
        {
            bool eliminado=false;
            var patrocinador=_appContext.Patrocinadores.Find(idPatrocinador);
            if(patrocinador!=null)
            {
                try
                {
                     _appContext.Patrocinadores.Remove(patrocinador);
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

        bool IRepositorioPatrocinador.ActualizarPatrocinador(Patrocinador patrocinador)
        {
            bool actualizado= false;
            var mun=_appContext.Patrocinadores.Find(patrocinador.Id);
            if(mun!=null)
            {
                try
                {
                     mun.Nombre=patrocinador.Nombre;
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
        IEnumerable<Patrocinador> IRepositorioPatrocinador.ListarPatrocinadores()
        {
            return _appContext.Patrocinadores;
        }
    }
}