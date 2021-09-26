using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Cancha
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Disciplina {get; set;}
        public int CantidadEspectadores {get; set;}
        public string Medidas {get; set;}

        //llave foránea de la relación con Escenario
        public int EscenarioId {get;set;}
    }
}