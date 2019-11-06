using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoPresupuestalController : GenericController<DocumentoPresupuestal>
    {
        private UnitOfWork uow;

        public override DocumentoPresupuestal Delete(long id)
        {
            uow = new UnitOfWork();
            DocumentoPresupuestal res = uow.DocumentoPresupuestalRepository.GetByID(id);
            uow.DocumentoPresupuestalRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public override DocumentoPresupuestal Get(long id)
        {
            uow = new UnitOfWork();
            DocumentoPresupuestal res = uow.DocumentoPresupuestalRepository.GetByID(id);
            uow.Dispose();
            return res;
        }
        [HttpGet]
        public override ActionResult<IEnumerable<DocumentoPresupuestal>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.DocumentoPresupuestalRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpPost]
        public override DocumentoPresupuestal Insert(DocumentoPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.DocumentoPresupuestalRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public override DocumentoPresupuestal Update(DocumentoPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.DocumentoPresupuestalRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
