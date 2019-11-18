using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Contracts;

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
            Proyecto res = uow.ProyectoRepository.GetByID(id);
            res.Propuesta = uow.PropuestaRepository.GetByID(res.PropuestaId);
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Proyecto>> GetAll()
        {
            uow = new UnitOfWork();
            IEnumerable<Proyecto> res = uow.ProyectoRepository.Get();
            foreach (Proyecto proyecto in res)
            {
                proyecto.Propuesta = uow.PropuestaRepository.GetByID(proyecto.PropuestaId);
            }
            uow.Dispose();
            return res.ToList();
        }

        [HttpGet("egresos/{id}")]
        public ActionResult<IList<TransaccionUnaria>> GetGastosProyectos(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<TransaccionUnaria> transaccions = uow.TransaccionUnariaRepository.Get(t => t.ProyectoId == id);
            return transaccions.ToList();
        }

        [HttpGet("{idProyecto}")]
        public ActionResult<IList<TransaccionUnaria>> GetIngresoProyectos(long idProyecto)
        {
            uow = new UnitOfWork();
            var ingreso = uow.ProyectoRepository
                            .GetByID(idProyecto).TransaccionesUnarias
                            .Where(t => t.Tipo == TransaccionType.INGRESO);  
                            uow.Dispose();                          

            return ingreso.ToList();
        }
    
        [HttpGet("estado/{proyectoState}")]
        public ActionResult<IList<Proyecto>> GetProyectosPorEstado(ProyectoState proyectoState)
        {
            uow = new UnitOfWork();
            IEnumerable<Proyecto> proyectos = uow.ProyectoRepository.Get(p => p.ProyectoState == proyectoState);
            foreach (Proyecto proyecto in proyectos)
            {
                proyecto.Propuesta = uow.PropuestaRepository.GetByID(proyecto.PropuestaId);
            }
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
            uow.PropuestaRepository.Update(propuesta);
            uow.ProyectoRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
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
