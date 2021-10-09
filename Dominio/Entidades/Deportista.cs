using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Deportista
    {
        public int Id {get; set;}
        public string Documento {get; set;}
        public string Nombre {get; set;}
        public string Apellidos {get; set;}
        public string Direccion {get; set;}
        public string Celular {get; set;}
        public string Correo {get; set;}
        public string Rh {get; set;}
        public string Eps {get; set;}
        public string Genero {get; set;}
        public DateTime FechaNacimiento {get; set;}
        
        // Llave foránea para la relación con Equipo
        public int EquipoId {get; set;}
    }
}
