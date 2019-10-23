using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación.Services
{
    public class PropuestaService : GenericService<Propuesta>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override IList<Propuesta> Get()
        {
            uow = new UnitOfWork();
            var res = uow.PropuestaRepository.Get();
            return res.ToList();
        }

        public override Propuesta Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Propuesta> res = uow.PropuestaRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override int Insert(Propuesta entity)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Propuesta entity)
        {
            uow = new UnitOfWork();
            uow.PropuestaRepository.Update(entity);
            return 1;
        }
    }
}
