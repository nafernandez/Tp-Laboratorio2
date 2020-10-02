using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible)
            :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", (object)taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");

            foreach (Vehiculo vehiculo in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if(vehiculo is Ciclomotor)
                        {
                            sb.AppendLine(vehiculo.Mostrar());
                            break;
                        }
                        break;
                    case ETipo.Sedan:
                        if (vehiculo is Sedan)
                        {
                            sb.AppendLine(vehiculo.Mostrar());
                            break;
                        }
                        break;
                    case ETipo.SUV:
                        if (vehiculo is Suv)
                        {
                            sb.AppendLine(vehiculo.Mostrar());
                            break;
                        }
                        break;
                    default:
                        sb.AppendLine(vehiculo.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if(taller.vehiculos.Count>= taller.espacioDisponible)
            {
                return taller;
            }
            foreach (Vehiculo vehiculoAAgregar in taller.vehiculos)
            {
                if (vehiculoAAgregar == vehiculo)
                {
                    return taller;
                }    
            }

            taller.vehiculos.Add(vehiculo);
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            
            for (int i=0; i< taller.vehiculos.Count; i++)
            {
                if(taller.vehiculos[i]== vehiculo)
                {
                    taller.vehiculos.RemoveAt(i);
                    break;
                }
            }
            return taller;
        }
        #endregion

        public enum ETipo
        {
            Ciclomotor,
            Sedan,
            SUV,
            Todos,
        }
    }
}
