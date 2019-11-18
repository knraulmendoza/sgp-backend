using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Transaccion : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public long ProyectoId { get; set; }

        public TransaccionType Tipo { get; set; }

        public Transaccion() { }
    }
}
