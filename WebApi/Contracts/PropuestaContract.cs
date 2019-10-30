using System.Collections.Generic;
using Dominio.Entities;

public interface PropuestaContract
{
    public IList<Componente> GetComponentesPorDimension(long idDimension);
}