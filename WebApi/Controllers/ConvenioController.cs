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
    public class ConvenioController : GenericController<Convenio>
    {
        private UnitOfWork uow;

        public override Convenio Delete(long id)
        {
            uow = new UnitOfWork();
            Convenio res = uow.ConvenioRepository.GetByID(id);
            uow.ConvenioRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public override Convenio Get(long id)
        {
            uow = new UnitOfWork();
            Convenio res = uow.ConvenioRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        public override ActionResult<IEnumerable<Convenio>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ConvenioRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public override Convenio Insert(Convenio entity)
        {
            uow = new UnitOfWork();
            uow.ConvenioRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public override Convenio Update(Convenio entity)
        {
            uow = new UnitOfWork();
            uow.ConvenioRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
