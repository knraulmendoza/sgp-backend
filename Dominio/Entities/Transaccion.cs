using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dominio.Entities
{
    public class Transaccion : BaseEntity
    {
        public DateTime Fecha { get; set; }
        
        public decimal Monto { get; set; }

        [ForeignKey("Proyecto")]
        public long ProyectoId { get; set; }

        public Proyecto Proyecto { get; set; }

        public TransaccionType Tipo { get; set; }

        public Transaccion() { }
    }
}
