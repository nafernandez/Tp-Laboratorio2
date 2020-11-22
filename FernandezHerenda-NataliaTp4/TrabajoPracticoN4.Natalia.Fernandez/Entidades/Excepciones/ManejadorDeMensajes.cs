using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Excepciones
{
    public class ManejadorDeMensajes
    {/// <summary>
    /// EXCEPCIONES
    /// </summary>
        private MensajeCronometrado mensaje;
        /// <summary>
        /// Metodo donde se le asigna una excepcion y una duracion a mostrar del mensaje. Se instancia un mensaje cronometrado en el con error.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="duracion"></param>
        public void ManejarMensaje(Exception exception, long duracion)
        {
            this.mensaje = new MensajeCronometrado(duracion, TipoMensajeCronometrado.ERROR, exception.Message);
        }
        /// <summary>
        /// Obtiene el mensaje a mostrar(error, success, warning, info)
        /// </summary>
        /// <returns></returns>
        public string ObtenerMensajeAMostrar()
        {
            if(this.mensaje == null)
            {
                return String.Empty;
            }

            return this.mensaje.Mensaje;
        }
        /// <summary>
        /// Actualiza el label donde muestra el mensaje
        /// </summary>
        public void Actualizar()
        {
            if(this.mensaje !=null && this.mensaje.EstaVencido())
            {
                this.mensaje = null;
            }
        }
        /// <summary>
        /// Maneja el mensaje, el tiempo, la duracion y el tipo de mensaje.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="tipo"></param>
        /// <param name="duracion"></param>
        public void ManejarMensaje(string mensaje, TipoMensajeCronometrado tipo, long duracion)
        {
            this.mensaje = new MensajeCronometrado(duracion, tipo, mensaje);
        }
        /// <summary>
        /// Obtiene el tipo de mensaje
        /// </summary>
        /// <returns></returns>
        public TipoMensajeCronometrado ObtenerTipoDeMensaje()
        {
            if (this.mensaje == null)
            {
                return TipoMensajeCronometrado.INFO;
            }

            return this.mensaje.Tipo;
        }
    }
}
