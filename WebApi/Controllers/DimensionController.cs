using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DimensionController : GenericController<Dimension>
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<Dimension> Delete(long id)
        {
            uow = new UnitOfWork();
            Dimension res = uow.DimensionRepository.GetByID(id);
            uow.DimensionRepository.Delete(id);
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<Dimension> Get(long id)
        {
            uow = new UnitOfWork();
            Dimension res = uow.DimensionRepository.GetByID(id);
            res.Componentes = uow.ComponenteRepository.Get(c => c.DimensionId == res.Id).ToList();
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Dimension>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.DimensionRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpPost]
        public ActionResult<Dimension> Insert(Dimension entity)
        {
            uow = new UnitOfWork();
            uow.DimensionRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public ActionResult<Dimension> Update(Dimension entity)
        {
            uow = new UnitOfWork();
            uow.DimensionRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
