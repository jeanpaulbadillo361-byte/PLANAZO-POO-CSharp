namespace PLANAZO_POO_CSharp.Modelos
{
    public enum EstadoReserva
    {
        Activa,
        Cancelada
    }

    public class Reserva
    {
        public int IdReserva { get; set; }
        public Usuario Usuario { get; set; }
        public Evento EventoReservado { get; set; }
        public int CantidadEntradas { get; set; }
        public decimal ValorTotal { get; set; }
        public EstadoReserva Estado { get; set; }

        public Reserva(int idReserva, Usuario usuario, Evento eventoReservado, int cantidadEntradas)
        {
            IdReserva = idReserva;
            Usuario = usuario;
            EventoReservado = eventoReservado;
            CantidadEntradas = cantidadEntradas;
            ValorTotal = eventoReservado.CalcularPrecioFinal() * cantidadEntradas;
            Estado = EstadoReserva.Activa;
        }

        public override string ToString()
        {
            return $"Reserva #{IdReserva} | Usuario: {Usuario.Nombre} | Evento: {EventoReservado.Nombre} | Entradas: {CantidadEntradas} | Total: ${ValorTotal:N0} | Estado: {Estado}";
        }
    }
}
