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
    public class RegistroPresupuestalController : GenericController<RegistroPresupuestal>
    {
        private UnitOfWork uow;

        [HttpDelete]
        public ActionResult<RegistroPresupuestal> Delete(long id)
        {
            uow = new UnitOfWork();
            RegistroPresupuestal res = uow.RegistroPresupuestalRepository.GetByID(id);
            uow.RegistroPresupuestalRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<RegistroPresupuestal> Get(long id)
        {
            uow = new UnitOfWork();
            RegistroPresupuestal res = uow.RegistroPresupuestalRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        public ActionResult<IEnumerable<RegistroPresupuestal>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.RegistroPresupuestalRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public ActionResult<RegistroPresupuestal> Insert(RegistroPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.RegistroPresupuestalRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public ActionResult<RegistroPresupuestal> Update(RegistroPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.RegistroPresupuestalRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
