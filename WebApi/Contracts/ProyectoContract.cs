using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Contracts
{
    public interface ProyectoContract
    {
        [Route("api/{controller}/{proyectoState}")]
        ICollection<Proyecto> GetProyectosPorEstado(ProyectoState proyectoState);

        [Route("api/{controller}/{idProyecto}/gastos")]
        IList<TransacciónUnaria> GetGastosProyectos(long idProyecto);
    }
}