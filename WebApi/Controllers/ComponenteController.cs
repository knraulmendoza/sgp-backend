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
    public class ComponenteController : GenericController<Componente>
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<Componente> Delete(long id)
        {
            uow = new UnitOfWork();
            Componente res = uow.ComponenteRepository.GetByID(id);
            uow.ComponenteRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<Componente> Get(long id)
        {
            uow = new UnitOfWork();
            Componente res = uow.ComponenteRepository.GetByID(id);
            res.Estrategias = uow.EstrategiaRepository.Get(e => e.ComponenteId == res.Id).ToList();
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Componente>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ComponenteRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpPost]
        public ActionResult<Componente> Insert(Componente entity)
        {
            uow = new UnitOfWork();
            uow.ComponenteRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public ActionResult<Componente> Update(Componente entity)
        {
            uow = new UnitOfWork();
            uow.ComponenteRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
