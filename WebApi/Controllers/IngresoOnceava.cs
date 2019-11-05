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
        public override IngresoOnceava Delete(long id)
        {
            uow = new UnitOfWork();
            IngresoOnceava res = uow.IngresoOnceavaRepository.GetByID(id);
            uow.IngresoOnceavaRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public override ActionResult<IEnumerable<IngresoOnceava>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.IngresoOnceavaRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public override IngresoOnceava Get(long id)
        {
            uow = new UnitOfWork();
            IngresoOnceava res = uow.IngresoOnceavaRepository.GetByID(id);
            uow.Dispose();
            return res;
        }
        [HttpPost]
        public override IngresoOnceava Insert(IngresoOnceava entity)
        {
            uow = new UnitOfWork();
            uow.IngresoOnceavaRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public override IngresoOnceava Update(IngresoOnceava entity)
        {
            uow = new UnitOfWork();
            uow.IngresoOnceavaRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
