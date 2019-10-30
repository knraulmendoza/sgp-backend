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

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.CompromisoRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Compromiso Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Compromiso> res = uow.CompromisoRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Compromiso>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.CompromisoRepository.Get();
            return res.ToList();
        }

        public override int Insert(Compromiso entity)
        {
            uow = new UnitOfWork();
            uow.CompromisoRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Compromiso entity)
        {
            uow = new UnitOfWork();
            uow.CompromisoRepository.Update(entity);
            return 1;
        }
    }
}
