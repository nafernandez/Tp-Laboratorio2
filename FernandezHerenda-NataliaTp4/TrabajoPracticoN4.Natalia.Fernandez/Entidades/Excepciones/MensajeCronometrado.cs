using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class MensajeCronometrado
    {
        private DateTime fechaInicio = DateTime.Now;
        private long duracion;
        private TipoMensajeCronometrado tipo;
        private string mensaje;
        /// <summary>
        /// Getter de tipo de mensaje
        /// </summary>
        public TipoMensajeCronometrado Tipo
        {
            get
            {
                return this.tipo;
            }
        }
        /// <summary>
        /// Getter de mensaje
        /// </summary>
        public string Mensaje
        {
            get
            {
                return mensaje;
            }
        }
        /// <summary>
        /// Constructor de mensaje cronometrado donde se le asigna la duracion, tipo de mensaje y el mensaje
        /// </summary>
        /// <param name="duracion"></param>
        /// <param name="tipo"></param>
        /// <param name="mensaje"></param>
        public MensajeCronometrado(long duracion, TipoMensajeCronometrado tipo, string mensaje)
        {
            this.mensaje = mensaje;
            this.tipo = tipo;
            this.duracion = duracion;
        }
        /// <summary>
        /// Metodo que corrobora si vencio o no el mensaje.
        /// </summary>
        /// <returns></returns>
        public bool EstaVencido()
        {
            return (DateTime.Now - this.fechaInicio).TotalMilliseconds > this.duracion;
        }
    }
}
