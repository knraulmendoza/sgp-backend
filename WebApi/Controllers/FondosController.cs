using System.Collections.Generic;
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

        [HttpGet("UltimasTransacciones")]
        public IEnumerable<Fondo, IEnumerable<Movimiento>> GetFondosConLosDiezUltimosMovimientos() {
            
        }
    }

}