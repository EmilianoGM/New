using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor() : base() { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        protected override string ParticiparEnClase()
        {
            return "CLASES DEL DIA:";
        }

        private void _randomClases()
        {
            int numeroDeClase;
            Universidad.EClases clase;
            if (!(this.clasesDelDia.Equals(null)))
            {
                for (int i = 0; i < 2; i++)
                {
                    numeroDeClase = Profesor.random.Next(0, 4);
                    clase = (Universidad.EClases)Enum.ToObject(typeof(Universidad.EClases), numeroDeClase);
                    this.clasesDelDia.Enqueue(clase);
                }
            }          
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (i.clasesDelDia.Contains(clase))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
