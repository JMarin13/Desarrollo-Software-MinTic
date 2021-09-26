using System;
using System.Collections.Generic;

namespace Dominio
{
    public class ColegioArbitral
    {
        public int Id {get; set;}
        public string Nit {get; set;}
        public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Resolucion {get; set;}
        public string Telefono {get; set;}
        public string correo {get; set;}

        //propiedad navigacional para la relacion con Arbitro
	    public List<Arbitro> Arbitros {get;set;}
    }
}