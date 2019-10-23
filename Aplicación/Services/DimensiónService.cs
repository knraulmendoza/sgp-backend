using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación.Services
{
    public class DimensiónService : GenericService<Dimension>
    {
        private UnitOfWork uow;
        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.DimensionRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override IList<Dimension> Get()
        {
            uow = new UnitOfWork();
            var res = uow.DimensionRepository.Get();
            return res.ToList();
        }

        public override Dimension Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Dimension> res = uow.DimensionRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
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
