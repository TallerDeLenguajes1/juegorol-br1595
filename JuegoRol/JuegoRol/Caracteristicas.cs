using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRol
{
    class Caracteristicas
    {
        private float velocidad;
        private float destreza;
        private float fuerza;
        private int nivel;
        private float armadura;

        public float Velocidad { get => velocidad; set => velocidad = value; }
        public float Destreza { get => destreza; set => destreza = value; }
        public float Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public float Armadura { get => armadura; set => armadura = value; }
    }
}
