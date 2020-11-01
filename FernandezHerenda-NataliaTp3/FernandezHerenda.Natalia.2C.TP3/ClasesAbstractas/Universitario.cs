using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor que llama al constructor de Persona
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo equals donde se evalua si el legajo de univesitario es igual al legajo de objeto y lo mismo con el dni
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>retorna true si es igual, false si no lo cumple</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                if (this.legajo == ((Universitario)obj).legajo || this.DNI == ((Universitario)obj).DNI)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Metodo de mostrar datos donde muestra el legajo y los datos del universitario
        /// </summary>
        /// <returns>retorna un string con todos los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}\n", base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);

            return sb.ToString();
        }
        /// <summary>
        /// metodo declarado abstracto para que se desarrolle en las clases que se necesitan(clases derivadas)
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores
        /// <summary>
        /// Operador donde desarrolla que dos universitaros no son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// operador donde dos universitarios seran iguales si son de mismo tipo y legajo o dni iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2))
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
