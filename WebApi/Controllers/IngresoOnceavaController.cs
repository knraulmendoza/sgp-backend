using Controllers.Generics;
using Dominio.Entities;
using Infraestructura.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Dominio.Entities.FondoGlobal;

namespace WebApi.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IngresoOnceavaController : GenericController<IngresoOnceava>
    {
        private UnitOfWork uow;

        [HttpDelete("{id}")]
        public ActionResult<IngresoOnceava> Delete(long id)
        {
            uow = new UnitOfWork();
            IngresoOnceava res = uow.IngresoOnceavaRepository.GetByID(id);
            uow.IngresoOnceavaRepository.Delete(id);
            uow.Save();
            uow.Dispose();
            return res;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IngresoOnceava>> GetAll()
        {
            uow = new UnitOfWork();
            var res = uow.IngresoOnceavaRepository.Get();
            uow.Dispose();
            return res.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<IngresoOnceava> Get(long id)
        {
            uow = new UnitOfWork();
            IngresoOnceava res = uow.IngresoOnceavaRepository.GetByID(id);
            res.SoporteInteres = uow.DocumentoRepository.GetByID(res.SoporteInteresId);
            res.SoporteValor = uow.DocumentoRepository.GetByID(res.SoporteValorId);
            uow.Dispose();
            return res;
        }
        [HttpPost]
        public ActionResult<IngresoOnceava> Insert(IngresoOnceava entity)
        {
            uow = new UnitOfWork();
            uow.IngresoOnceavaRepository.Insert(entity);
            Fondo sgp = FondoGlobal.instance.Value.GetFondo("Sistema general de participación");
            Fondo intereses = FondoGlobal.instance.Value.GetFondo("Intereses");
            FondoGlobal.GetInstance().GenerarMovimiento(MovimientoType.INGRESO, sgp, entity.Valor);
            FondoGlobal.GetInstance().GenerarMovimiento(MovimientoType.INGRESO, intereses, entity.Interes);

            Movimiento movimiento = new Movimiento {
                NombreDelFondo = "Sistema general de participación",
                Tipo = MovimientoType.INGRESO,
                Monto = entity.Valor,
                Concepto = "Ingreso de Onceava",
                Fecha = System.DateTime.Now
            };
            uow.MovimientoRepository.Insert(movimiento);

            Movimiento movimientoInteres = new Movimiento {
                NombreDelFondo = "Intereses",
                Tipo = MovimientoType.INGRESO,
                Monto = entity.Interes,
                Concepto = "Interes de Onceava",
                Fecha = System.DateTime.Now
            };
            uow.MovimientoRepository.Insert(movimientoInteres);
            
            uow.Save();
            uow.Dispose();
            return entity;
        }

        [HttpPut]
        public ActionResult<IngresoOnceava> Update(IngresoOnceava entity)
        {
            uow = new UnitOfWork();
            uow.IngresoOnceavaRepository.Update(entity);
            uow.Save();
            uow.Dispose();
            return entity;
        }
    }
}
