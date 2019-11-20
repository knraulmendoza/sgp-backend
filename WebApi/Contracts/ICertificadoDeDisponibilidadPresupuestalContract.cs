using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Entities.FondoGlobal;

public interface ICertificadoDeDisponibilidadPresupuestalContract
{
    // Route[("api/[controller]/{idProyecto}/generar-cdp")]
    ActionResult<CertificadoDeDisponibilidadPresupuestal> GenerarCertificadoDeDisponibilidadPresupuestal(long Proyecto, IDictionary<string, decimal> fondosYPresupuestos);

    // [HttpGet]
    // Route[("api/[controller]/{estado}/listarProyectos")]
    IEnumerable<Proyecto> GetListarProyectos(string estado);

    // Route[("api/[controller]/listarFondos")]
	IEnumerable<Fondo> GetListarFondos();
    
}