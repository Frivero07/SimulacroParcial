using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaJuegos.Modelos
{
    public class Juego
    {
        public string Nombre { get; private set; }
        public Plataforma plataforma { get; private set; }
        public double Precio { get; private set; }
        public int  Cantidad { get; private set; }
        public Juego(string nombre, Plataforma plataforma, double precio, int cantidad)
        {
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"{GetType().Name}, {Nombre}, {plataforma}, {Precio}, {Cantidad}";
        }

    }
}
