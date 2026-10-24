namespace PLANAZO_POO_CSharp.Modelos
{
    public class Taller : Evento
    {
        public string Instructor { get; set; }

        public Taller(int id, string nombre, DateTime fecha, decimal precioBase, int capacidadMaxima, string instructor)
            : base(id, nombre, fecha, precioBase, capacidadMaxima)
        {
            Instructor = instructor;
        }

        public override decimal CalcularPrecioFinal()
        {
            return PrecioBase * 0.90m;
        }
    }
}
