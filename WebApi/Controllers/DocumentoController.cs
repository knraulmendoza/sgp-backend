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
    public class DocumentoController : GenericController<Documento>
    {
        private UnitOfWork uow;

        

        [HttpGet]
        public override Documento Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Documento> res = uow.DocumentoRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        [HttpGet]
        public override ActionResult<IEnumerable<Documento>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.DocumentoRepository.Get();
            return res.ToList();
        }

        [HttpPost]
        public override int Insert(Documento entity)
        {
            uow = new UnitOfWork();
            uow.DocumentoRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        [HttpDelete]
        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.DocumentoRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        [HttpPut]
        public override int Update(Documento entity)
        {
            uow = new UnitOfWork();
            uow.DocumentoRepository.Update(entity);
            return 1;
        }
    }
}