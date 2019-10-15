using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Convenio : BaseEntity
    {
        public string Codigo { get; set; }
        public DateTime FechaDeSuscripcion { get; set; }
        public short Plazo { get; set; }
        public float Valor { get; set; }
        public string objeto { get; set; }

        public Convenio() { }
        
    }
}
