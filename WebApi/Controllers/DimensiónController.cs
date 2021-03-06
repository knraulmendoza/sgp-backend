﻿using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DimensiónController : GenericController<Dimension>
    {
        private UnitOfWork uow;
        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.DimensionRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override Dimension Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Dimension> res = uow.DimensionRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override ActionResult<IEnumerable<Dimension>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.DimensionRepository.Get();
            return res.ToList();
        }

        public override int Insert(Dimension entity)
        {
            uow = new UnitOfWork();
            uow.DimensionRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Dimension entity)
        {
            uow = new UnitOfWork();
            uow.DimensionRepository.Update(entity);
            return 1;
        }
    }
}
