using System;
using System.Collections.Generic;

namespace Dominio.Entities
{
    public class FondoGlobal
    {
        public decimal PresupuestoTotal { get; set; }

        public IList<Movimiento> Movimientos { get; set; }

        public IDictionary<string, decimal> Fondos { get; set; }

        public static readonly Lazy<FondoGlobal> instance = new Lazy<FondoGlobal>(() => new FondoGlobal());

        private FondoGlobal()
        {
            Construir();
        }

        public void GenerarMovimiento(MovimientoType tipo, decimal monto, string nombreDelFondo, IDetalleDelMovimiento detalle)
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
            });

            RecalcularPresupuesto();
        }

        public static FondoGlobal GetInstance()
        {
            return instance.Value;
        }

        public void RecalcularPresupuesto()
        {
            decimal nuevoPresupuesto = 0;
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
            Fondos = new Dictionary<string, decimal>();

            Fondos.Add("Fondo 1", 100000000);
            Fondos.Add("Fondo 2", 200000000);
            Fondos.Add("Fondo 3", 400000000);

            foreach (var fondo in Fondos)
            {
                PresupuestoTotal += fondo.Value;
            }
        }
    }
}