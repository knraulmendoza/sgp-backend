namespace Dominio.Entities
{
    public class TransacciónBinaria : Transaccion
    {
        public Proyecto ProyectoDeDestino { get; set; }

        public TransacciónBinaria() { }
    }
}