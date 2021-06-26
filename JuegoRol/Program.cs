using System;
using System.Collections.Generic;

namespace JuegoRol
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumeroDePersonajes;
            string Ingreso;
            Personaje Jugador1, Jugador2;
            List<Personaje> Jugadors = new List<Personaje>();
            CreadorDePersonajes PersonajeCreado = new CreadorDePersonajes();
            Pelea NuevaPelea = new Pelea();

            do
            {
                Console.WriteLine("\nIngrese el numero de jugadores: ");
                Ingreso = Console.ReadLine();
            } while (!int.TryParse(Ingreso, out NumeroDePersonajes) || NumeroDePersonajes < 2);

            for (int i = 0; i < NumeroDePersonajes; i++)
            {
                Jugadors.Add(PersonajeCreado.PersonajeAleatorio());
            }

            foreach (Personaje personaje in Jugadors)
            {
                personaje.MostrarPersonaje();
            }

            do
            {
                Jugador1 = NuevaPelea.SeleccionarJugador(Jugadors);
                do
                {
                    Jugador2 = NuevaPelea.SeleccionarJugador(Jugadors);
                } while (Jugador1 == Jugador2);

                NuevaPelea.Combate(Jugadors, Jugador1, Jugador2);
            } while (Jugadors.Count > 1);
        }
    }
}
