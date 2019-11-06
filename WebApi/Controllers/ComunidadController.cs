using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunidadController : GenericController<Comunidad>
    {
        private UnitOfWork uow;

        [HttpDelete]
        public override Comunidad Delete(long id)
        {
            uow = new UnitOfWork();
            Comunidad res = uow.ComunidadRepository.GetByID(id);
            uow.ComunidadRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public override Comunidad Get(long id)
        {
            uow = new UnitOfWork();
            Comunidad res = uow.ComunidadRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public override ActionResult<IEnumerable<Comunidad>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ComunidadRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpPost]
        public override Comunidad Insert(Comunidad entity)
        {
            uow = new UnitOfWork();
            uow.ComunidadRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
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
