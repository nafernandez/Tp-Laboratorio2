using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Persona()
        {
        }
        /// <summary>
        /// Constructor que llama al constructor por defecto, recibe por parametro nombre, apellido, nacionalidad.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor que llama al constructor de 3 parametros y se le agrega el dni en int
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que llama al constructor que tiene 3 parametros y se le agrega dni en string
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad de lectura y escritura para apellido (en el set se valida el apellido si es letra o esta vacio)
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para DNI(en el set se valida el dni si es valido o no)
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para nombre(En el set se valida si el nombre es vacio o es valido)
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de solo escritura donde se valida el dni si lo recibe como string
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo donde se muestra los datos de la Persona con un StringBuilder
        /// </summary>
        /// <returns>Retorna todos los datos en forma de string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
     
            sb.AppendFormat("Nombre: {0}\n", Nombre);
            sb.AppendFormat("Apellido: {0}\n", Apellido);
            sb.AppendFormat("Dni: {0}\n", DNI);
            sb.AppendFormat("Nacionalidad: {0}\n", Nacionalidad);

            return sb.ToString();
        }
        /// <summary>
        /// Metodo donde se valida el dni si pertenece para argentino o extranjero
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna un int, retorna el dni y si no es valida la nacionalidad, lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        return dato;
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        return dato;
                    }
                    break;
            }

            throw new NacionalidadInvalidaException();
        }

        /// <summary>
        /// Metodo donde se valida el dni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>retorna la validacion del dni y sino lanza una excepcion de dni invalido</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!int.TryParse(dato, out dni))
            {
                throw new DniInvalidoException();
            }

            return ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Metodo que valida el nombre o apellido dependiendo el caso si esta vacio o si son letras.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>retorna el nombre</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char caracter in dato)
            {
                if (!(char.IsLetter(caracter) && char.IsWhiteSpace(caracter)))
                {
                    return null;
                }
            }

            return dato;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado donde se declara Argentino y Extranjero.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero,
        }
        #endregion
    }
}
