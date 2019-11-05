using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Components;

public interface CertificadoDeDisponibilidadPresupuestalContract
{
    // Route[("api/[controller]/{idProyecto}/generar-cdp")]
    CertificadoDeDisponibilidadPresupuestal GenerarCertificadoDeDisponibilidadPresupuestal(long Proyecto, IDictionary<string, float> fondosYPresupuestos);


    // [HttpGet]
    // Route[("api/[controller]/{estado}/listarProyectos")]
    IEnumerable<Proyecto> GetListarProyectos(string estado) {}

    // Route[("api/[controller]/listarFondos")]
	IList<string, float> GetListarFondos();
    
}