using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;


namespace Persistencia
{
    public class RepositorioArbitro:IRepositorioArbitro
    {
        // Atributos 
        private readonly AppContext _appContext;
        
        //Metodos
        //Constructor por defecto
        public RepositorioArbitro(AppContext appContext)
        {
            _appContext=appContext;
        }

        bool IRepositorioArbitro.CrearArbitro(Arbitro arbitro)
        {
            bool creado=false;
            bool existe=ValidarNombre(arbitro);
            if(!existe)
            {
                try
                {
                    _appContext.Arbitros.Add(arbitro);
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
        Arbitro IRepositorioArbitro.BuscarArbitro(int idArbitro)
        {
            /*var arbitro=_appContext.Arbitros.Find(idarbitro);
            return arbitro;*/
            return _appContext.Arbitros.Find(idArbitro);
        }
        bool IRepositorioArbitro.EliminarArbitro(int idArbitro)
        {
            bool eliminado=false;
            var arbitro=_appContext.Arbitros.Find(idArbitro);
            if(arbitro!=null)
            {
                try
                {
                     _appContext.Arbitros.Remove(arbitro);
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

        bool IRepositorioArbitro.ActualizarArbitro(Arbitro arbitro)
        {
            bool actualizado= false;
            var mun=_appContext.Arbitros.Find(arbitro.Id);
            if(mun!=null)
            {
                try
                {
                     mun.Nombre=arbitro.Nombre;
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
        IEnumerable<Arbitro> IRepositorioArbitro.ListarArbitros()
        {
            return _appContext.Arbitros;
        }
        // metodo que verifica la existencia de un nombre antes de guardarlo
        bool ValidarNombre(Arbitro arbitro)
        {
            bool existe=false;
            var mun=_appContext.Arbitros.FirstOrDefault(m=>m.Nombre==arbitro.Nombre);
            if(mun!=null)
            {
                existe=true;
            }
            return existe;
        }

    }
}
