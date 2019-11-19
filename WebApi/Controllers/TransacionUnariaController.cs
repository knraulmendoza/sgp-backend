using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebApi.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionUnariaController : GenericController<TransaccionUnaria>
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<TransaccionUnaria> Delete(long id)
        {
            uow = new UnitOfWork();
            TransaccionUnaria res = uow.TransaccionUnariaRepository.GetByID(id);
            uow.TransaccionUnariaRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<TransaccionUnaria> Get(long id)
        {
            uow = new UnitOfWork();
            TransaccionUnaria res = uow.TransaccionUnariaRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransaccionUnaria>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.TransaccionUnariaRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpGet("gastos/{idProyecto}")]
        public IList<TransaccionUnaria> GetGastosProyectos(long idProyecto)
        {
            uow = new UnitOfWork();
            var egresos = uow.TransaccionUnariaRepository.Get(t => t.ProyectoId == idProyecto);
            return egresos.ToList();
        }

        [HttpPost]
        public ActionResult<TransaccionUnaria> Insert(TransaccionUnaria entity)
        {
            /* uow = new UnitOfWork();
            var detalle = uow.TransaccionUnariaRepository.Insert(entity);
            uow.EgresoRepository.Insert(new Egreso()
            {
                Fecha = entity.Fecha,
                Monto = entity.Monto,
                ProyectoDeDestinoId = entity.ProyectoId,
                // Detalle no existe en la entidad Egreso
                // Detalle = detalle,
                Concepto = entity.Concepto,
                Tipo = MovimientoType.EGRESO
            });
            Proyecto proyecto = uow.ProyectoRepository.GetByID(entity.ProyectoId);
            proyecto.PresupuestoEjecutado += entity.Monto;
            uow.ProyectoRepository.Update(proyecto);
            uow.Save();
            uow.Dispose();
            return entity;*/
            uow = new UnitOfWork();
            uow.EgresoRepository.Insert(new Egreso()
            {
                Fecha = entity.Fecha,
                Monto = entity.Monto,
                ProyectoDeDestinoId = entity.ProyectoId,
                // Detalle no existe en la entidad Egreso
                // Detalle = detalle,
                Concepto = entity.Concepto,
                Tipo = MovimientoType.EGRESO
            });
            //var detalle = uow.TransaccionUnariaRepository.Insert(entity);
            Proyecto proyecto = uow.ProyectoRepository.GetByID(entity.ProyectoId);
            proyecto.PresupuestoEjecutado += entity.Monto;
            uow.ProyectoRepository.Update(proyecto);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut("{id}")]
        public ActionResult<TransaccionUnaria> Update(TransaccionUnaria entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionUnariaRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }

}