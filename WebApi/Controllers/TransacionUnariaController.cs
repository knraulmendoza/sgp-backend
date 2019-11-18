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
        public TransaccionUnariaController(){
            uow = new UnitOfWork();
            if(uow.TransaccionUnariaRepository.Get().ToList().Count == 0){
                uow.TransaccionUnariaRepository.Insert(new TransaccionUnaria{
                    Fecha = new System.DateTime(),
                    Monto = 5000,
                    Tipo =  TransaccionType.EGRESO,
                    Concepto = "Pago servicios",
                    ProyectoId = 1
                });
                uow.TransaccionUnariaRepository.Insert(new TransaccionUnaria{
                    Fecha = new System.DateTime(),
                    Monto = 10000,
                    Tipo =  TransaccionType.EGRESO,
                    Concepto = "Pago Deudas",
                    ProyectoId = 1
                });
            }
            uow.Save();
            uow.Dispose();
        }

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
            uow = new UnitOfWork();
            var detalle = uow.TransaccionUnariaRepository.Insert(entity);
            uow.EgresoRepository.Insert(new Egreso()
            {
                Fecha = entity.Fecha,
                Monto = entity.Monto,
                ProyectoDeDestino = entity.Proyecto,
                Detalle = detalle,
                Concepto = entity.Concepto,
                Tipo = MovimientoType.EGRESO
            });
            var proyecto = from p in uow.ProyectoRepository.Get()
                            where p.Id == entity.ProyectoId
                            select p;
            proyecto.FirstOrDefault().PresupuestoEjecutado += entity.Monto;
            uow.ProyectoRepository.Update(proyecto.FirstOrDefault());
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