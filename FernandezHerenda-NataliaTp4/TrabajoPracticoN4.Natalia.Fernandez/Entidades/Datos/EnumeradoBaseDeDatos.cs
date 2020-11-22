using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Datos
{
    public class EnumeradoBaseDeDatos
    {
        /// <summary>
        /// enumerador para los comandos de la base de datos
        /// </summary>
        public enum ComandoBaseDeDatos
        {
            Insert,
            Update,
            Delete
        }
    }
}
