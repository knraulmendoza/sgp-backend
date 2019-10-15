using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Transaccion : BaseEntity
    {
        public DateTimer Fecha { get; set; }
        public float Monto { get; set; }
        public int Tipo { get; set; }

        public Transaccion() { }
    }
}
