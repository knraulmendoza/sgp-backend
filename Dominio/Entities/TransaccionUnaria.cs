
namespace Dominio.Entities
{
    public class TransaccionUnaria : Transaccion, IDetalleDelMovimiento
    {
        public TransaccionUnaria() { }

        public string Concepto { get; set; }
    }

}