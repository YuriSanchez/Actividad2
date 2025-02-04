using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Sistema de Gestión de Citas Médicas ===");

        // Verifica la conexión a la base de datos antes de iniciar el programa
        using (var conexion = ConexionBD.ObtenerConexion())
        {
            if (conexion == null)
            {
                Console.WriteLine("No se pudo conectar a la base de datos. Cerrando el programa.");
                return; // Termina la ejecución si no hay conexión
            }
        }

        bool ejecutando = true;

        while (ejecutando)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Ver citas");
            Console.WriteLine("2. Agregar cita");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    List<Cita> citas = CitaDAO.ObtenerCitas();
                    if (citas.Count == 0)
                    {
                        Console.WriteLine("No hay citas registradas.");
                    }
                    else
                    {
                        Console.WriteLine("\nListado de Citas:");
                        foreach (var cita in citas)
                        {
                            Console.WriteLine($"{cita.Id}. {cita.Paciente} - {cita.Medico} - {cita.Fecha}");
                        }
                    }
                    break;

                case "2":
                    Console.Write("Nombre del paciente: ");
                    string paciente = Console.ReadLine();

                    Console.Write("Nombre del médico: ");
                    string medico = Console.ReadLine();

                    Console.Write("Fecha de la cita (YYYY-MM-DD HH:MM:SS): ");
                    string fechaInput = Console.ReadLine();
                    DateTime fecha;

                    if (!DateTime.TryParse(fechaInput, out fecha))
                    {
                        Console.WriteLine("⚠️ Formato de fecha inválido. Intente de nuevo.");
                        break;
                    }

                    CitaDAO.AgregarCita(paciente, medico, fecha);
                    Console.WriteLine("✅ Cita agregada con éxito.");
                    break;

                case "3":
                    Console.WriteLine("👋 Saliendo del sistema. ¡Hasta pronto!");
                    ejecutando = false;
                    break;

                default:
                    Console.WriteLine("❌ Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
