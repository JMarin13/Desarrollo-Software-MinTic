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

        public bool CrearDeportista(Deportista obj)
        {
            bool creado=false;
            bool existe=ValidarNombre(obj);
            if(!existe)
            {
                try
                {
                    _appContext.Deportistas.Add(obj);
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
        public Deportista BuscarDeportista(int id)
        {
            return _appContext.Deportistas.Find(id);
        }

        public bool EliminarDeportista(int id)
        {
            bool eliminado=false;
            var deportista=_appContext.Deportistas.Find(id);
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

        public bool ActualizarDeportista(Deportista obj)
        {
            bool actualizado= false;
            var mun=_appContext.Deportistas.Find(obj.Id);
            if(mun!=null)
            {
                try
                {
                     mun.Nombres=obj.Nombres;
                     mun.Documento=obj.Documento;
                     mun.Apellidos=obj.Apellidos;
                     mun.Genero=obj.Genero;
                     mun.Direccion=obj.Direccion;
                     mun.Celular=obj.Celular;
                     mun.Correo=obj.Correo;
                     mun.Rh=obj.Rh;
                     mun.EPS=obj.EPS;
                     mun.FechaNacimiento=obj.FechaNacimiento;
                     mun.EquipoId=obj.EquipoId;
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
        public IEnumerable<Deportista> ListarDeportistas()
        {
            return _appContext.Deportistas;
        }

        public List<Deportista> ListarDeportistas1()
        {
            return _appContext.Deportistas.ToList();
        }
        // metodo que verifica la existencia de un nombre antes de guardarlo
        bool ValidarNombre(Deportista obj)
        {
            bool existe=false;
            var mun=_appContext.Deportistas.FirstOrDefault(m=>m.Nombres==obj.Nombres);
            if(mun!=null)
            {
                existe=true;
            }
            return existe;
        }

    }
}
