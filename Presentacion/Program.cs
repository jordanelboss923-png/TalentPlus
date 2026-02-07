using System;
using System.Data.SqlClient;
using Negocio;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpleadoService servicio = new EmpleadoService();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CONTROL DE EMPLEADOS - TALENTPLUS ===");
                Console.WriteLine("1. Registrar empleado");
                Console.WriteLine("2. Buscar empleado por cédula");
                Console.WriteLine("3. Actualizar empleado");
                Console.WriteLine("4. Eliminar empleado");
                Console.WriteLine("5. Listar empleados");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Cédula: ");
                        string cedula = Console.ReadLine();
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Apellido: ");
                        string apellido = Console.ReadLine();
                        Console.Write("Cargo: ");
                        string cargo = Console.ReadLine();
                        Console.Write("Salario: ");
                        decimal salario = decimal.Parse(Console.ReadLine());

                        servicio.Registrar(cedula, nombre, apellido, cargo, salario);
                        Console.WriteLine("Empleado registrado ✔");
                        break;

                    case 2:
                        Console.Write("Cédula a buscar: ");
                        SqlDataReader dr = servicio.Buscar(Console.ReadLine());
                        if (dr.Read())
                        {
                            Console.WriteLine($"{dr["Nombre"]} {dr["Apellido"]} - {dr["Cargo"]} - {dr["Salario"]}");
                        }
                        else
                        {
                            Console.WriteLine("Empleado no encontrado");
                        }
                        dr.Close();
                        break;

                    case 3:
                        Console.Write("Cédula: ");
                        cedula = Console.ReadLine();
                        Console.Write("Nuevo Nombre: ");
                        nombre = Console.ReadLine();
                        Console.Write("Nuevo Apellido: ");
                        apellido = Console.ReadLine();
                        Console.Write("Nuevo Cargo: ");
                        cargo = Console.ReadLine();
                        Console.Write("Nuevo Salario: ");
                        salario = decimal.Parse(Console.ReadLine());

                        servicio.Actualizar(cedula, nombre, apellido, cargo, salario);
                        Console.WriteLine("Empleado actualizado ✔");
                        break;

                    case 4:
                        Console.Write("Cédula a eliminar: ");
                        servicio.Eliminar(Console.ReadLine());
                        Console.WriteLine("Empleado eliminado ❌");
                        break;

                    case 5:
                        SqlDataReader lista = servicio.Listar();
                        while (lista.Read())
                        {
                            Console.WriteLine($"{lista["Cedula"]} - {lista["Nombre"]} {lista["Apellido"]}");
                        }
                        lista.Close();
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 0);
        }
    }
}
