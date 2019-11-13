using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Transaccion : BaseEntity
    {
        public DateTime Fecha { get; set; }

        public float Monto { get; set; }

        public long IdProyecto { get; set; }
        
        public Proyecto Proyecto { get; set; }

        public TransaccionType Tipo { get; set; }

        public Transaccion() { }
    }
}
