using System.Collections.Generic;
using Dominio.Entities;

public interface CertificadoDeDisponibilidadPresupuestalContract
{
    Route[("api/[controller]/{idProyecto}/generar-cdp")]
    CertificadoDeDisponibilidadPresupuestal GenerarCertificadoDeDisponibilidadPresupuestal(long idProyecto, IDictionary<string, float> fondosYPresupuestos);

    Route[("api/[controller]/listarProyectosCDPEmitidos")]
	IEnumerable<Proyecto> GetListarProyectosCDPemitidos();

    Route[("api/[controller]/listarFondos")]
	IList<string, float> GetListasFondos();
    
}