using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.StringToDNI = value.ToString();
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona()
        { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad)
        {
        }
        #endregion

        #region Validaciones
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino)
            {
                if(dato < 9000000)
                {
                    return dato;
                }
            } else if(nacionalidad == ENacionalidad.Extranjero)
            {
                if(dato > 89999999 && dato < 100000000)
                {
                    return dato;
                }
            }
            throw new NacionalidadInvalidaException("La nacionalidad no coincide con el numero de DNI");
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            int resultado = 0;
            bool flag;
            if (!(String.IsNullOrEmpty(dato)))
            {
                flag = int.TryParse(dato, out resultado);
                if (!flag)
                {
                    throw new DniInvalidoException();
                }
                else
                {
                    if(resultado < 1 || resultado > 99999999)
                    {
                        throw new DniInvalidoException();
                    } else
                    {
                        retorno = this.ValidarDni(nacionalidad, resultado);
                    }
                }
            }
            return retorno;
        }

        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            if (!(String.IsNullOrEmpty(dato)))
            {
                foreach (char c in dato)
                {
                    if (!Char.IsLetter(c))
                    {
                        return retorno;
                    }
                }
                retorno = dato;
            }
            return retorno;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return this.nombre + " - " + this.apellido + " - " + this.nacionalidad.ToString() + " - " + this.dni.ToString();
        }
        #endregion

    }
}
