using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Torneo
    {
        public int Id{get; set;}
        public string Nombre{get; set;}
        public string Categoria{get; set;}
        public DateTime FechaInicio{get; set;}
        public DateTime FechaFin{get; set;}
        
        // Llave foránea para la relación con Municipio
        public int MunicipioId {get; set;}
        // Propiedad navigacional para la relación con TorneoEquipo
        public List<TorneoEquipo> TorneoEquipos {get; set;}
        //propiedad navigacional para la relacion con Escenario
	    public List<Escenario> Escenarios {get;set;}
        //propiedad navigacional para la relacion con Arbitro
	    public List<Arbitro> Arbitros {get;set;}
    }
}