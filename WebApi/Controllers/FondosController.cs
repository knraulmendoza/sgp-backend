using System.Collections.Generic;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FondosController
    {
        [HttpGet("/Api/Fondo/Fondos")]
        public IDictionary<string, decimal> GetFondos() => FondoGlobal.GetInstance().Fondos;

        [HttpGet("/Fondo/PresupuestoTotal")]
        public decimal GetPresupuesto() => FondoGlobal.GetInstance().PresupuestoTotal;
    }
}