using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TiendaJuegos.Modelos
{
    static public class Menu
    {
        private static List<Action> Acciones = new List<Action>
        {
            AgregarJuego,
            MostrarJuegos,
            ModificarJuegos,
            EliminarJuegos
        };
        public static void MostrarMenu()
        {
            SisTienda.CargarDatos();

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n --- Menú de misiones ---\n" +
                    "1. Agregar juego\n" +
                    "2. Mostrar juegos\n" +
                    "3. Modificar juegos\n" +
                    "4. Eliminar juego\n" +
                    "5. Salir\n");
                Console.WriteLine("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count + 1)
                {
                    if (indice == Acciones.Count + 1)
                    {
                        salir = true;
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
            }

        }

        static public void AgregarJuego()
        {
            Console.WriteLine("ingrese el nombre del juego");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la plataforma");
            foreach (var plataforma in Enum.GetValues(typeof(Plataforma)))
            {
                Console.WriteLine($"{(int)plataforma}. {plataforma}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            Plataforma Seleccion = (Plataforma)seleccion;
            Console.WriteLine("ingrese el precio");
            double precio = double.Parse(Console.ReadLine());
            Console.WriteLine("ingrese la cantidad de stock");
            int cantidad = int.Parse(Console.ReadLine());

            Juego juego = new Juego(nombre,Seleccion, precio, cantidad);
            SisTienda.AgregarJuego(juego);
        }
        static public void EliminarJuego()
        {
            Console.Write("Ingrese el nombre de la misión: ");
            string nombre = Console.ReadLine();
            SisTienda.EliminarMision(nombre);
        }

    }
}



  
