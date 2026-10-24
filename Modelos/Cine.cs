namespace PLANAZO_POO_CSharp.Modelos
{
    public class Cine : Evento
    {
        public string Sala { get; set; }

        public Cine(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima, string sala)
            : base(id, nombre, fecha, precioBase, capacidadMaxima)
        {
            Sala = sala;
        }

        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase;
        }
    }
}
