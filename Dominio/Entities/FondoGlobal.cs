using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entities
{
    public class FondoGlobal
    {
        [NotMapped]
        public class Fondo
        {
            public string Nombre { get; set; }

            public decimal Presupuesto { get; set; }

            public ICollection<Movimiento> Movimientos { get; set; }
        }

        public decimal PresupuestoTotal { get; set; }

        public IList<Movimiento> Movimientos { get; set; }

        public ICollection<Fondo> Fondos { get; set; }

        public Fondo GetFondo(string nombreFondo)
        {
            foreach (Fondo fondo in Fondos)
            {
                if (fondo.Nombre == nombreFondo) return fondo;
            }
            return null;
        }

        public static readonly Lazy<FondoGlobal> instance = new Lazy<FondoGlobal>(() => new FondoGlobal());

        private FondoGlobal()
        {
            Construir();
        }

        public void GenerarMovimiento(MovimientoType tipo, Fondo fondo, decimal monto)
        {
            if (tipo == MovimientoType.EGRESO)
            {
                fondo.Presupuesto -= monto;
            }
            else
            {
                fondo.Presupuesto += monto;
            }

            Movimientos.Add(new Movimiento()
            {
                //Concepto = detalle.Concepto,
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

            Fondos = new List<Fondo>()
            {
                new Fondo()
                {
                    Nombre = "Fondo 1",
                    Presupuesto = 1000000000
                },
                new Fondo()
                {
                    Nombre = "Fondo 2",
                    Presupuesto = 200000000
                },
                new Fondo()
                {
                    Nombre = "Fondo 3",
                    Presupuesto = 400000000
                }
            };

            foreach (var fondo in Fondos)
            {
                PresupuestoTotal += fondo.Presupuesto;
            }
        }
    }
}