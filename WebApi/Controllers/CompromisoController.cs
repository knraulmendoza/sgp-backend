using Dominio.Entities;
using Infraestructura.Utils;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Controllers.Generics;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompromisoController : GenericController<Compromiso>
    {
        private UnitOfWork uow;

        public ActionResult<Compromiso> Delete(long id)
        {
            uow = new UnitOfWork();
            Compromiso res = uow.CompromisoRepository.GetByID(id);
            uow.CompromisoRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public ActionResult<Compromiso> Get(long id)
        {
            uow = new UnitOfWork();
            Compromiso res = uow.CompromisoRepository.GetByID(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public ActionResult<IEnumerable<Compromiso>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.CompromisoRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public ActionResult<Compromiso> Insert(Compromiso entity)
        {
            uow = new UnitOfWork();
            uow.CompromisoRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public ActionResult<Compromiso> Update(Compromiso entity)
        {
            uow = new UnitOfWork();
            uow.CompromisoRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}