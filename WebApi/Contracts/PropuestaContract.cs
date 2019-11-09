using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

public interface PropuestaContract
{
    IList<Componente> GetComponentesPorDimension(long idDimension);
    
    [Route("api/[controller]/{idProyecto}/documento")]
    byte[] GetArchivoDelProyecto(long idProyecto);

}