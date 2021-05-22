using System.Linq;
using System;
using System.Drawing;
using System.Threading;
using culebrita.Estructuras.Padre;

namespace culebrita.Estructuras.Pilas
{
    public class SnakePilas : ClsPrincipal
    {
        public bool bMoverLaCulebrita(PilaLista culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {
            var lastPoint = (Point)culebra.lista().Last();

            if (lastPoint.Equals(posiciónObjetivo)) return true;

            if (culebra.lista().Any(x => x.Equals(posiciónObjetivo))) return false;

            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            culebra.insertar(posiciónObjetivo);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write("&");

            // Quitar cola
            if (culebra.lista().Count > longitudCulebra)
            {
                var removePoint = (Point)culebra.lista().First();
                culebra.lista().Remove(removePoint);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }
        public Point bMostrarComida(Size screenSize, PilaLista culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.lista().Last();
            Point point = (Point)culebra.lista().First();
            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if ((point.X != x || point.Y != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }
        public void CulebraPilas()
        {
            var punteo = 0;
            var velocidad = 100; //modificar estos valores y ver qué pasa
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20);
            var culebrita = new PilaLista();
            var longitudCulebra = 5; //modificar estos valores y ver qué pasa
            var posiciónActual = new Point(0, 9); //modificar estos valores y ver qué pasa
            culebrita.insertar(posiciónActual);
            var dirección = Direction.Derecha; //modificar estos valores y ver qué pasa
            DibujaPantalla(tamañoPantalla);
            MuestraPunteo(punteo);
            while (bMoverLaCulebrita(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                Thread.Sleep(velocidad);
                dirección = ObtieneDireccion(dirección);
                posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);
                if (posiciónActual.Equals(posiciónComida))
                {
                    posiciónComida = Point.Empty;
                    longitudCulebra++;
                    punteo += 10;
                    MuestraPunteo(punteo);
                    if(velocidad >= 40){
                        velocidad = (int)incrementaV(velocidad);
                    }
                    
                    Console.Beep();
                }

                if (posiciónComida == Point.Empty)
                {
                    posiciónComida = bMostrarComida(tamañoPantalla, culebrita);
                }
            }
            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Write("Fin del Juego");
            Thread.Sleep(2000);
            Console.ReadKey();
        }
    }
}