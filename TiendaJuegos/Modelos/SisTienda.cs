using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TiendaJuegos.Modelos
{
    static public class SisTienda
    {
        static List<Juego> juegos = new();
        static readonly string ArchivoJuego = "juegos.txt";

        static public void  AgregarJuego(Juego juego)
        {
            juegos.Add(juego);
        }

        static public void MostrarJuegos()
        {
            foreach (var juego in juegos)
            {
                Console.WriteLine(juego);
            }
        }
        static public void Modificar(string nombre, Juego nuevoprecio, Juego nuevostock)
        {
            var juego = juegos.Find(m => m.Nombre == nombre);

            if (juego == null)
            {
                Console.WriteLine($"Juego '{nombre}' no encontrado.");
            }
            else
            {
                juegos.Remove(juego);
                juegos.Add(nuevoprecio);
                juegos.Add(nuevostock);
                Console.WriteLine($"El juego  '{nombre}' ha sido mmodifico.");
            }
           
        }
        static public void EliminarMision(string nombre)
        {

            var juego = juegos.Find(m => m.Nombre == nombre);
            if (juego == null)
            {
                Console.WriteLine($"Juego '{nombre}' no encontrado.");
            }
            else
            {
                juegos.Remove(juego);
            }
        }
        static public void GuardarDatos()
        {
            using StreamWriter writer = new StreamWriter(ArchivoJuego);
            foreach (var juego in juegos)
            {
                writer.WriteLine(juego);
            }
            Console.WriteLine("Datos Guardados Correctamente");
        }
        static public void CargarDatos ()
        {
            if (File.Exists(ArchivoJuego))
            {
                foreach (var linea in File.ReadAllLines(ArchivoJuego))
                {
                    string[] d = linea.Split(", ");
                    Juego m = null;
                    string nombre = d[1];
                    Plataforma plataforma = (Plataforma)Enum.Parse(typeof(Plataforma), d[2]);
                    double precio = double.Parse(d[3]);
                    int cantidad = int.Parse(d[4]); 
                    juegos.Add(m);

                }
            }
        }
    }
    }
}
