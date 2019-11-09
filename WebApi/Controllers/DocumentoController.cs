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
    public class DocumentoController : GenericWithFileController<Documento>, GenericController<Documento>
    {
        private UnitOfWork uow;

        [HttpGet("{id}")]
        public ActionResult<Documento> Get(long id)
        {
            uow = new UnitOfWork();
            Documento res = uow.DocumentoRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        [HttpGet("download/{url}")]
        public override ActionResult DownloadFile(string fileName) {
            return base.DownloadFile(fileName);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Documento>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.DocumentoRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpPost]
        public ActionResult<Documento> Insert(Documento entity)
        {
            uow = new UnitOfWork();
            uow.DocumentoRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpDelete]
        public ActionResult<Documento> Delete(long id)
        {
            uow = new UnitOfWork();
            Documento res = uow.DocumentoRepository.GetByID(id);
            uow.DocumentoRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpPut]
        public ActionResult<Documento> Update(Documento entity)
        {
            uow = new UnitOfWork();
            uow.DocumentoRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}