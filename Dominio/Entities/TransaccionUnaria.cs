
namespace Dominio.Entities
{
    public class TransaccionUnaria : Transaccion, IDetalleDelMovimiento
    {
        public long ProyectoId { get; set; }
        public TransaccionUnaria() { }

        public string Concepto { get; set; }
    }

}