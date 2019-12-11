using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities
{
    public class Movimiento : BaseEntity
    {
        public decimal Monto { get; set; }
        
        public DateTime Fecha { get; set; }

        public MovimientoType Tipo { get; set; }

        public string Concepto { get; set; }

        [NotMapped]
        public IDetalleDelMovimiento Detalle { get; set; }

        public string NombreDelFondo { get; set; }

        public Movimiento() { }
    }
}