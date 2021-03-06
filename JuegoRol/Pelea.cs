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

            Console.WriteLine("Lugar: " + GetProvinciaAleatoria());
            Jugador1.PrePelea(Jugador2);
            while (nroDeAtaques < 20 && Jugador1.Salud > 0 && Jugador2.Salud > 0)
            {
                Jugador1.Atacar(Jugador2);
                int Turno = nroDeAtaques;
                Console.WriteLine("\nTurno " + (Turno + 1));

                Console.WriteLine($"\nSalud {Jugador2.Nombre}: {Math.Round(Jugador2.Salud, 2)}");

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
                Resultados(personajes, Jugador2, Jugador1);
            }
            else if (Jugador2.Salud > Jugador1.Salud)
            {
                Resultados(personajes, Jugador1, Jugador2);
            }
        }

        public void Resultados(List<Personaje> personajes, Personaje Ganador, Personaje Perdedor)
        {
            Console.WriteLine("\nGanador: ");
            Ganador.SubirDeNivel();
            Ganador.MostrarPersonaje();
            personajes.Remove(Perdedor);
            Ganador.Curarse();
        }

        public Personaje SeleccionarJugador(List<Personaje> Jugadors)
        {
            return Jugadors[random.Next(0, Jugadors.Count)];
        }

        public string GetProvinciaAleatoria()
        {
            string Auxiliar;
            ProvinciasArgentinas Posibilidades = new ProvinciasArgentinas();
            Posibilidades = ProvinciasApi.GetProvincias();
            if(Posibilidades != null)
            {
                Auxiliar = Posibilidades.Provincias[random.Next(0, Posibilidades.Provincias.Count)].Nombre;
            }
            else
            {
                Auxiliar = "Perdidos en el espacio";
            }

            return Auxiliar;
        }
    }
}
