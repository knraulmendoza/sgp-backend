using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramaController : GenericController<Programa>
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<Programa> Delete(long id)
        {
            uow = new UnitOfWork();
            Programa res = uow.ProgramaRepository.GetByID(id);
            uow.ProgramaRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<Programa> Get(long id)
        {
            uow = new UnitOfWork();
            Programa res = uow.ProgramaRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Programa>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.ProgramaRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpPost]
        public ActionResult<Programa> Insert(Programa entity)
        {
            uow = new UnitOfWork();
            uow.ProgramaRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public ActionResult<Programa> Update(Programa entity)
        {
            uow = new UnitOfWork();
            uow.ProgramaRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
