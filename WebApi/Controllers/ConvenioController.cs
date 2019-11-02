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

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.ConvenioRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Convenio Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Convenio> res = uow.ConvenioRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Convenio>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ConvenioRepository.Get();
            return res.ToList();
        }

        public override int Insert(Convenio entity)
        {
            uow = new UnitOfWork();
            uow.ConvenioRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Convenio entity)
        {
            uow = new UnitOfWork();
            uow.ConvenioRepository.Update(entity);
            return 1;
        }
    }
}
