using System.Collections.Generic;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Entities.FondoGlobal;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class FondosController
    {
        [HttpGet]
        public IEnumerable<Fondo> GetFondos() => FondoGlobal.GetInstance().Fondos;

        [HttpGet("PresupuestoTotal")]
        public decimal GetPresupuesto() => FondoGlobal.GetInstance().PresupuestoTotal;

        private void construirFondo() {
            UnitOfWork uow = new UnitOfWork();

            // Comentado por dañar el sistema
            // uow.MovimientoRepository.Get().ForEach();
        }

    }

}