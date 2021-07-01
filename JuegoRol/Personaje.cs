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

        public void PrePelea(Personaje defensor)
        {
            Console.WriteLine("\nSalud Inicial\n");
            Console.WriteLine(Nombre + ": " + Math.Round(Salud));
            Console.WriteLine(defensor.Nombre + ": " + Math.Round(defensor.Salud, 2) + "\n");
        }

        public void Atacar(Personaje defensor)
        {
            float Ataque = Destreza * Fuerza * Nivel;
            float Precision = (float)random.Next(1, 101);
            float ValorDeAtaque = Ataque * Precision;
            float CritChance = random.Next(1, 4);

            float PoderDeDefensa = (float)(defensor.Armadura * defensor.Velocidad);
            float MaxDamage = 50000;

            float Damage = ((ValorDeAtaque * Precision - PoderDeDefensa) / MaxDamage) * CritChance * 10;


            defensor.Salud -= Damage;

            if(defensor.Salud < 0)
            {
                defensor.Salud = 0;
            }
        }
        public void Curarse()
        {
            if (random.Next(10) > 5)
            {
                if (Salud + 20 < 100)
                {
                    Salud += 20;
                }
                else
                {
                    Salud = 100;
                }
            }
        }

        public void SubirDeNivel()
        {
            Nivel += 1;
            Velocidad += random.Next(2);
            Destreza += random.Next(3);
            Fuerza += random.Next(2);
            Armadura += random.Next(2);
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
