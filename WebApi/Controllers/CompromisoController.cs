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

        public override Compromiso Delete(long id)
        {
            uow = new UnitOfWork();
            Compromiso res = uow.CompromisoRepository.GetByID(id);
            uow.CompromisoRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public override Compromiso Get(long id)
        {
            uow = new UnitOfWork();
            Compromiso res = uow.CompromisoRepository.GetByID(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public override ActionResult<IEnumerable<Compromiso>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.CompromisoRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public override Compromiso Insert(Compromiso entity)
        {
            uow = new UnitOfWork();
            uow.CompromisoRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public override Compromiso Update(Compromiso entity)
        {
            uow = new UnitOfWork();
            uow.CompromisoRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}