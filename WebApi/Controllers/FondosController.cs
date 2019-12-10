using System.Collections.Generic;
using System.Linq;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Entities.FondoGlobal;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class FondosController
    {
        [HttpGet]
        public IEnumerable<Fondo> GetFondos() => FondoGlobal.GetInstance().Fondos;

        [HttpGet("PresupuestoTotal")]
        public decimal GetPresupuesto() => FondoGlobal.GetInstance().PresupuestoTotal;

        [HttpGet("Fondos/UltimosMovimientos")]
        public IDictionary<string, ICollection<Movimiento>> GetFondosConSusÚltimosCincoMovimientos()
        {
            UnitOfWork uow = new UnitOfWork();

            IDictionary<string, ICollection<Movimiento>> fondos = new Dictionary<string, ICollection<Movimiento>>();

            foreach (var fondo in FondoGlobal.GetInstance().Fondos)
            {
                fondos.Add(
                    fondo.Nombre,
                    uow.MovimientoRepository.Get(m => m.NombreDelFondo == fondo.Nombre).Take(5).ToList()
                    );
            }

            return fondos;
        }
    }

}