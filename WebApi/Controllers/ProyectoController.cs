﻿using Controllers.Generics;
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

        public ProyectoController(){
            uow = new UnitOfWork();
            if(uow.ProyectoRepository.Get().ToList().Count == 0){
                uow.ProyectoRepository.Insert(new Proyecto{
                    Nombre = "Proyecto 1",
                    FechaEjecucion = new System.DateTime(),
                    PresupuestoAprobado = 10000,
                    ProyectoState = ProyectoState.CONTRATADO
                });
                uow.ProyectoRepository.Insert(new Proyecto{
                    Nombre = "Proyecto 2",
                    FechaEjecucion = new System.DateTime(),
                    PresupuestoAprobado = 20000,
                    ProyectoState = ProyectoState.CONTRATADO
                });
                uow.ProyectoRepository.Insert(new Proyecto{
                    Nombre = "Proyecto 3",
                    FechaEjecucion = new System.DateTime(),
                    PresupuestoAprobado = 15000,
                    ProyectoState = ProyectoState.ACEPTADO
                });
            }
            uow.Save();
            uow.Dispose();
        }

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

        [HttpGet("egresos/{idProyecto}")]
        public IList<TransaccionUnaria> GetGastosProyectos(long idProyecto)
        {
            uow = new UnitOfWork();
            var egresos = uow.ProyectoRepository
                            .GetByID(idProyecto).TransaccionesUnarias
                            .Where(t => t.Tipo == TransaccionType.EGRESO);
            return egresos.ToList();
        }

        [HttpGet("estado/{proyectoState}")]
        public ICollection<Proyecto> GetProyectosPorEstado(ProyectoState proyectoState)
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
