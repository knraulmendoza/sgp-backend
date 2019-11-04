using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngresoOnceavaController : GenericController<IngresoOnceava>
    {
        private UnitOfWork uow;

        [HttpDelete]
        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.IngresoOnceavaRepository.Delete(id);
            uow.Dispose();
            return 1;
        }
        [HttpGet]
        public override ActionResult<IEnumerable<IngresoOnceava>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.IngresoOnceavaRepository.Get();
            return res.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public override IngresoOnceava Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<IngresoOnceava> res = uow.IngresoOnceavaRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }
        [HttpPost]
        public override int Insert(IngresoOnceava entity)
        {
            uow = new UnitOfWork();
            uow.IngresoOnceavaRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        [HttpPut]
        public override int Update(IngresoOnceava entity)
        {
            uow = new UnitOfWork();
            uow.IngresoOnceavaRepository.Update(entity);
            return 1;
        }
    }
}
