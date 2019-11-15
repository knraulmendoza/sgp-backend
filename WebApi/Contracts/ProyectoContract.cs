using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Contracts
{
    public interface ProyectoContract
    {
        [Route("api/{controller}/estado/{proyectoState}")]
        ICollection<Proyecto> GetProyectosPorEstado(ProyectoState proyectoState);

        [Route("api/{controller}/egresos/{idProyecto}")]
        IList<TransaccionUnaria> GetGastosProyectos(long idProyecto);
    }
}