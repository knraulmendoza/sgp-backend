using System.Collections.Generic;
using System.Linq;
using Dominio.Entities;
using Infraestructura.Utils;
using static Dominio.Entities.FondoGlobal;

namespace Dominio
{
    public class FondosRepository
    {
        private void construirFondo(string nombre)
        {
            UnitOfWork uow = new UnitOfWork();

            decimal ingresos = uow.MovimientoRepository.Get(
                m => m.Tipo == MovimientoType.INGRESO &&
                    m.NombreDelFondo == nombre).Sum(m => m.Monto);

            decimal egresos = uow.MovimientoRepository.Get(
                m => m.Tipo == MovimientoType.EGRESO &&
                    m.NombreDelFondo == nombre).Sum(m => m.Monto);

            Fondo fondo = FondoGlobal.GetInstance().Fondos
                                    .Where(f => f.Nombre == nombre)
                                    .FirstOrDefault();
                                    
            fondo.Presupuesto = ingresos - egresos;
            fondo.Movimientos = uow.MovimientoRepository.Get(m => m.NombreDelFondo == nombre).ToList();
        }

        public void ConstruirFondoGlobal() {
            UnitOfWork uow = new UnitOfWork();

            var ingresos = uow.MovimientoRepository.Get(m => m.Tipo == MovimientoType.INGRESO)
                                                    .Sum(m => m.Monto);

            var egresos = uow.MovimientoRepository.Get(m => m.Tipo == MovimientoType.EGRESO)
                                                    .Sum(m => m.Monto);

            FondoGlobal.GetInstance().PresupuestoTotal = ingresos - egresos;
            FondoGlobal.GetInstance().Movimientos = uow.MovimientoRepository.Get().ToList();
            FondoGlobal.GetInstance().Fondos = new List<Fondo>() {
                new Fondo()
                {
                    Nombre = "Intereses"
                },
                new Fondo()
                {
                    Nombre = "Sistema general de participación"
                },
                new Fondo()
                {
                    Nombre = "Vigencias anteriores"
                },
                new Fondo()
                {
                    Nombre = "Libre"
                }
            };

            foreach (var fondo in FondoGlobal.GetInstance().Fondos)
            {
                construirFondo(fondo.Nombre);
            }
        }
    }
}