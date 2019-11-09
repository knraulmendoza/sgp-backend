using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

public interface CertificadoDeDisponibilidadPresupuestalContract
{
    // Route[("api/[controller]/{idProyecto}/generar-cdp")]
    ActionResult<CertificadoDeDisponibilidadPresupuestal> GenerarCertificadoDeDisponibilidadPresupuestal(long Proyecto, IDictionary<string, decimal> fondosYPresupuestos);

    // [HttpGet]
    // Route[("api/[controller]/{estado}/listarProyectos")]
    IEnumerable<Proyecto> GetListarProyectos(string estado);

    // Route[("api/[controller]/listarFondos")]
	IDictionary<string, decimal> GetListarFondos();
    
}