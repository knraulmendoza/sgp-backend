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
    public class DimensionController : GenericController<Dimension>
    {
        private UnitOfWork uow;
        public override Dimension Delete(long id)
        {
            uow = new UnitOfWork();
            Dimension res = uow.DimensionRepository.GetByID(id);
            uow.DimensionRepository.Delete(id);
            uow.Dispose();
            return res;
        }

        public override Dimension Get(long id)
        {
            uow = new UnitOfWork();
            Dimension res = uow.DimensionRepository.GetByID(id);
            uow.Dispose();
            return res;
        }

        public override ActionResult<IEnumerable<Dimension>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.DimensionRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        public override Dimension Insert(Dimension entity)
        {
            uow = new UnitOfWork();
            uow.DimensionRepository.Insert(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }

        public override Dimension Update(Dimension entity)
        {
            uow = new UnitOfWork();
            uow.DimensionRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
