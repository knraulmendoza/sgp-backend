using Controllers.Generics;
using Dominio.Entities;
using Dominio.Entities.States;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropuestaController : GenericController<Propuesta>, PropuestaContract
    {
        public class Reporte    {
            public int estado {get; set;}
            public int total {get; set;}

            public Reporte(){}
        }
        private UnitOfWork uow;
        
        [HttpGet]
        public ActionResult<IEnumerable<Propuesta>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.PropuestaRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Propuesta> Get(long id)
        {
            uow = new UnitOfWork();
            Propuesta res = uow.PropuestaRepository.GetByID(id);
            uow.Dispose();
            return res;
        }
        
        [HttpPost]
        public ActionResult<Propuesta> Insert(Propuesta entity)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpDelete("{id}")]
        public ActionResult<Propuesta> Delete(long id)
        {
            uow = new UnitOfWork();
            Propuesta res = uow.PropuestaRepository.GetByID(id);
            uow.PropuestaRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpPut]
        public ActionResult<Propuesta> Update(Propuesta entity)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpGet("/file/{id}")]
        public byte[] GetArchivoDelProyecto(long id)
        {
            uow=new UnitOfWork();
            var PDF=uow.PropuestaRepository.GetByID(id).Documento.RawData;
            uow.Save();
            uow.Dispose();
            return PDF;
        }

        [HttpGet("estado/{state}")]
        public ActionResult<IList<Propuesta>> GetPropuestasPorEstado(PropuestaState state)
        {
            uow = new UnitOfWork();
            var propuestas = uow.PropuestaRepository.Get(p => p.PropuestaState == state);
            uow.Dispose();
            return propuestas.ToList();
        }

        public IList<Componente> GetComponentesPorDimension(long idDimension)
        {
            throw new NotImplementedException();
        }

        [HttpGet("informacion")]
        public ActionResult<IList<Reporte>> contarPropuestasPorEstado(){
            List<Reporte> reportes = new List<Reporte>();
            for(int i = 0; i<=2; i++){
                reportes.Add(new Reporte{
                    estado = i,
                    total = contarPropuesta((PropuestaState)i)
                });
            }
            return reportes;
        }

        public int contarPropuesta(PropuestaState propuestaState){
            uow = new UnitOfWork();
            var propuestas = uow.PropuestaRepository.Get(filter: p => p.PropuestaState == propuestaState);
            uow.Save();
            uow.Dispose();
            return propuestas.Count();
        }
    }
}
