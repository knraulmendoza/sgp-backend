using System;

namespace Dominio.Entities
{
    public class Consignación : IDetalleDelMovimiento
    {
        public float Valor { get; set; }

        public DateTime Fecha { get; set; }

        public ConsignaciónType Tipo { get; set; }

        public Consignación() { }
    }
}