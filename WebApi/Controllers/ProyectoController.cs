using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Contracts;
/* Estados para la propuesta */
using Dominio.Entities.States;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectoController : GenericController<Proyecto>, ProyectoContract
    {
        private UnitOfWork uow;

        [HttpDelete]
        public ActionResult<Proyecto> Delete(long id)
        {
            uow = new UnitOfWork();
            Proyecto res = uow.ProyectoRepository.GetByID(id);
            uow.ProyectoRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<Proyecto> Get(long id)
        {
            uow = new UnitOfWork();
            Proyecto res = uow.ProyectoRepository.Get(p => p.Id == id, includeProperties: "Beneficiarios,Propuesta")
                .FirstOrDefault();
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Proyecto>> GetAll()
        {
            uow = new UnitOfWork();
            IEnumerable<Proyecto> res = uow.ProyectoRepository.Get(includeProperties: "Propuesta");
            uow.Dispose();
            return res.ToList();
        }

        
        [HttpGet("egresos/{id}")]
        public ActionResult<IEnumerable<TransaccionUnaria>> GetGastosProyectos(long id)
        {
            uow = new UnitOfWork();
            var proyecto = uow.ProyectoRepository.Get(filter: p => p.Id == id, includeProperties: "TransaccionesUnarias").FirstOrDefault(); // uow.TransaccionUnariaRepository.Get(t => t.ProyectoId == id);
            if (proyecto == null)
            {
                return new NotFoundResult();
            }
            else
            {
                var r = from t in proyecto.TransaccionesUnarias
                        where t.Tipo == TransaccionType.EGRESO
                        select t;
                return new ActionResult<IEnumerable<TransaccionUnaria>>(r);
            }
        }

        [HttpGet("ingresos/{idProyecto}")]
       public ActionResult<IEnumerable<TransaccionUnaria>> GetIngresosProyectos(long id)
        {
            uow = new UnitOfWork();
            var proyecto = uow.ProyectoRepository.Get(filter: p => p.Id == id, includeProperties: "TransaccionesUnarias").FirstOrDefault(); // uow.TransaccionUnariaRepository.Get(t => t.ProyectoId == id);
            if (proyecto == null)
            {
                return new NotFoundResult();
            }
            else
            {
                var r = from t in proyecto.TransaccionesUnarias
                        where t.Tipo == TransaccionType.INGRESO
                        select t;
                return new ActionResult<IEnumerable<TransaccionUnaria>>(r);
            }
        }

         [HttpGet("ingresobinario/{idProyecto}")]
       public ActionResult<IEnumerable<TransaccionBinaria>> GetIngresosProyectosBinario(long id)
        {
            uow = new UnitOfWork();
            var proyecto = uow.ProyectoRepository.Get(filter: p => p.Id == id, includeProperties: "TransaccionBinarias").FirstOrDefault(); // uow.TransaccionUnariaRepository.Get(t => t.ProyectoId == id);
            if (proyecto == null)
            {
                return new NotFoundResult();
            }
            else
            {
                var r = from t in proyecto.TransaccionesBinarias
                        where t.Tipo == TransaccionType.INGRESO
                        select t;
                return new ActionResult<IEnumerable<TransaccionBinaria>>(r);
            }
        }
         [HttpGet("Egresosbinario/{idProyecto}")]
       public ActionResult<IEnumerable<TransaccionBinaria>> GetEgresosProyectosBinario(long id)
        {
            uow = new UnitOfWork();
            var proyecto = uow.ProyectoRepository.Get(filter: p => p.Id == id, includeProperties: "TransaccionBinarias").FirstOrDefault(); // uow.TransaccionUnariaRepository.Get(t => t.ProyectoId == id);
            if (proyecto == null)
            {
                return new NotFoundResult();
            }
            else
            {
                var r = from t in proyecto.TransaccionesBinarias
                        where t.Tipo == TransaccionType.EGRESO
                        select t;
                return new ActionResult<IEnumerable<TransaccionBinaria>>(r);
            }
        }
    
        [HttpGet("estado/{proyectoState}")]
        public ActionResult<IList<Proyecto>> GetProyectosPorEstado(ProyectoState proyectoState)
        {
            uow = new UnitOfWork();
            IEnumerable<Proyecto> proyectos = uow.ProyectoRepository.Get(p => p.ProyectoState == proyectoState, includeProperties: "Propuesta,Beneficiarios");
            uow.Save();
            uow.Dispose();
            return proyectos.ToList();
        }

  
        [HttpPost]
        public ActionResult<Proyecto> Insert(Proyecto entity)
        {
            uow = new UnitOfWork();
            Propuesta propuesta = uow.PropuestaRepository.GetByID(entity.PropuestaId);
            propuesta.FechaDeAprobacion = System.DateTime.Now;
            propuesta.PropuestaState = PropuestaState.ACEPTADO;
            uow.ProyectoRepository.Insert(entity);
            uow.PropuestaRepository.Update(propuesta);
            uow.Save();
            uow.Dispose();
            return this.Get(entity.Id);
        }

        [HttpPut]
        public ActionResult<Proyecto> Update(Proyecto entity)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
