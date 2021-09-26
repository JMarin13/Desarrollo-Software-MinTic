using System;
using System.Collections.Generic;

namespace Dominio
{
    public class TorneoEquipo
    {
        public int EquipoId {get; set;}
        public int TorneoId {get; set;}
        
        // Propiedad navigacional para relación con Equipo
        public Equipo Equipo {get; set;}
        // Propiedad navigacional para relación con Torneo
        public Torneo Torneo {get; set;}
    }
}