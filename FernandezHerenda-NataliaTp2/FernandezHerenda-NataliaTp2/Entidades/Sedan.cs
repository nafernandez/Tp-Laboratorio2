using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
     public class Sedan : Vehiculo
    {
        private ETipo tipo;

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override Vehiculo.ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        /// <summary>
        /// Metodo mostrar que se sobreescribe con el override para mostrar los datos de Sedan y de la clase base(vehiculo)
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + (object)this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = Sedan.ETipo.CuatroPuertas;
        }
        /// <summary>
        /// constructor donde se le asigna el tipo que recibe por parametro a este tipo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
             : base(chasis, marca, color) 
        {
            this.tipo = tipo;
        }
        public enum ETipo
        {
            CuatroPuertas,
            CincoPuertas,
        }
    }
}
