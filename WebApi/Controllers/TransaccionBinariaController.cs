using Controllers.Generics;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionBinariaController : GenericController<TransaccionBinaria>
    {

        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<TransaccionBinaria> Delete(long id)
        {
            uow = new UnitOfWork();
            TransaccionBinaria res = uow.TransaccionBinariaRepository.GetByID(id);
            uow.TransaccionBinariaRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet("{id}")]
        public ActionResult<TransaccionBinaria> Get(long id)
        {
            uow = new UnitOfWork();
            TransaccionBinaria res =  uow.TransaccionBinariaRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransaccionBinaria>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.TransaccionBinariaRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpPost]
        public ActionResult<TransaccionBinaria> Insert(TransaccionBinaria entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionBinariaRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut("{id}")]
        public ActionResult<TransaccionBinaria> Update(TransaccionBinaria entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionBinariaRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}