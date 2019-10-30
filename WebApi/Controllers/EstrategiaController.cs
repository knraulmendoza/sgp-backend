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
    public class EstrategiaController : GenericController<Estrategia>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.EstrategiaRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Estrategia Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Estrategia> res = uow.EstrategiaRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Estrategia>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.EstrategiaRepository.Get();
            return res.ToList();
        }

        public override int Insert(Estrategia entity)
        {
            uow = new UnitOfWork();
            uow.EstrategiaRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Estrategia entity)
        {
            uow = new UnitOfWork();
            uow.EstrategiaRepository.Update(entity);
            return 1;
        }
    }
}
