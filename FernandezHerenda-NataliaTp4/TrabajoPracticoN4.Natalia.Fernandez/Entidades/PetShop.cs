using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Datos;
using static Entidades.Datos.EnumeradoBaseDeDatos;

namespace Entidades
{
    public class PetShop: Serializadores<Venta>
    {
        private List<Producto> productos;
        private List<Venta> ventas;
        private List<Compra> compras;
        /// <summary>
        /// EVENTO
        /// </summary>
        public event Action ListaDeProductosModificada;
        private static PetShop singleton;

        #region Constructores
        /// <summary>
        /// Devuelve la instancia unica de la clase
        /// </summary>
        /// <returns></returns>
        public static PetShop GetInstance()
        {
            if (singleton == null)
            {
                singleton = new PetShop();
            }
            return singleton;
        }
        /// <summary>
        /// Constructor, instancia los campos de tipo lista. 
        /// Asocia el evento de cambios en la tabla de productos para actualizar la lista.
        /// </summary>
        private PetShop()
        {
            this.productos = ProductosDAO.SelectAll();
            ProductosDAO.CambiosAProductos += ActualizarListaProductos;
            this.ventas = new List<Venta>();
            this.compras = new List<Compra>();

        }

        #endregion

        #region Properties
        /// <summary>
        /// Propiedad solo lectura de lista de compras
        /// </summary>
        /// 
        public List<Compra> Compras
        {
            get
            {
                return this.compras;
            }
        }
        /// <summary>
        /// Propiedad solo lectura de lista de ventas
        /// </summary>
        public List<Venta> Ventas
        {
            get
            {
                return this.ventas;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de productos
        /// </summary>
        public List<Producto> Productos
        {
            get
            {
                return this.productos;
            }
            set
            {
                this.productos = value;
                this.ListaDeProductosModificada();
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Genera una nueva venta y crea un archivo xml. ARCHIVOS
        /// </summary>
        /// <param name="producto">Producto a Vender.</param>
        /// <param name="cantidad">Cantidad solicitada del producto.</param>
        public Venta Vender(Producto producto, int cantidad)
        {
            Venta nuevaVenta = new Venta(producto, cantidad, DateTime.Now);
            this.ventas.Add(nuevaVenta);

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), String.Format(@"Venta_{0}.xml", nuevaVenta.Fecha.ToString("ddMMyyyy_HHmmss")));
            Serializadores<Venta>.SerializarAXml(nuevaVenta, ruta);

            return nuevaVenta;
        }
        /// <summary>
        /// Genera una nueva venta y crea un archivo xml ARCHIVOS
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public Compra Comprar(Producto producto, int cantidad)
        {
            Compra nuevaCompra= new Compra(producto, cantidad, DateTime.Now);
            this.compras.Add(nuevaCompra);

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), String.Format(@"Compra_{0}.xml", nuevaCompra.Fecha.ToString("ddMMyyyy_HHmmss")));
            Serializadores<Compra>.SerializarAXml(nuevaCompra, ruta);

            return nuevaCompra;
        }
        /// <summary>
        /// BASE DE DATOS. actualiza la lista de productos en la base de datos.
        /// </summary>
        /// <param name="comando"></param>
        private void ActualizarListaProductos(ComandoBaseDeDatos comando)
        {
            this.Productos = ProductosDAO.SelectAll();
        }
        /// <summary>
        /// Devuelve un string conteniendo la descripción breve de cada venta en la lista de ventas. 
        /// </summary>
        /// <returns></returns>
        public string MostrarVentas()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Venta venta in ventas)
            {
                sb.AppendLine(venta.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        ///  Devuelve un string conteniendo la descripción breve de cada compra en la lista de compras. 
        /// </summary>
        /// <returns></returns>
        public string MostrarCompras()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Compra compra in compras)
            {
                sb.AppendLine(compra.ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}

