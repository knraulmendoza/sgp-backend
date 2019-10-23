using Dominio.Entities;
using Infraestructura.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicación.Services
{
    public class TransaccionService : GenericService<Transaccion>
    {
        private UnitOfWork uow;

        public override int Delete(long id)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Delete(id);
            uow.Dispose();
            return 1;
        }

        public override IList<Transaccion> Get()
        {
            uow = new UnitOfWork();
            var res = uow.TransaccionRepository.Get();
            return res.ToList();
        }

        public override Transaccion Get(long id)
        {
            uow = new UnitOfWork();
            IEnumerable<Transaccion> res = uow.TransaccionRepository.Get(a => a.Id == id);
            uow.Dispose();
            return res.ToList().FirstOrDefault();
        }

        public override int Insert(Transaccion entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Insert(entity);
            uow.Dispose();
            return 1;
        }

        public override int Update(Transaccion entity)
        {
            uow = new UnitOfWork();
            uow.TransaccionRepository.Update(entity);
            return 1;
        }
    }
}
