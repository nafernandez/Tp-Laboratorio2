using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Datos
{
    /// <summary>
    /// METODO DE EXTENSION
    /// </summary>
    public static class FormatoPrecio
    {
        /// <summary>
        /// Metodo de extension que cambia la estructura del formato del precio
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string CambioEstructuraPrecio(this Double valor)
        {
            return String.Format("${0:0.00}", valor);
        }
    }
}
