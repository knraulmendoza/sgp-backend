using System;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public class FondoGlobal
    {
        public float PresupuestoTotal { get; set; }

        public IList<Movimiento> Movimientos { get; set; }

        public IDictionary<string, float> Fondos { get; set; }

        public static readonly Lazy<FondoGlobal> instance = new Lazy<FondoGlobal>(() => new FondoGlobal());

        private FondoGlobal()
        {
            Construir();
        }

        public void GenerarMovimiento(MovimientoType tipo, float monto, string nombreDelFondo, IDetalleDelMovimiento detalle)
        {
            if (tipo == MovimientoType.EGRESO) {
                Fondos[nombreDelFondo] -= monto;
            } else {
                Fondos[nombreDelFondo] += monto;
            }

            Movimientos.Add(new Movimiento() {
                Concepto = detalle.Concepto,
                Fecha = DateTime.Now,
                Tipo = tipo,
                Monto = monto,
                Detalle = detalle
            });

            RecalcularPresupuesto();
        }

        public static FondoGlobal GetInstance()
        {
            return instance.Value;
        }

        public void RecalcularPresupuesto()
        {
            float nuevoPresupuesto = 0;
            foreach (Movimiento m in Movimientos)
            {
                if (m.Tipo == MovimientoType.INGRESO)
                    nuevoPresupuesto += m.Monto;
                else
                    nuevoPresupuesto -= m.Monto;
            }
            PresupuestoTotal = nuevoPresupuesto;
        }

        public void AgregarMovimiento(Movimiento movimiento)
        {
            Movimientos.Add(movimiento);
        }

        public void Construir()
        {

        }
    }
}