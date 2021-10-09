using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;


namespace Persistencia
{
    public class RPatrocinador:IRPatrocinador
    {
        // Atributos 
        private readonly AppContext _appContext;
        
        //Metodos
        //Constructor por defecto
        public RPatrocinador(AppContext appContext)
        {
            _appContext=appContext;
        }

        public bool CrearPatrocinador(Patrocinador patrocinador)
        {
            bool creado=false;
            bool existe=ValidarIdentificacion(patrocinador);
            if(!existe)
            {
                try
                {
                    _appContext.Patrocinadores.Add(patrocinador);
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
        public Patrocinador BuscarPatrocinador(int idPatrocinador)
        {
            /*var municipio=_appContext.Municipios.Find(idMunicipio);
            return municipio;*/
            return _appContext.Patrocinadores.Find(idPatrocinador);
        }
        public bool EliminarPatrocinador(int idPatrocinador)
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

        public bool ActualizarPatrocinador(Patrocinador patrocinador)
        {
            bool actualizado= false;
           // bool existe=ValidarIdentificacion(patrocinador);
            //if(!existe)
           // {
                var pat=_appContext.Patrocinadores.Find(patrocinador.Id);
                if(pat!=null)
                {
                    try
                    {
                        pat.Identificacion=patrocinador.Identificacion;
                        pat.Nombre=patrocinador.Nombre;
                        pat.Direccion=patrocinador.Direccion;
                        pat.Telefono=patrocinador.Telefono;
                        pat.TipoPersona=patrocinador.TipoPersona;
                        pat.Correo=patrocinador.Correo;
                        _appContext.SaveChanges();
                        actualizado=true;
                    }
                    catch (System.Exception)
                    {
                        
                         return actualizado;
                    }
                }
           // }            
            return actualizado;
        }
        public IEnumerable<Patrocinador> ListarPatrocinadores()
        {
            return _appContext.Patrocinadores;
        }

        public List<Patrocinador> ListarPatrocinadores1()
        {
            return _appContext.Patrocinadores.ToList();
        }

        // metodo que verifica la existencia de un nombre antes de guardarlo
        bool ValidarIdentificacion(Patrocinador obj)
        {
            bool existe=false;
            var patrocinador=_appContext.Patrocinadores.FirstOrDefault(p=>p.Identificacion==obj.Identificacion);
            if(patrocinador!=null)
            {
                existe=true;
            }
            return existe;
        }

    }
}
