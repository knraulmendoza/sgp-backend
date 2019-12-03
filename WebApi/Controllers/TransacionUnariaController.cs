using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static Dominio.Entities.FondoGlobal;
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

        [HttpGet("egresos/{id}")]
        public ActionResult<IList<TransaccionUnaria>> GetGastosProyectos(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<TransaccionUnaria> transaccions = uow.TransaccionUnariaRepository.Get(t => t.ProyectoId == id);
            return transaccions.ToList();
        }

        [HttpPost]
        public ActionResult<TransaccionUnaria> Insert(TransaccionUnaria entity)
        {
            if(ingresarGasto(entity.ProyectoId, entity.Monto)){
                uow = new UnitOfWork();
                uow.TransaccionUnariaRepository.Insert(entity);
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
        
       
        [HttpPost]
        public ActionResult<TransaccionUnaria> IngresoPresupuesto(long IdProyecto,decimal Monto,Fondo fondo){
                    
             uow = new UnitOfWork();
             Proyecto proyecto = new Proyecto();   
             proyecto = uow.ProyectoRepository.GetByID(IdProyecto);
             //foreach (var fondo in FondoGlobal.GetInstance().Fondos){
             
                if(fondo.Presupuesto > Monto || FondoGlobal.GetInstance().PresupuestoTotal>Monto){

                         proyecto.PresupuestoEjecutado += Monto;
                         uow.ProyectoRepository.Update(proyecto);
                         //getFondo(values.Monto);
                         FondoGlobal.instance.Value.GenerarMovimiento(MovimientoType.INGRESO,fondo,Monto);
                         var transaccion=uow.TransaccionUnariaRepository.Insert(new TransaccionUnaria{
                           Fecha = new System.DateTime(),
                           Monto = Monto,
                           ProyectoId = IdProyecto,
                           Tipo =  TransaccionType.INGRESO
                             });
                         uow.Save();
                        uow.Dispose();
                        return transaccion;

                      }
                         

            return null;
        }

      [HttpPost]
        public ActionResult<TransaccionUnaria> EgresoPresupuesto(long IdProyecto,decimal Monto,Fondo fondo){
                    
             uow = new UnitOfWork();
             Proyecto proyecto = new Proyecto();   
             proyecto = uow.ProyectoRepository.GetByID(IdProyecto);
             //foreach (var fondo in FondoGlobal.GetInstance().Fondos){
             
                if(fondo.Presupuesto > Monto || FondoGlobal.GetInstance().PresupuestoTotal>Monto){

                         proyecto.PresupuestoAprobado -= Monto;
                         uow.ProyectoRepository.Update(proyecto);
                         //getFondo(values.Monto);
                         FondoGlobal.instance.Value.GenerarMovimiento(MovimientoType.EGRESO,fondo,Monto);
                         var transaccion=uow.TransaccionUnariaRepository.Insert(new TransaccionUnaria{
                           Fecha = new System.DateTime(),
                           Monto = Monto,
                           ProyectoId = IdProyecto,
                           Tipo =  TransaccionType.EGRESO
                             });
                         uow.Save();
                        uow.Dispose();
                        return transaccion;

                      }
                         

            return null;
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