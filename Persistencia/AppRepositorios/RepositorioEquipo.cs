using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;


namespace Persistencia
{
    public class RepositorioEquipo:IRepositorioEquipo //Se deben implementar los metodos que estan firmados
    {
        //Atributos
        private readonly AppContext _appContext;//_appContext es el atributo propio de la clase, no tiene ningun valor pero debe recibir un valor para poder trabajar
        //metodos
        //Constructor por defecto
        public RepositorioEquipo(AppContext appContext)//rcive un argumento que es para el manejo de appContext
        {//cuando se use este contructor par ainstanciar uan clase de tipo 
            _appContext=appContext;//para el _appContext que es el que se utilizara para generar las transacciones sobre la Db, se le da el mismo valor que nos llega de appContext
        }
        bool IRepositorioEquipo.CrearEquipo(Equipo equipo)//se implementa desde donde esta lo firmado IRepositorioEquipo 
        {
            bool creado=false;
            bool existe=ValidarNombre(equipo);// se llama el metodo validar con el objeto "equipo" y se guarda en bool
            if(!existe)// si no existe
            {
                try
                {
                    _appContext.Equipos.Add(equipo);//atravez del contexto "_appContext" a la tabla Equipos, adicionar un registro "equipo"
                    _appContext.SaveChanges();//Se guarda
                    creado=true;
                }
                catch (System.Exception)
                {
                    return creado;
                }

            }
            return creado;
        }
        Equipo IRepositorioEquipo.BuscarEquipo(int idEquipo)
        {
            return _appContext.Equipos.Find(idEquipo);
        }

        bool IRepositorioEquipo.EliminarEquipo(int idEquipo)
        {
            bool eliminado=false;
            var equipo=_appContext.Equipos.Find(idEquipo);
            if(equipo!=null)
            {
                try
                {
                    _appContext.Equipos.Remove(equipo);
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
        bool IRepositorioEquipo.ActualizarEquipo(Equipo equipo)
        {
            bool actualizado=false;
            var equi=_appContext.Equipos.Find(equipo.Id);//se guarda en la var "equi" lo que se encontro en la lista
            if(equi!=null)
            {
                try
                {
                    equi.Nombre=equipo.Nombre;
                    equi.Deporte=equipo.Deporte;
                    equi.FechaCreacion=equi.FechaCreacion;
                    //equi.
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
        IEnumerable<Equipo> IRepositorioEquipo.ListarEquipo()
        {
            return _appContext.Equipos;
        }
        //metodo que verifica la existencia de un nombre antes de guardarlo 
        bool ValidarNombre(Equipo equipo)// recibe de tipo "Equipo un equipo con miniscula
        {
            bool existe=false;
            var equ=_appContext.Equipos.FirstOrDefault(e=>e.Nombre==equipo.Nombre);//recorre toda la lista "equipos", se crea un objeto anonimo sin tipo (e) y una anotacion landa (=>), se pregunta si ese nombre del equipo es igual al nombre del "equipo" que esta lleganf.
            if(equ!=null)            //FirstOrDefault es qeu se detenga cuando encuentre un resultado true
            {// cuando equ es diferente de null(nulo), es por que existe
                existe=true;
            }
            return existe;
        }



    }
}