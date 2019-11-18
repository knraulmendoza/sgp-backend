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
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Proyecto>> GetAll()
        {
            uow = new UnitOfWork();
            IEnumerable<Proyecto> res = uow.ProyectoRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpGet("Egresos/{idProyecto}")]
        public ActionResult<IList<TransaccionUnaria>> GetGastosProyectos(long idProyecto)
        {
            uow = new UnitOfWork();
            var egresos = uow.ProyectoRepository
                            .GetByID(idProyecto).TransaccionesUnarias
                            .Where(t => t.Tipo == TransaccionType.EGRESO);
                            uow.Dispose();
            return egresos.ToList();
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
        [HttpGet]
        public ActionResult<IList<proyecto>> GetProyectoSinRp()
        {
            uow= new UnitOfWork();
            var res = uow.ProyectoRepository.Get(p => p.ProyectoState == ProyectoState.EN_ESPERA).ToList();
            uow.Dispose();
            return res;
        }


        public ActionResult<ICollection<Proyecto>> GetProyectosPorEstado(ProyectoState proyectoState)
        {
            uow = new UnitOfWork();
            var proyectos = uow.ProyectoRepository.Get(p => p.ProyectoState == proyectoState);
            uow.Save();
            uow.Dispose();
            return proyectos.ToList();
        }

        [HttpPost]
        public ActionResult<Proyecto> Insert(Proyecto entity)
        {
            uow = new UnitOfWork();
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
