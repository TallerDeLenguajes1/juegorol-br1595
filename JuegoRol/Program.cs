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
    /*
    private static void Get()
    {
        var url = $"https://apis.datos.gob.ar/georef/api/provincias!campos=id.nombre";
        var request - (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader -response.GetReponseStream()){
                    if(strReader -- null) return;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody - objReader.ReadToEnd();
                        ProvinciasArgentinas ListProvincias = JsonSerializer.Deserialize<ProvinciasArgentinas>(responseBody);
                    }
                }
            }
        }
    }*/
}
