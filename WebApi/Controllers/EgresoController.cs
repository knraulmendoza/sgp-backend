using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Contracts;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EgresoController : GenericController<Egreso>, EgresoContract
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<Egreso> Delete(long id)
        {
            uow = new UnitOfWork();
            uow.EgresoRepository.Delete(id);
            uow.Dispose();
            return null;
        }

        [HttpGet("{id}")]
        public ActionResult<Egreso> Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Egreso> res = uow.EgresoRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Egreso>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.EgresoRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpGet("proyecto/{idProyecto}")]
        public IList<Egreso> GetGastosProyectos(long idProyecto)
        {
            uow = new UnitOfWork();
            IEnumerable<Egreso> egreso = uow.EgresoRepository.Get(e => e.ProyectoId == idProyecto);
            uow.Dispose();
            return egreso.ToList();
        }

        [HttpGet("/estado/{proyectoState}")]
        public IList<Proyecto> GetProyectosConRP(string proyectoState)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public ActionResult<Egreso> Insert(Egreso entity)
        {
            if(ingresarGasto(entity.ProyectoId, entity.Monto)){
                uow = new UnitOfWork();
                uow.EgresoRepository.Insert(new Egreso()
                {
                    Fecha = entity.Fecha,
                    Monto = entity.Monto,
                    ProyectoId = entity.ProyectoId,
                    Concepto = entity.Concepto,
                    Tipo = MovimientoType.EGRESO
                });
                uow.Save();
                uow.Dispose();                
                return entity;
            }else{
                return null;
            }
        }

        private bool ingresarGasto(long id, decimal Monto){
            uow = new UnitOfWork();
            bool bandera = true;
            Proyecto proyecto = new Proyecto();   
            proyecto = uow.ProyectoRepository.GetByID(id);
            if((proyecto.PresupuestoAprobado - proyecto.PresupuestoEjecutado) > Monto){
                proyecto.PresupuestoEjecutado += Monto;
                uow.ProyectoRepository.Update(proyecto);
            }else{
                bandera = false;
            }
            uow.Save();
            uow.Dispose();
            return bandera;
        }

        [HttpPut]
        public ActionResult<Egreso> Update(Egreso entity)
        {
            uow = new UnitOfWork();
            uow.EgresoRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}