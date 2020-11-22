using Entidades.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public sealed class Venta
    {
        private static int porcentajeIva;
        private Producto producto;
        private double precioFinal;
        private int cantidad;
        private DateTime fecha;

        #region Constructores
        /// <summary>
        /// Constructor que iniciliza el atributo estatico porcentajeIva
        /// </summary>
        static Venta()
        {
            Venta.porcentajeIva = 21;
        }

        public Venta()
        {

        }
        /// <summary>
        /// Constructor de venta que asigna el producto, cantidad y la fecha
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <param name="fecha"></param>
        internal Venta(Producto producto, int cantidad, DateTime fecha)
        {
            this.cantidad = cantidad;
            this.producto = producto;
            this.fecha = fecha;
            Vender(cantidad);
        }

        #endregion

        #region Properties
        /// <summary>
        /// Propiedad que obtiene y setea, segun lo que se desee, el valor del procentajeIva
        /// </summary>
        public static int PorcentajeIva
        {
            get
            {
                return Venta.PorcentajeIva;
            }
            set
            {
                Venta.PorcentajeIva = porcentajeIva;
            }
        }
        /// <summary>
        /// Propiedad de cantidad
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
        /// Propiedad de producto
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
        /// propiedad de Precio final
        /// </summary>
        public double PrecioFinal
        {
            get
            {
                return this.precioFinal;
            }
            set
            {
                this.precioFinal = value;
            }
        }
        /// <summary>
        /// propiedad de fecha de solo lectura
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
        /// Metodo donde se le quita la cantidad que se recibe por parametro al stock y calcula el precio final de la venta
        /// </summary>
        /// <param name="cantidad"></param>
        private void Vender(int cantidad)
        {
            producto.Stock -= cantidad;
            this.precioFinal = Venta.CalcularPrecioFinal(producto.Precio, cantidad);
        }
        /// <summary>
        /// Metodo estatico donde se calcula el precio final de la venta, se realiza la cuenta del porcentaje de iva
        /// </summary>
        /// <param name="precioUnidad"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static double CalcularPrecioFinal(double precioUnidad, int cantidad)
        {
            double precioSinIva = precioUnidad * cantidad;
            return precioSinIva + precioSinIva * Venta.porcentajeIva / 100;
        }
        /// <summary>
        /// Obtiene las descripciones de precio, cantidad y descripcion con SU METODO DE EXTENSION
        /// </summary>
        /// <returns></returns>
        public string ObtenerDescripcionBreve()
        {
            return String.Format("Descripcion: {0} PrecioFinal: {1}  Cantidad: {2}", this.producto.Descripcion, this.precioFinal.CambioEstructuraPrecio(), this.Cantidad);
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
