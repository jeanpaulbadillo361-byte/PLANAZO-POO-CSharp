using System;
using PLANAZO_POO_CSharp.Servicios;

namespace PLANAZO_POO_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorReservas gestor = new GestorReservas();
            gestor.CargarDatosIniciales();

            int opcion = 0;
            do
            {
                Console.WriteLine("\n=== SISTEMA DE GESTIÓN PLANAZO ===");
                Console.WriteLine("1. Mostrar Catálogo de Eventos");
                Console.WriteLine("2. Crear Reserva");
                Console.WriteLine("3. Cancelar Reserva");
                Console.WriteLine("4. Ver Resumen Financiero");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            gestor.MostrarCatalogo();
                            break;
                        case 2:
                            Console.Write("Ingrese documento del usuario: ");
                            string doc = Console.ReadLine();
                            Console.Write("Ingrese ID del evento: ");
                            if (int.TryParse(Console.ReadLine(), out int idEvento))
                            {
                                Console.Write("Ingrese cantidad de entradas: ");
                                if (int.TryParse(Console.ReadLine(), out int cant))
                                {
                                    gestor.CrearReserva(doc, idEvento, cant);
                                }
                            }
                            break;
                        case 3:
                            Console.Write("Ingrese ID de la reserva a cancelar: ");
                            if (int.TryParse(Console.ReadLine(), out int idReserva))
                            {
                                gestor.CancelarReserva(idReserva);
                            }
                            break;
                        case 4:
                            gestor.MostrarResumenFinanciero();
                            break;
                        case 5:
                            Console.WriteLine("¡Saliendo del sistema!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }

            } while (opcion != 5);
        }
    }
}
