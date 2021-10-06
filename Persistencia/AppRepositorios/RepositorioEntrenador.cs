using System.Collections.Generic;
using Dominio;
using System.Linq;
using System;


namespace Persistencia
{
    public class RepositorioEntrenador:IRepositorioEntrenador //Se deben implementar los metodos que estan firmados
    {
        //Atributos
        private readonly AppContext _appContext;//_appContext es el atributo propio de la clase, no tiene ningun valor pero debe recibir un valor para poder trabajar
        //metodos
        //Constructor por defecto
        public RepositorioEntrenador(AppContext appContext)//rcive un argumento que es para el manejo de appContext
        {//cuando se use este contructor para instanciar uan clase de tipo 
            _appContext=appContext;//para el _appContext que es el que se utilizara para generar las transacciones sobre la Db, se le da el mismo valor que nos llega de appContext
        }
        bool IRepositorioEntrenador.CrearEntrenador(Entrenador entrenador)//se implementa desde donde esta lo firmado IRepositorioEntrenador 
        {
            bool creado=false;
            bool existe=ValidarDocumento(entrenador);// se llama el metodo validar con el objeto "entrenador" y se guarda en bool
            if(!existe)// si no existe
            {
                try
                {
                    _appContext.Entrenadores.Add(entrenador);//atravez del contexto "_appContext" a la tabla Entrenadores, adicionar un registro "entrenador"
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
        Entrenador IRepositorioEntrenador.BuscarEntrenador(int idEntrenador)// metodo crear buscar
        {
            /*var municipio=_appContext.Municipios.Find(idMunicipio);
            return municipio;*/
            return _appContext.Entrenadores.Find(idEntrenador);
        }

        bool IRepositorioEntrenador.EliminarEntrenador(int idEntrenador)
        {
            bool eliminado=false;
            var entrenador=_appContext.Entrenadores.Find(idEntrenador);
            if(entrenador!=null)
            {
                try
                {
                    _appContext.Entrenadores.Remove(entrenador);
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
        bool IRepositorioEntrenador.ActualizarEntrenador(Entrenador entrenador)
        {
            bool actualizado=false;
            var ent=_appContext.Entrenadores.Find(entrenador.Id);//se guarda en la var "ent" lo que se encontro en la lista
            if(ent!=null)
            {
                try
                {
                    ent.Documento=entrenador.Documento;
                    ent.Nombre=entrenador.Nombre;
                    ent.Apellido=ent.Apellido;
                    //ent.
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
        IEnumerable<Entrenador> IRepositorioEntrenador.ListarEntrenador()
        {
            return _appContext.Entrenadores;
        }
        //metodo que verifica la existencia de un nombre antes de guardarlo 
        bool ValidarDocumento(Entrenador entrenador)// recibe de tipo "Entrenador un entrenador con miniscula
        {
            bool existe=false;
            var ent=_appContext.Entrenadores.FirstOrDefault(e=>e.Documento==entrenador.Documento);//recorre toda la lista "Entrenadores", se crea un objeto anonimo sin tipo (e) y una anotacion landa (=>), se pregunta si ese documento del entrenador es igual al documento del "entrenador" que esta lleganf.
            if(ent!=null)            //FirstOrDefault es qeu se detenga cuando encuentre un resultado true
            {// cuando ent es diferente de null(nulo), es por que existe
                existe=true;
            }
            return existe;
        }

    }
}