using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entities
{
    public class Proyecto : BaseEntity
    {
        public Propuesta Propuesta {get; set;}
        public int ProyectoState {get; set;}
        public string Nombre {get; set;}
        public float PresupuestoAprovado {get; set;}
        public float PresupuestoEjecutado {get; set;}
        public List<Comunidad> Comunidad {get; set;}
        public DateTime FechaEjecucion {get; set;}
        public List<CertificadoDeDisponibilidadPresupuestal> CertificadosDeDisponibilidaPresupuestales {get; set;}
        public List<Transaccion> Transacciones {get; set;}
        public DateTime FechaCierre {get; set;}
        public DateTime FechaDeCierrePrevista {get; set;}
        public Programa Programa { get; set; }
        public List<Actividad> Actividades {get; set;}
        public IList<Beneficiario> Beneficiarios {get; set;}

        public Proyecto() { }

    }
}
