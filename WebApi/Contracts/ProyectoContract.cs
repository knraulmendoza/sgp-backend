using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Contracts
{
    public interface ProyectoContract
    {
        [Route("api/{controller}/estado/{proyectoState}")]
        ActionResult<ICollection<Proyecto>> GetProyectosPorEstado(ProyectoState proyectoState);

        [Route("api/{controller}/egresos/{idProyecto}")]
        ActionResult<IList<TransaccionUnaria>> GetGastosProyectos(long idProyecto);
    }
}