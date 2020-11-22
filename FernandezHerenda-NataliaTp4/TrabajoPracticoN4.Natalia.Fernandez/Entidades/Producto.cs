using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Producto
    {
        private int stock;
        private double precio;
        private int codigo;
        private string descripcion;

        #region Constructores

        public Producto()
        {
        }

        /// <summary>
        /// Constructor. Inicializa los atributos del producto. 
        /// </summary>
        /// <param name="codigo">Codigo único del producto en la base de datos.</param>
        /// <param name="descripcion">Descripción del producto.</param>
        /// <param name="stock">Stock disponible del producto.</param>
        /// <param name="precio">Precio del producto.</param>
        public Producto(int codigo, string descripcion, int stock, double precio)
        {
            this.codigo = codigo;
            this.Stock = stock;
            this.Precio = precio;
            this.Descripcion = descripcion;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Stock del producto. Se verifica que sea mayor a 0
        /// </summary>
        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                if (value >= 0)
                {
                    this.stock = value;
                }
            }
        }

        /// <summary>
        /// Precio del producto. Debe ser mayor a 1. 
        /// </summary>
        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                if (value >= 1)
                {
                    this.precio = value;
                }
            }
        }

        /// <summary>
        /// Descripción del producto. 
        /// </summary>
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        /// <summary>
        /// Código del producto en la base de datos
        /// Propiedad de sólo lectura. 
        /// </summary>
        public int Codigo
        {
            get
            {
                return this.codigo;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve un string con los datos de un producto: código, descripción, precio y stock. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("ID: {0} - ", this.Codigo));
            sb.AppendLine(String.Format("{0} - ", this.Descripcion));
            sb.AppendLine(String.Format("${0:0.00} - ", this.Precio));
            sb.AppendLine(String.Format("{0} u.", this.Stock));

            return sb.ToString();
        }
        #endregion
    }
}
