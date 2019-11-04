using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class IngresoGeneral : BaseEntity
    {
        public double Valor { get; set; }
        public double Interes { get; set; }
        public string SoporteValor { get; set; }
        public string SoporteInteres { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public IngresoGeneral() { }
    }
}