using Entidades.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public sealed class Compra
    {
        private Producto producto;
        private double precio;
        private int cantidad;
        private DateTime fecha;

        #region Constructores
        public Compra()
        {

        }
        /// <summary>
        ///  Constructor donde se le asigna por parametro los datos de la compra, producto, cantidad y fecha
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <param name="fecha"></param>
        internal Compra(Producto producto, int cantidad, DateTime fecha)
        {
            this.cantidad = cantidad;
            this.producto = producto;
            this.precio = producto.Precio;
            this.fecha = fecha;
            Comprar(cantidad);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propiedad de lectura y escritura para cantidad
        /// </summary>
        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.cantidad = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para Producto
        /// </summary>
        public Producto Producto
        {
            get
            {
                return this.producto;
            }
            set
            {
                this.producto = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para Precio
        /// </summary>
        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para Fecha
        /// </summary>
        public DateTime Fecha
        {
            get
            {
                return this.fecha;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo de compra donde se asigna la cantidad al stock
        /// </summary>
        /// <param name="cantidad"></param>
        private void Comprar(int cantidad)
        {
            producto.Stock += cantidad;
        }
        /// <summary>
        /// Privada. Obtiene la descripcion breve de los atributos CON EL METODO DE EXTENSION
        /// </summary>
        /// <returns></returns>
        private string ObtenerDescripcionBreve()
        {
            return String.Format("Descripcion: {0} PrecioFinal: {1}  Cantidad: {2}", this.producto.Descripcion, this.precio.CambioEstructuraPrecio(), this.Cantidad);
        }

        /// <summary>
        /// Devuelve un string con los datos de un producto: descripción, precio y stock. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ObtenerDescripcionBreve();
        }
        #endregion
    }
}
