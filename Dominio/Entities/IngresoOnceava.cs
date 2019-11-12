using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class IngresoOnceava : BaseEntity
    {
        public decimal Valor { get; set; }
        public decimal Interes { get; set; }
        public Documento SoporteValor { get; set; }
        public Documento SoporteInteres { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public IngresoOnceava() { }
    }
}