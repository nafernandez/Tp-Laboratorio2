using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// ValidarOperador se utiliza para poder validar el char que recibe por parametro el método, en caso de que no sea
        /// +,-,/ o *, lo convierte en +.
        /// </summary>
        /// <param name="operador"> recibe el operador de tipo char por parametro</param>
        /// <returns>retorna un string en vez de char para poder utilizarlo en otros métodos</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno = "+";
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                retorno = Convert.ToString(operador);
            }
            return retorno;
        }
        /// <summary>
        /// Valida la operación con el método ValidarOperador y realiza la operación
        /// correspondiente.
        /// </summary>
        /// <param name="num1">recibe num1 de tipo Numero para poder realizar la operación</param>
        /// <param name="num2">recibe num2 de tipo Numero para poder realizar la operación</param>
        /// <param name="operador">recibe operador de tipo string para poder validarlo</param>
        /// <returns>retorna un double para poder obtener el resultado de la operación</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            ValidarOperador(Convert.ToChar(operador));
            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }
            return resultado;
        }
    }
}
