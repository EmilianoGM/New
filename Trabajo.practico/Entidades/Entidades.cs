using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double _numero;
        public Numero() : this(0)
        {
        }
        public Numero(double numero)
        {
            _numero = numero;
        }
        public Numero(string strNumero) : this(Double.Parse(strNumero))
        {
        }
        private double ValidarNumero(string strNumero)
        {
            double auxNumero;
            if(!Double.TryParse(strNumero, out auxNumero))
            {
                auxNumero = 0;
            }
            return auxNumero;
        }
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";
            bool flag = true;
            int auxNumero;
            for (int i = 0; i < binario.Length; i++)
            {
                if(binario[i] != 1 || binario[i] != 0)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                auxNumero = Convert.ToInt32(binario, 10);
                retorno = auxNumero.ToString();
            }
            return retorno;
        }
        public static string DecimalBinario(double numero)
        {
            string retorno;
            int auxNumero;
            auxNumero = Convert.ToInt32(Math.Abs(numero));
            retorno = Convert.ToString(auxNumero, 2);
            return retorno;
        }
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";
            double auxNumero;
            if (!Double.TryParse(numero, out auxNumero))
            {
                retorno = Numero.DecimalBinario(auxNumero);
            }
            return retorno;
        }
    }
}
