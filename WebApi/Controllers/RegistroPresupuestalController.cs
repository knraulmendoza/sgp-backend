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

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.RegistroPresupuestalRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override RegistroPresupuestal Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<RegistroPresupuestal> res = uow.RegistroPresupuestalRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<RegistroPresupuestal>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.RegistroPresupuestalRepository.Get();
            return res.ToList();
        }

        public override int Insert(RegistroPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.RegistroPresupuestalRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(RegistroPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.RegistroPresupuestalRepository.Update(entity);
            return 1;
        }
    }
}
