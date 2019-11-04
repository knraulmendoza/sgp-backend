using System.Collections.Generic;
using Dominio.Entities;

public interface EmitirCDPContract
{
    CDP GenerarCDP(Proyecto proyecto, IDictionary<string, float> fondosYPresupuestos);	
	IEnumerable<Proyecto> GetListarProyectosCDPemitidos();
	IList<string, float> GetListasFondos();
    
}