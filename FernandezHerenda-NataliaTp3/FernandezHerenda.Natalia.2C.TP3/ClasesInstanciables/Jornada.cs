using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Constructores
        /// <summary>
        /// Constructor por defecto donde se inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Sobrecarga de constructor donde se llama al constructor por defecto
        /// </summary>
        /// <param name="clase">Se asigna la clase que recibe por parametro</param>
        /// <param name="instructor">Se asigna el instructor que recibe por parametro</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad de lectura y escritura de la lista alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guardara los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>retorna si es true o false</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            bool sePudoGuardar = texto.Guardar("Jornada.txt", jornada.ToString());
            return sePudoGuardar;
        }
        /// <summary>
        /// retornara los datos de la jornada como texto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string datosJornada = string.Empty;
            Texto texto = new Texto();
            texto.Leer("Jornada.txt", out datosJornada);
            return datosJornada;
        }
        /// <summary>
        /// Mostrara todos los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Clase de: {0}\n", this.clase);
            sb.AppendFormat("Profesor: {0}\n", this.instructor);

            foreach (Alumno alumno in alumnos)
            {
                sb.AppendFormat("\n", alumno.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Una jornada no sera igual a un alumno si el mismo NO participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Una jornada sera igual a un alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return j.alumnos.Contains(a);
        }
        /// <summary>
        /// Se agrega alumnos y se valida que no esten previamente cargados
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        #endregion
    }
}
