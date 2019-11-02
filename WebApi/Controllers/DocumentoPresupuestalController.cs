using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentoPresupuestalController : GenericController<DocumentoPresupuestal>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.DocumentoPresupuestalRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override DocumentoPresupuestal Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<DocumentoPresupuestal> res = uow.DocumentoPresupuestalRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<DocumentoPresupuestal>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.DocumentoPresupuestalRepository.Get();
            return res.ToList();
        }

        public override int Insert(DocumentoPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.DocumentoPresupuestalRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(DocumentoPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.DocumentoPresupuestalRepository.Update(entity);
            return 1;
        }
    }
}
