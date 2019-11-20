using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static Dominio.Entities.FondoGlobal;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificadoDeDisponibilidadPresupuestalController : GenericController<CertificadoDeDisponibilidadPresupuestal>, ICertificadoDeDisponibilidadPresupuestalContract
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<CertificadoDeDisponibilidadPresupuestal> Delete(long id)
        {
            uow = new UnitOfWork();
            CertificadoDeDisponibilidadPresupuestal res = uow.CertificadoDeDisponibilidadPresupuestalRepository.GetByID(id);
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpPost("GenerarCertificado")]
        public ActionResult<CertificadoDeDisponibilidadPresupuestal> GenerarCertificadoDeDisponibilidadPresupuestal(long idProyecto, IDictionary<string, decimal> fondos)
        {
            uow = new UnitOfWork();
            var proyecto = uow.ProyectoRepository.GetByID(idProyecto);
            if (proyecto == null)
            {
                return new NotFoundResult();
            }
            var certificado = new CertificadoDeDisponibilidadPresupuestal() {
                Codigo = Guid.NewGuid().ToString(),
                FechaDeExpedicion = DateTime.Now,
                FechaDeVencimiento = proyecto.FechaCierre,
                RegistroPresupuestal = default
            };
            proyecto.CertificadosDeDisponibilidaPresupuestales.Add(certificado);
            uow.ProyectoRepository.Update(proyecto);
            uow.Save();
            uow.Dispose();
            return certificado;
        }

        [HttpGet("{id}")]
        public ActionResult<CertificadoDeDisponibilidadPresupuestal> Get(long id)
        {
            uow = new UnitOfWork();
            CertificadoDeDisponibilidadPresupuestal res = uow.CertificadoDeDisponibilidadPresupuestalRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CertificadoDeDisponibilidadPresupuestal>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.CertificadoDeDisponibilidadPresupuestalRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public IEnumerable<Fondo> GetListarFondos()
        {
            return FondoGlobal.GetInstance().Fondos;
        }

        public IEnumerable<Proyecto> GetListarProyectos(string estado)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public ActionResult<CertificadoDeDisponibilidadPresupuestal> Insert(CertificadoDeDisponibilidadPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public ActionResult<CertificadoDeDisponibilidadPresupuestal> Update(CertificadoDeDisponibilidadPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
