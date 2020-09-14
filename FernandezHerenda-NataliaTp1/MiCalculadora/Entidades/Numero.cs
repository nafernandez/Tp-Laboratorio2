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
        /// <summary>
        /// Valida que sea un numero y se lo asigna a numero que es el atributo de la clase
        /// </summary>
        public string setNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// Constructor por defecto se le asigna 0 y sin parametros.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor. En el asignamos el parametro a this.numero.
        /// </summary>
        /// <param name="numero">Ingresa por parametro un double para poder validarlo como setter</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor. En el ingresa un string y se valida si es numero o no.
        /// </summary>
        /// <param name="strNumero">String que ingresa por parametro para poder validarlo.</param>
        public Numero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }
        /// <summary>
        /// Comprueba que el valor recibido sea numérico.
        /// </summary>
        /// <param name="strNumero">Recibe por parametro un string para poder convertirlo</param>
        /// <returns>Retorna un double cuando corrobora que se puede convertir de string a double</returns>
        double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }
            return numero;
        }
        /// <summary>
        /// Valida que la cadena de caracteres sea '1' y '0'.
        /// </summary>
        /// <param name="binario">Recibe por parametro un string para poder corroborar</param>
        /// <returns>Retorna true si es binario y false si no lo es.</returns>
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
        /// <summary>
        /// Convierte el resultado, trabaja con enteros positivos.
        /// Valida que se trate de un binario y luego lo convierte de binario a decimal.
        /// </summary>
        /// <param name="binario">Recibe un string por parametro para tratar de convertirlo.</param>
        /// <returns>Retorna un decimal y si no es posible retorna "Valor inválido"</returns>
         public static string BinarioDecimal(string binario)
        {
            string numeroBinario = "Valor inválido";

            if (EsBinario(binario))
            {
                numeroBinario = Convert.ToInt32(binario, 2).ToString();
            }
            return numeroBinario;
        }
        /// <summary>
        /// Convierte el resultado, trabaja con enteros positivos.
        /// Convertira un número de decimal a binario, en caso de ser posible.
        /// </summary>
        /// <param name="numero">Recibe por parametro un string para poder convertirlo.</param>
        /// <returns>Retorna un binario y en caso de no ser posible, retorna "valor inválido"</returns>
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
                resultado = "Valor inválido";
            }
            return resultado;
        }
        /// <summary>
        /// Corrobora que el numero sea mayor de 0 para poder castearlo a int y obtener el numero binario.
        /// </summary>
        /// <param name="numero">Recibe un double por parametro para poder validarlo</param>
        /// <returns>Si es válido retorna el numero en binario, sino "Valor inválido"</returns>
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
        /// <summary>
        /// Realiza la operacion resta.
        /// </summary>
        /// <param name="n1">Obtiene por parametro n1 de tipo Numero</param>
        /// <param name="n2">Obtiene por parametro n2 de tipo Numero</param>
        /// <returns>Retorna la resta obtenida.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// Realiza la operacion multiplicación.
        /// </summary>
        /// <param name="n1">Obtiene por parametro n1 de tipo Numero</param>
        /// <param name="n2">Obtiene por parametro n2 de tipo Numero</param>
        /// <returns>Retorna la multiplicación obtenida.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// Realiza la operacion división.
        /// </summary>
        /// <param name="n1">Obtiene por parametro n1 de tipo Numero</param>
        /// <param name="n2">Obtiene por parametro n2 de tipo Numero</param>
        /// <returns>Retorna la división obtenida.
        /// Si se trata de division por 0, retorna double.MinValue.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else

                return n1.numero / n2.numero;
        }
        /// <summary>
        /// Realiza la operacion suma.
        /// </summary>
        /// <param name="n1">Obtiene por parametro n1 de tipo Numero.</param>
        /// <param name="n2">Obtiene por parametro n2 de tipo Numero.</param>
        /// <returns>Retorna la suma obtenida.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
    
    }
}
