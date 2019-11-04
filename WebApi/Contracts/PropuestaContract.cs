using System.Collections.Generic;
using Dominio.Entities;

public interface PropuestaContract
{
    IList<Componente> GetComponentesPorDimension(long idDimension);
    char[] getFileProject(long idProyecto);
}