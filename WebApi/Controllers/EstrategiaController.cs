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

        public ActionResult<Estrategia> Delete(long id)
        {
            uow = new UnitOfWork();
            Estrategia res = uow.EstrategiaRepository.GetByID(id);
            uow.EstrategiaRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public ActionResult<Estrategia> Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Estrategia> res = uow.EstrategiaRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public ActionResult<IEnumerable<Estrategia>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.EstrategiaRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public ActionResult<Estrategia> Insert(Estrategia entity)
        {
            uow = new UnitOfWork();
            uow.EstrategiaRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public ActionResult<Estrategia> Update(Estrategia entity)
        {
            uow = new UnitOfWork();
            uow.EstrategiaRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
