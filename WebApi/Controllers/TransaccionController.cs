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
    public class TransaccionController : GenericController<Transaccion>
    {
        private UnitOfWork uow;

        public override Transaccion Delete(long id)
        {
            uow = new UnitOfWork();
            Transaccion res = uow.TransaccionRepository.GetByID(id);
            uow.TransaccionRepository.Delete(id);
            uow.Dispose();
            return res;
        }

        public override Transaccion Get(long id)
        {
            uow = new UnitOfWork();
            Transaccion res = uow.TransaccionRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        public override ActionResult<IEnumerable<Transaccion>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.TransaccionRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public override Transaccion Insert(Transaccion entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public override Transaccion Update(Transaccion entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
