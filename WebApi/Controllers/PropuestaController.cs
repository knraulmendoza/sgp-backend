using Controllers.Generics;
using Dominio.Entities;
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

        [HttpDelete]
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

        [HttpGet("{id}")]
        public byte[] GetArchivoDelProyecto(long id)
        {
            uow=new UnitOfWork();
            var PDF=uow.PropuestaRepository.GetByID(id).Documento.RawData;
            uow.Save();
            uow.Dispose();
            return PDF;
        }

        public IList<Componente> GetComponentesPorDimension(long idDimension)
        {
            throw new NotImplementedException();
        }
    }
}
