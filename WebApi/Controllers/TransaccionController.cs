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

        [HttpDelete("{id}")]
        public ActionResult<Transaccion> Delete(long id)
        {
            uow = new UnitOfWork();
            Transaccion res = uow.TransaccionRepository.GetByID(id);
            uow.TransaccionRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<Transaccion> Get(long id)
        {
            uow = new UnitOfWork();
            Transaccion res = uow.TransaccionRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaccion>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.TransaccionRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttPost]
        public ActionResult<Transaccion> Insert(Transaccion entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public ActionResult<Transaccion> Update(Transaccion entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
