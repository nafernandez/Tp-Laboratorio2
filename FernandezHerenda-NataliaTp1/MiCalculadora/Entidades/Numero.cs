using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     public class Numero
    {
        private double numero;
        public string setNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }
        double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }
            return numero;
        }

        private static bool EsBinario(string binario)
        {
            bool retorno = true;

            char[] arrayDeChar = binario.ToCharArray();
            for (int i = 0; i < arrayDeChar.Length; i++)
            {
                if (arrayDeChar[i] != '0' && arrayDeChar[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
         public static string BinarioDecimal(string binario)
        {
            string numeroBinario = "Valor inválido";

            if (EsBinario(binario))
            {
                numeroBinario = Convert.ToInt32(binario, 2).ToString();
            }
            return numeroBinario;
        }
        public static string DecimalBinario(string numero)
        {
            string resultado;
            double numeroEnDouble;

            if (double.TryParse(numero, out numeroEnDouble))
            {
                resultado = DecimalBinario(numeroEnDouble);
            }
            else
            {
                resultado = "Valor invalido";
            }
            return resultado;
        }
        public static string DecimalBinario(double numero)
        {
            string retorno = "Valor Inválido";
            if (numero > 0)
            {
                String cadena = "";
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2);
                    retorno = cadena;
                }
            }
            else
            {
                if (numero == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    return retorno;
                }
            }
            return retorno;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else

                return n1.numero / n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
    
    }
}
