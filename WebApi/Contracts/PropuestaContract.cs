using System.Collections.Generic;
using Dominio.Entities;

public interface PropuestaContract
{
    IList<Componente> GetComponentesPorDimension(long idDimension);
    File getFileProject(long idProyecto);
}