using System.Collections.Generic;
using Dominio.Entities;

public interface CertificadoDeDisponibilidadPresupuestalContract
{
    Route[("api/[controller]/{idProyecto}/generar-cdp")]
    CertificadoDeDisponibilidadPresupuestal GenerarCertificadoDeDisponibilidadPresupuestal(long idProyecto, IDictionary<string, float> fondosYPresupuestos);

    Route[("api/[controller]/listarProyectosCDPEmitidos")]
	IEnumerable<Proyecto> GetListarProyectosCDPEmitidos();
    IEnumerable<Proyecto> GetListarProyectosParaEmitirCDP();

    Route[("api/[controller]/listarFondos")]
	IList<string, float> GetListarFondos();
    
}