using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

public interface PropuestaContract
{
    IList<Componente> GetComponentesPorDimension(long idDimension);
    
    [Route("api/[controller]/{idProyecto}/documento")]
    byte[] GetArchivoDelProyecto(long idProyecto);

}