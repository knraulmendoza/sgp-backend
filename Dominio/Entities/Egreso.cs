using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities
{
    public class Egreso : Movimiento
    {
        [ForeignKey("Proyecto")]
        public long ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }
        public Egreso() { }
    }
}