﻿using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificadoDeDisponibilidadPresupuestalController : GenericController<CertificadoDeDisponibilidadPresupuestal>, CertificadoDeDisponibilidadPresupuestalContract
    {
        private UnitOfWork uow;

        public override CertificadoDeDisponibilidadPresupuestal Delete(long id)
        {
            uow = new UnitOfWork();
            CertificadoDeDisponibilidadPresupuestal res = uow.CertificadoDeDisponibilidadPresupuestalRepository.GetByID(id);
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public CertificadoDeDisponibilidadPresupuestal GenerarCertificadoDeDisponibilidadPresupuestal(long idProyecto, IDictionary<string, float> fondosYPresupuestos)
        {
            var certificado = new CertificadoDeDisponibilidadPresupuestal();

            uow = new UnitOfWork();
            var proyecto = uow.ProyectoRepository.GetByID(idProyecto);
            certificado = new CertificadoDeDisponibilidadPresupuestal() {
                Codigo = "",
                FechaDeExpedicion = DateTime.Now,
                FechaDeVencimiento = DateTime.Now,
                RegistroPresupuestal = new RegistroPresupuestal() {
                    
                }
            };
            return certificado;
        }

        public override CertificadoDeDisponibilidadPresupuestal Get(long id)
        {
            uow = new UnitOfWork();
            CertificadoDeDisponibilidadPresupuestal res = uow.CertificadoDeDisponibilidadPresupuestalRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        public override ActionResult<IEnumerable<CertificadoDeDisponibilidadPresupuestal>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.CertificadoDeDisponibilidadPresupuestalRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public IDictionary<string, float> GetListarFondos()
        {
            return FondoGlobal.GetInstance().Fondos;
        }

        public IEnumerable<Proyecto> GetListarProyectos(string estado)
        {
            throw new System.NotImplementedException();
        }

        public override CertificadoDeDisponibilidadPresupuestal Insert(CertificadoDeDisponibilidadPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public override CertificadoDeDisponibilidadPresupuestal Update(CertificadoDeDisponibilidadPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.CertificadoDeDisponibilidadPresupuestalRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}