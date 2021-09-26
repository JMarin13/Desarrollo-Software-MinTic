using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Equipo
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Deporte {get; set;}
        public DateTime FechaCreacion {get; set;}
        
        // Propiedad navigacional para la relación con Entrenador
        public Entrenador Entrenador {get; set;}
        // Propiedad navigacional para la relación con Deportista
        public List<Deportista> Deportistas {get; set;}
        // Llave foránea para la relación con Patrocinador
        public int PatrocinadorId {get; set;}
        // Propiedad navigacional para la relación con TorneoEquipo
        public List<TorneoEquipo> TorneoEquipos {get; set;}
    }
}