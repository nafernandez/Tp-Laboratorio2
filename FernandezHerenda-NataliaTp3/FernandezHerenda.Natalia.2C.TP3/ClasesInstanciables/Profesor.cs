using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Profesor
        /// </summary>
        public Profesor()
        {
        }
        /// <summary>
        /// Constructor estatico que inicializa a random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor que llama al constructor de universitario y se agregan dos clases randoms
        /// y se inicializa clasesDelDia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Asigna dos clases randoms a la cola
        /// </summary>
        private void _randomClases()
        {
            Universidad.EClases clase = (Universidad.EClases)random.Next(0, 3);
            clasesDelDia.Enqueue(clase);
        }
        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat(ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Muestra las clases del dia que puede dar el profesor
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores
        /// <summary>
        /// un profesor NO sera igual a una EClase si NO da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Un profesor sera igual a un Eclase si da esa clase
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        #endregion
    }
}
