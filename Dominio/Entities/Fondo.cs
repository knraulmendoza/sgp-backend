using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Fondo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal PresupuestoDisponible { get; set; }

        public ICollection<Movimiento> Movimiento { get; set; }

        public Fondo() {
        }
    }
}