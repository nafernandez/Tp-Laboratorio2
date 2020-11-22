using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Excepciones;
using Entidades.Datos;

namespace PetShopForm
{
    public partial class FormPetShop : Form
    {
        private PetShop petShop;
        private ManejadorDeMensajes manejadorDeMensajes;
        private Producto producto;
        /// <summary>
        /// DELEGADO
        /// </summary>
        delegate void Callback();
        private Thread thread;
        public FormPetShop()
        {
            InitializeComponent();
            this.petShop = PetShop.GetInstance();
            this.petShop.ListaDeProductosModificada += ActualizacionLista;
            this.manejadorDeMensajes = new ManejadorDeMensajes();
        }

        private void FormPetShop_Load(object sender, EventArgs e)
        {
            this.ActualizacionLista();
            this.InicializarChequeoDeMensajes();

            
        }

       private void ActualizacionLista()
        {
            try
            {
                this.richTextBoxVentas.Text = this.petShop.MostrarVentas();
                this.listBoxProductos.DataSource = null;
                this.listBoxProductos.Refresh();
                this.listBoxProductos.DataSource = this.petShop.Productos;
                this.listBoxProductos.DisplayMember = "Descripcion";

                if (this.petShop.Productos.Count > 0)
                {
                    this.listBoxProductos.SelectedIndex = 0;
                    this.ActualizarProductoSeleccionado();
                }
            }
            catch (Exception ex)
            {
                this.manejadorDeMensajes.ManejarMensaje(ex, 5000);
            }
        }

        private void ActualizarProductoSeleccionado()
        {
            try
            {
                this.producto = (Producto)this.listBoxProductos.SelectedValue;
                if (producto != null)
                {
                    this.listBoxDetalleProducto.Text = this.producto.ToString();
                }
            }
            catch (Exception ex)
            {
                this.manejadorDeMensajes.ManejarMensaje(ex, 5000);
            }
        }

        private void ListBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarProductoSeleccionado();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                Form formularioVenta = new FormularioVenta(this.petShop, (Producto)this.listBoxProductos.SelectedItem, manejadorDeMensajes);
               
                DialogResult result = formularioVenta.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.richTextBoxVentas.Text = this.petShop.MostrarVentas();
                }
            }
            catch (Exception ex)
            {
                throw new PetShopException("El producto no se pudo eliminar", ex);
            }
        }

        private void InicializarChequeoDeMensajes()
        {
           thread= new Thread(this.ActualizarLabelDeMensajes);
            thread.Start();
        }

        public void ActualizarLabelDeMensajes()
        {
            while(true)
            {
                this.AsignarMensaje();
                Thread.Sleep(1000);
            }    
        }
        public void AsignarMensaje()
        {
            if (this.lblError.InvokeRequired)
            {
                Callback d = new Callback(this.AsignarMensaje);
                this.Invoke(d);
            }
            else
            {
                this.manejadorDeMensajes.Actualizar();
                switch(this.manejadorDeMensajes.ObtenerTipoDeMensaje())
                {
                    case TipoMensajeCronometrado.ERROR:
                        this.lblError.ForeColor = System.Drawing.Color.Red;
                        break;
                    case TipoMensajeCronometrado.INFO:
                        this.lblError.ForeColor = System.Drawing.Color.Blue;
                        break;
                    case TipoMensajeCronometrado.SUCCESS:
                        this.lblError.ForeColor = System.Drawing.Color.Green;
                        break;
                    case TipoMensajeCronometrado.WARNING:
                        this.lblError.ForeColor = System.Drawing.Color.Orange;
                        break;
                }
                this.lblError.Text = this.manejadorDeMensajes.ObtenerMensajeAMostrar();
            }
        }

        private void FormularioPetShop_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarProductosFormulario formulario = new AgregarProductosFormulario(manejadorDeMensajes);

                DialogResult result = formulario.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.richTextBoxCompras.Text = this.petShop.MostrarCompras();
                }
            }
            catch (Exception ex)
            {
                throw new PetShopException("El producto no se pudo comprar", ex);
            }
        }

        private void listBoxProductos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.listBoxDetalleProducto.Items.Clear();
            if (this.listBoxProductos.SelectedItem != null)
            {
                this.listBoxDetalleProducto.Items.Add(this.listBoxProductos.SelectedItem);
            }
        }
    }
}
