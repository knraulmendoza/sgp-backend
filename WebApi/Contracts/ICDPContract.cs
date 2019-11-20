using System.Collections.Generic;
using Dominio.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Entities.FondoGlobal;

public interface ICDPContract
{
    // Route[("api/[controller]/{idProyecto}/generar-cdp")]
    ActionResult<CDP> GenerarCDP(long Proyecto, IEnumerable<KeyValuePair<string, decimal>> fondos);

    // [HttpGet]
    // Route[("api/[controller]/{estado}/listarProyectos")]
    IEnumerable<Proyecto> GetListarProyectos(string estado);

    // Route[("api/[controller]/listarFondos")]
	IEnumerable<Fondo> GetListarFondos();
    
}