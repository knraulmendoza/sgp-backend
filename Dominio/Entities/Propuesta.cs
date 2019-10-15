using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Propuesta : BaseEntity
    {
        public DateTime FechaDePresentación { get; set; }
        public DateTime FechaDeAprovacion {get; set;}
        //public File Documento {get; set;}
        //public int PropuestaState {get; set;}

        public Propuesta() { }
    }
}
