using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa las listas de profesor, jornada y alumno
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad de lectura y escritura de Alumnos
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
        /// Propiedad de lectura y escritura de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura donde se accede a traves de un indexador
        /// </summary>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Serializara los datos de la Universidad en un XML, incluyendo los datos de sus profes, alumnos, jornadas.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> archivoXml = new Xml<Universidad>();

            return archivoXml.Guardar("Universidad.xml", uni);
        }
        /// <summary>
        /// Retornara una universidad con todos los datos previamente serializados
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> archivoXml = new Xml<Universidad>();
            Universidad universidad;
            archivoXml.Leer("Universidad.xml", out universidad);
            return universidad;
        }
        /// <summary>
        /// Mostrara los datos de alumno, universidad y clases.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            sb.Append("CLASE DE ");
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendFormat(jornada.ToString());
            }

            sb.AppendLine("Dictada por:  ");
            foreach (Profesor profesor in uni.Instructores)
            {
                sb.AppendFormat(profesor.ToString());
            }
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in uni.Alumnos)
            {
                sb.AppendFormat(alumno.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Hara publico mostrar datos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Operadores 
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Corrobora si la lista de alumnos contiene al alumno.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.alumnos.Contains(a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Corrobora si la lista de profes contiene al profe.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.profesores.Contains(i);
        }
        /// <summary>
        /// Retornada el primer profe que NO pueda dar la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor != clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Retornada el primer profe capaz de dar esa clase
        /// si no hay profe lanzara excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar 
        /// y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia)
        /// y  la lista de alumnos que la toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = g == clase;
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada += alumno;
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }
        /// <summary>
        /// Se agregarán Alumnos validando que no estén previamente cargados
        /// sino lanzara una excepcion
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
            {
                throw new AlumnoRepetidoException();
            }
            else
            {
                u.alumnos.Add(a);
            }

            return u;
        }
        /// <summary>
        /// Se agregarán Profesores validando que no estén previamente cargados
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!u.profesores.Contains(i))
            {
                u.profesores.Add(i);
            }

            return u;
        }
   
        #endregion

        #region Enumerados 
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD,
        }

        #endregion
    }
}
