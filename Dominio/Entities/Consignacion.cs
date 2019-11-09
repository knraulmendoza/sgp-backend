using System;

namespace Dominio.Entities
{
    public class Consignación : IDetalleDelMovimiento
    {
        public decimal Valor { get; set; }

        public DateTime Fecha { get; set; }

        public ConsignaciónType Tipo { get; set; }
        public string Concepto { get; set; }

        public Consignación() { }
    }
}