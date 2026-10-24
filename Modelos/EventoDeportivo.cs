namespace PLANAZO_POO_CSharp.Modelos
{
    public class EventoDeportivo : Evento
    {
        public string Deporte { get; set; }

        public EventoDeportivo(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima, string deporte)
            : base(id, nombre, fecha, precioBase, capacidadMaxima)
        {
            Deporte = deporte;
        }

        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase * 1.20m;
        }
    }
}
