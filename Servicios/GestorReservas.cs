using System;
using System.Collections.Generic;
using System.Linq;
using PLANAZO_POO_CSharp.Modelos;

namespace PLANAZO_POO_CSharp.Servicios
{
    public class GestorReservas
    {
        public List<Evento> Eventos { get; set; } = new List<Evento>();
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
        private int _nextReservaId = 1;

        public void CargarDatosIniciales()
        {
            // Catálogo inicial de eventos
            Eventos.Add(new Cine(1, "Avengers: Secret Wars", DateTime.Now.AddDays(5), 25000m, 100, "Sala IMAX 1"));
            Eventos.Add(new Concierto(2, "Festival de Rock al Parque", DateTime.Now.AddDays(12), 80000m, 500, "Metallica"));
            Eventos.Add(new Taller(3, "Taller de Programación en C#", DateTime.Now.AddDays(3), 40000m, 30, "Ing. Juan Pérez"));
            Eventos.Add(new EventoDeportivo(4, "Final de la Liga Local", DateTime.Now.AddDays(8), 50000m, 200, "Fútbol"));

            // Usuarios predeterminados
            Usuarios.Add(new Usuario("12345678", "Jean Paul", "jean@email.com"));
            Usuarios.Add(new Usuario("87654321", "Moises Arrieta", "moises@email.com"));
        }

        public void MostrarCatalogo()
        {
            Console.WriteLine("\n--- CATÁLOGO DE EVENTOS ---");
            foreach (var ev in Eventos)
            {
                Console.WriteLine(ev.ToString());
            }
        }

        public void CrearReserva(string docUsuario, int eventoId, int cantidad)
        {
            var usuario = Usuarios.FirstOrDefault(u => u.Documento == docUsuario);
            if (usuario == null)
            {
                Console.WriteLine("Error: Usuario no encontrado.");
                return;
            }

            var evento = Eventos.FirstOrDefault(e => e.Id == eventoId);
            if (evento == null)
            {
                Console.WriteLine("Error: Evento no encontrado.");
                return;
            }

            if (evento.CuposDisponibles < cantidad)
            {
                Console.WriteLine("Error: No hay suficientes cupos disponibles.");
                return;
            }

            evento.CuposDisponibles -= cantidad;
            var reserva = new Reserva(_nextReservaId++, usuario, evento, cantidad);
            Reservas.Add(reserva);
            Console.WriteLine($"¡Reserva exitosa! ID de reserva: {reserva.IdReserva}");
        }

        public void CancelarReserva(int idReserva)
        {
            var reserva = Reservas.FirstOrDefault(r => r.IdReserva == idReserva);
            if (reserva == null)
            {
                Console.WriteLine("Error: Reserva no encontrada.");
                return;
            }

            if (reserva.Estado == EstadoReserva.Cancelada)
            {
                Console.WriteLine("La reserva ya se encontraba cancelada.");
                return;
            }

            reserva.Estado = EstadoReserva.Cancelada;
            reserva.EventoReservado.CuposDisponibles += reserva.CantidadEntradas;
            Console.WriteLine($"Reserva #{idReserva} cancelada exitosamente.");
        }

        public void MostrarResumenFinanciero()
        {
            Console.WriteLine("\n--- RESUMEN FINANCIERO Y ESTADÍSTICO ---");
            decimal totalVentas = Reservas.Where(r => r.Estado == EstadoReserva.Activa).Sum(r => r.ValorTotal);
            int totalReservasActivas = Reservas.Count(r => r.Estado == EstadoReserva.Activa);

            Console.WriteLine($"Total de reservas activas: {totalReservasActivas}");
            Console.WriteLine($"Ingresos totales generados: ${totalVentas:N0}");
        }
    }
}
