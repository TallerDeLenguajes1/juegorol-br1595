using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRol
{
    public enum tipoPersonaje
    {
        Monje,
        Ninja,
        Templario,
        Samurai,
        Normal
    }
    public class Personaje
    {
        Random random = new Random();

        private int velocidad, destreza, fuerza, nivel, armadura, edad;
        private float salud;
        private tipoPersonaje tipo;
        private string nombre, apodo;
        private DateTime fechaNacimiento;

        public void MostrarPersonaje()
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Apodo: {Apodo}");
            Console.WriteLine($"Fecha de nacimiento: {FechaNacimiento.ToString("dd-MM-yyyy")}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Tipo: {TipoPersonaje}");
            Console.WriteLine("\nCaracteristicas:");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Velocidad: {Velocidad}");
            Console.WriteLine($"Destreza: {Destreza}");
            Console.WriteLine($"Fuerza: {Fuerza}");
            Console.WriteLine($"Armadura: {Armadura}");
        }

        public void Atacar(Personaje defensor)
        {
            float Ataque = Destreza * Fuerza * Nivel;
            float Precision = (float)random.Next(1, 101);
            float valorDeAtaque = Ataque * Precision;
            float critChance = random.Next(1, 4);

            float poderDeDefensa = (float)(defensor.Armadura * defensor.Velocidad);
            float maxDamage = 50000;

            float damage = ((valorDeAtaque * Precision - poderDeDefensa) / maxDamage) * critChance * 10;
               

            defensor.Salud -= damage;
        }

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public tipoPersonaje TipoPersonaje { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public float Salud { get => salud; set => salud = value; }
    }
}
