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
    public class EstrategiaController : GenericController<Estrategia>
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<Estrategia> Delete(long id)
        {
            uow = new UnitOfWork();
            Estrategia res = uow.EstrategiaRepository.GetByID(id);
            uow.EstrategiaRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<Estrategia> Get(long id)
        {
            uow = new UnitOfWork();
            Estrategia res = uow.EstrategiaRepository.GetByID(id);
            res.Programas = uow.ProgramaRepository.Get(p => p.EstrategiaId == res.Id).ToList();
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Estrategia>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.EstrategiaRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpPost]
        public ActionResult<Estrategia> Insert(Estrategia entity)
        {
            uow = new UnitOfWork();
            uow.EstrategiaRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
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
