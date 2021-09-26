using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Municipio
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        
        // Propiedad navigacional para la relación con Torneo
        public List<Torneo> Torneos {get; set;}
    }
}