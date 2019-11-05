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
    public class ComunidadController : GenericController<Comunidad>
    {
        private UnitOfWork uow;
        public override Comunidad Delete(long id)
        {
            uow = new UnitOfWork();
            Comunidad res = uow.ComunidadRepository.GetByID(id);
            uow.ComunidadRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        public override Comunidad Get(long id)
        {
            uow = new UnitOfWork();
            Comunidad res = uow.ComunidadRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        public override ActionResult<IEnumerable<Comunidad>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ComunidadRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public override Comunidad Insert(Comunidad entity)
        {
            uow = new UnitOfWork();
            uow.ComunidadRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public override Comunidad Update(Comunidad entity)
        {
            uow = new UnitOfWork();
            uow.ComunidadRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
