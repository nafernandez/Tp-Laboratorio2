using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Constructores
        /// <summary>
        /// Constructor por defecto de alumno
        /// </summary>
        public Alumno()
        {
        }
        /// <summary>
        /// Constructor que llama al constructor de Universitario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor que llama al constructor de Alumno con 5 parametros y se le asigna el estado de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// protected
        /// Muestra los datos de Universitario, el estado de cuenta y la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            string estado= null;

            sb.AppendFormat("{0}\n", base.MostrarDatos());
            
            switch(this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    estado = "Cuota al día";
                    break;
                case EEstadoCuenta.Becado:
                    estado = "Becado";
                    break;
                case EEstadoCuenta.Deudor:
                    estado = "Debe cuotas";
                    break;
            }
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", estado);
            sb.AppendFormat("{0}", this.ParticiparEnClase());

            return sb.ToString();
        }
        /// <summary>
        /// Metodo donde muestra la clase que toma
        /// </summary>
        /// <returns>Retorna la cadena de clase q toma</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("TOMA CLASES DE: {0}\n", this.claseQueToma.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos de mostrar datos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Un alumno sera distinto de una clase solo si no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }
        /// <summary>
        /// Un alumno sera igual a una clase si toma esa clase y su estado de cuenta no es deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado donde se declara alDia, Deudor y Becado
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado,
        }

        #endregion
    }
}
