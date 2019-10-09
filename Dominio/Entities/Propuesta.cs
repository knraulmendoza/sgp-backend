using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Propuesta : BaseEntity
    {
        public long Id { get; set; }
        public DateTime FechaDePresentación { get; set; }
        public DateTime FechaDeAprovacion {get; set;}
        public File Documento {get; set;}
        public int PropuestaState {get; set;}

    }
}
