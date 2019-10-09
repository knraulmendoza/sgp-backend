using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    class Convenio : BaseEntity
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaDeSuscripcion { get; set; }
        public short Plazo { get; set; }
        public float Valor { get; set; }
        public string objeto { get; set; }
    }
}
