﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        public Universitario() : base()
        { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            return this.ToString() + " - " + this.legajo.ToString();
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if(pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                return (Universitario)obj == this;
            }
            return false;
        }
    }
}
