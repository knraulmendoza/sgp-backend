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
    [Route("Api/Cdp")]
    public class CDPController : GenericController<CDP>
    {
        public class Values
        {
            public long IdProyecto { get; set; }

            public string IdCDP { get; set; }

            public IDictionary<string, decimal> Fondos { get; set; }

            public Values() { }
        }

        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<CDP> Delete(long id)
        {
            uow = new UnitOfWork();
            CDP res = uow.CDPRepository.GetByID(id);
            uow.CDPRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpPost("Generar")]
        public ActionResult<Object> GenerarCDP([FromBody]Values values)
        {
            uow = new UnitOfWork();
            var proyecto = uow.ProyectoRepository.Get(filter: p => p.Id == values.IdProyecto, includeProperties: "CDPs").FirstOrDefault();
            if (proyecto == null)
            {
                return new {
                    código = "CDP-44",
                    mensaje = "Este proyecto no está registrado"
                };
            }
            if (uow.CDPRepository.Get(cdp => cdp.Codigo == values.IdCDP).FirstOrDefault() != null) {
                return new {
                        código = "CDP-43",
                        mensaje = "Un CDP con este código ya está registrado"
                    };
            }
            foreach (var fondo in FondoGlobal.GetInstance().Fondos)
            {
                try
                {
                    if (fondo.Presupuesto < values.Fondos[fondo.Nombre])
                    {
                        return new
                        {
                            código = "CDP-45",
                            mensaje = "El fondo no tiene suficiente presupuesto"
                        };
                    }
                }
                catch (KeyNotFoundException e)
                {
                }
            }
            var certificado = new CDP()
            {
                Codigo = values.IdCDP,
                FechaDeExpedicion = DateTime.Now,
                FechaDeVencimiento = proyecto.FechaCierre,
                RegistroPresupuestal = default
            };
            uow.CDPRepository.Insert(certificado);
            proyecto.CDPs.Add(certificado);
            proyecto.ProyectoState = ProyectoState.ACEPTADO;
            uow.ProyectoRepository.Update(proyecto);
            int totalCdps = proyecto.CDPs.Count;
            values.Fondos.ToList().ForEach(fondo =>
            {
                uow.TransaccionUnariaRepository.Insert(new TransaccionUnaria()
                {
                    Concepto = "Se generó el " + (totalCdps + 1) + " CDP",
                    Fecha = DateTime.Now.Date,
                    Monto = fondo.Value,
                    Proyecto = proyecto,
                    ProyectoId = proyecto.Id
                });
            });
            uow.Save();
            uow.Dispose();
            return certificado;
        }

        [HttpGet("{id}")]
        public ActionResult<CDP> Get(long id)
        {
            uow = new UnitOfWork();
            CDP res = uow.CDPRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CDP>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.CDPRepository.Get();
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
        public ActionResult<CDP> Insert(CDP entity)
        {
            uow = new UnitOfWork();
            uow.CDPRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public ActionResult<CDP> Update(CDP entity)
        {
            uow = new UnitOfWork();
            uow.CDPRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
