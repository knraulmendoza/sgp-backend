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

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Transaccion Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Transaccion> res = uow.TransaccionRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Transaccion>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.TransaccionRepository.Get();
            return res.ToList();
        }

        public override int Insert(Transaccion entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Transaccion entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Update(entity);
            return 1;
        }
    }
}
