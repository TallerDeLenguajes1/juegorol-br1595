using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRol
{
    public enum NombrePersonajes
    {
        Jorge,
        Pedro,
        Robledo,
        Lisa,
        Chori,
        Bic
    }

    public enum ApodosPersonajes
    {
        Petizo,
        Micho,
        Cuervo,
        Tito,
        Invencible,
        Cabezon,
        Gordo
    }
    class CreadorDePersonajes
    {

        public List<Personaje> personajes = new List<Personaje>();

        readonly Random random = new Random();

        public Personaje PersonajeAleatorio()
        {
            Personaje NuevoPersonaje = new Personaje
            {
                Salud = 100,
                Nivel = 1,
                Nombre = NombrePersonajeAleatorio(),
                Apodo = ApodoAleatorio(),
                TipoPersonaje = TipoPersonajeAleatorio(),
                FechaNacimiento = FechaNacimientoAleatorio(),
                Velocidad = GeneradorAleatorio(1, 10),
                Destreza = GeneradorAleatorio(1, 5),
                Fuerza = GeneradorAleatorio(1, 10),
                Armadura = GeneradorAleatorio(1, 10)
            };
            NuevoPersonaje.Edad = ObtenerEdad(NuevoPersonaje.FechaNacimiento);

            return NuevoPersonaje;
        }

        string NombrePersonajeAleatorio()
        {
            Array valuesNombrePersonajes = Enum.GetValues(typeof(NombrePersonajes));
            return ((NombrePersonajes)valuesNombrePersonajes.GetValue(random.Next(valuesNombrePersonajes.Length))).ToString();
        }

        string ApodoAleatorio()
        {
            Array ValuesApodosPersonajes = Enum.GetValues(typeof(ApodosPersonajes));
            return ((ApodosPersonajes)ValuesApodosPersonajes.GetValue(random.Next(ValuesApodosPersonajes.Length))).ToString();
        }

        DateTime FechaNacimientoAleatorio()
        {
            TimeSpan years = new TimeSpan(random.Next(0, 301) * 365, 0, 0, 0);
            return DateTime.Now - years;
        }

        int ObtenerEdad(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Now;
            int edad = hoy.Year - fechaNacimiento.Year;

            if (hoy.Month < fechaNacimiento.Month || (hoy.Month == fechaNacimiento.Month && hoy.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            return edad;
        }
        int GeneradorAleatorio(int min, int max)
        {
            return random.Next(min, max + 1);
        }
        tipoPersonaje TipoPersonajeAleatorio()
        {
            Array valuesTipoPje = Enum.GetValues(typeof(tipoPersonaje));
            return (tipoPersonaje)valuesTipoPje.GetValue(random.Next(valuesTipoPje.Length));
        }


    }
}
