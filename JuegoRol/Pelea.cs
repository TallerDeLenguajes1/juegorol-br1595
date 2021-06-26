using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRol
{
    class Pelea
    {

        readonly Random random = new Random();

        public void Combate(List<Personaje> personajes, Personaje Jugador1, Personaje Jugador2)
        {
            int nroDeAtaques = 0;

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"\n{Jugador1.Nombre} vs {Jugador2.Nombre}");

            while (nroDeAtaques < 20 && Jugador1.Salud > 0 && Jugador2.Salud > 0)
            {
                Jugador1.Atacar(Jugador2);
                int Turno = nroDeAtaques;
                Console.WriteLine("\nTurno " + Turno);

                Console.WriteLine($"\nSalud {Jugador2.Nombre}: {Math.Round(Jugador2.Salud,2)}");

                if (Jugador2.Salud > 0)
                {
                    Jugador2.Atacar(Jugador1);
                    Console.WriteLine($"\nSalud {Jugador1.Nombre}: {Math.Round(Jugador1.Salud, 2)}");
                }

                nroDeAtaques++;
            }

            Console.WriteLine("\n/////////////////////////");

            if (Jugador1.Salud > Jugador2.Salud)
            {

                Console.WriteLine("\nGanador: ");
                Jugador1.MostrarPersonaje();
                personajes.Remove(Jugador2);
            }
            else if (Jugador2.Salud > Jugador1.Salud)
            {
                Console.WriteLine("\nGanador: ");
                Jugador2.MostrarPersonaje();
                personajes.Remove(Jugador1);
            }
        }

        public Personaje SeleccionarJugador(List<Personaje> Jugadors)
        {
            return Jugadors[random.Next(0, Jugadors.Count)];
        }
    }
}
