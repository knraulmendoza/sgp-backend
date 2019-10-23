using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación.Services
{
    public class RegistroPresupuestalService : GenericService<RegistroPresupuestal>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.RegistroPresupuestalRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override IList<RegistroPresupuestal> Get()
        {
            uow = new UnitOfWork();
            var res = uow.RegistroPresupuestalRepository.Get();
            return res.ToList();
        }

        public override RegistroPresupuestal Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<RegistroPresupuestal> res = uow.RegistroPresupuestalRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override int Insert(RegistroPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.RegistroPresupuestalRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(RegistroPresupuestal entity)
        {
            uow = new UnitOfWork();
            uow.RegistroPresupuestalRepository.Update(entity);
            return 1;
        }
    }
}
