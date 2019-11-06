
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Contracts
{
    public interface EgresoContract
    {
         [Route("api/{controller}/{proyectoState}")]
        IList<Proyecto> GetProyectosConRP(string proyectoState);

        [Route("api/{controller}/{idProyecto}")]
        IList<Egreso> GetGastosProyectos(long idProyecto);
    }
}