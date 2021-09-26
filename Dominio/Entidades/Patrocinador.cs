using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Patrocinador
    {
        public int Id {get; set;}
        public string Identificacion {get; set;}
        public string Nombre {get; set;}
        public string Direccion {get; set;}
        public string Telefono {get; set;}
        public string TipoPersona {get; set;}
        public string Correo {get; set;}
        
        // Propiedad navigacional para la relación con Equipo
        public List<Equipo> Equipos {get; set;}
    }
}