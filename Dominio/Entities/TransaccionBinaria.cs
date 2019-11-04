namespace Dominio.Entities
{
    public class TransaccionBinaria : Transaccion
    {
        public Proyecto ProyectoDeDestino { get; set; }

        public TransaccionBinaria() { }
    }
}