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
    public class BeneficiarioController : GenericController<Beneficiario>
    {
        private UnitOfWork uow;

        [HttpDelete]
        public override Beneficiario Delete(long id)
        {
            uow = new UnitOfWork();
            Beneficiario res = uow.BeneficicarioRepository.GetByID(id);
            uow.ComponenteRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public override ActionResult<IEnumerable<Beneficiario>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.BeneficicarioRepository.Get();
            uow.Dispose();
            return res.ToList();
        }
        
        [HttpGet("{id}")]
        public override Beneficiario Get(long id)
        {
            uow = new UnitOfWork();
            Beneficiario res = uow.BeneficicarioRepository.GetByID(id);
            uow.Dispose();
            return res;
        }
        [HttpPost]
        public override Beneficiario Insert(Beneficiario entity)
        {
            uow = new UnitOfWork();
            uow.BeneficicarioRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
        [HttpPut]
        public override Beneficiario Update(Beneficiario entity)
        {
            uow = new UnitOfWork();
            uow.BeneficicarioRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
