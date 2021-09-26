using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Entrenador
    {
        public int Id {get; set;}
        public string Documento {get; set;}
        public string Nombres {get; set;}
        public string Apellidos {get; set;}
        public string Genero {get; set;}
        public string Nombre {get; set;}
        
        // Llave foránea para la relación con Equipo
        public int EquipoId {get;set;}
    }
}