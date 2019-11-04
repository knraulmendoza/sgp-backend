using System;

namespace Dominio.Entities
{
    public class Movimiento
    {
        public float Monto {get;set;}

        public DateTime Fecha {get;set;}

        public MovimientoType Tipo {get;set;}

        public string Concepto {get;set;}

        public IDetalleDelMovimiento Detalle {get;set;}

        public Movimiento() {}
    }
}