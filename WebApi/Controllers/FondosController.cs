using System.Collections.Generic;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Entities.FondoGlobal;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FondosController
    {
        [HttpGet("/Api/Fondo/Fondos")]
        public IEnumerable<Fondo> GetFondos() => FondoGlobal.GetInstance().Fondos;

        [HttpGet("/Fondo/PresupuestoTotal")]
        public decimal GetPresupuesto() => FondoGlobal.GetInstance().PresupuestoTotal;
    }
}