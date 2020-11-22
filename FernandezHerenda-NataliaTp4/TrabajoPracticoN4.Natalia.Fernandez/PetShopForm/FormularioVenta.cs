using Entidades;
using Entidades.Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShopForm
{
    public partial class FormularioVenta : Form
    {
        private ManejadorDeMensajes manejadorDeMensajes;
        public FormularioVenta()
        {
            InitializeComponent();
        }

        private Producto productoSeleccionado;
        private PetShop petShop;

        public FormularioVenta(PetShop petShop, Producto productoSeleccionado, ManejadorDeMensajes manejadorDeMensajes)
        {
            InitializeComponent();
            this.petShop = petShop;
            this.productoSeleccionado = productoSeleccionado;
            this.manejadorDeMensajes = manejadorDeMensajes;
        }

        private void VentasForm_Load(object sender, EventArgs e)
        {
            this.lblDescripcion.Text = this.productoSeleccionado.Descripcion;
            ActualizarPrecio();
        }

        private void OnCantidadChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        private void ActualizarPrecio()
        {
            int cantidadSeleccionada = Convert.ToInt32(this.NUDCantidad.Value);
            double nuevoPrecioFinal = Venta.CalcularPrecioFinal(this.productoSeleccionado.Precio, cantidadSeleccionada);
        }


        private void OnVenderClick(object sender, EventArgs e)
        {
            try
            {
                int cantidadSeleccionada = Convert.ToInt32(this.NUDCantidad.Value);

                if (productoSeleccionado.Stock >= cantidadSeleccionada)
                {
                    this.petShop.Vender(this.productoSeleccionado, cantidadSeleccionada);
                    this.DialogResult = DialogResult.OK;
                    this.manejadorDeMensajes.ManejarMensaje("Venta realizada exitosamente!", Entidades.TipoMensajeCronometrado.SUCCESS, 4000);
                    this.Close();
                }
                else
                {
                    this.manejadorDeMensajes.ManejarMensaje("Cantidad superada", Entidades.TipoMensajeCronometrado.ERROR, 4000);
                }
            }catch(Exception ex)
            {
                manejadorDeMensajes.ManejarMensaje(ex, 5000);
            }
            
        }

        /// <summary>
        /// Manejador del evento click del botón cancelar.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
