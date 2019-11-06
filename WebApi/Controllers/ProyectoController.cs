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
    public class ProyectoController : GenericController<Proyecto>
    {
        private UnitOfWork uow;

        [HttpDelete]
        public override Proyecto Delete(long id)
        {
            uow = new UnitOfWork();
            Proyecto res = uow.ProyectoRepository.GetByID(id);
            uow.ProyectoRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public override Proyecto Get(long id)
        {
            uow = new UnitOfWork();
            Proyecto res = uow.ProyectoRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        public override ActionResult<IEnumerable<Proyecto>> GetAll()
        {
            uow = new UnitOfWork();
            IEnumerable<Proyecto> res = uow.ProyectoRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public override Proyecto Insert(Proyecto entity)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public override Proyecto Update(Proyecto entity)
        {
            uow = new UnitOfWork();
            uow.ProyectoRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
