using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Contracts
{
    public interface ProyectoContract
    {
        // [HttpGet("api/{controller}/estado/{proyectoState}")]
        ActionResult<IList<Proyecto>> GetProyectosPorEstado(ProyectoState proyectoState);

        // [HttpGet("api/{controller}/egresos/{idProyecto}")]
        ActionResult<IList<TransaccionUnaria>> GetGastosProyectos(long idProyecto);
    }
}