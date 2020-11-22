using Entidades;
using Entidades.Datos;
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
    public partial class AgregarProductosFormulario : Form
    {
        private ManejadorDeMensajes manejadorDeMensajes;
        public AgregarProductosFormulario(ManejadorDeMensajes manejadorDeMensajes)
        {
            InitializeComponent();
             this.manejadorDeMensajes = manejadorDeMensajes;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string nuevaDescripcion = this.txtDescripcion.Text;
                double nuevoPrecio = Convert.ToDouble(this.txtPrecio.Text);
                int nuevoStock = (int)this.NUDStock.Value;
                this.manejadorDeMensajes.ManejarMensaje("Compra realizada exitosamente!", Entidades.TipoMensajeCronometrado.SUCCESS, 4000);
               ;

                Producto productoExistente = null; 
                foreach (Producto producto  in PetShop.GetInstance().Productos)
                {
                    if(producto.Descripcion.Equals(nuevaDescripcion))
                    {
                        productoExistente = producto;
                        break;
                    }
                }

                Boolean productoYaExiste = productoExistente != null;

                if(productoYaExiste)
                {
                    ProductosDAO.Update(productoExistente.Codigo, productoExistente.Precio, productoExistente.Stock + nuevoStock);
                    productoExistente.Stock += nuevoStock;
                }
                else
                {
                    productoExistente = new Producto(0, nuevaDescripcion, nuevoStock, nuevoPrecio);
                    ProductosDAO.Insert(nuevaDescripcion, nuevoPrecio, nuevoStock);
                }

                
                PetShop.GetInstance().Comprar(productoExistente, nuevoStock);
                this.Close();
            }catch(Exception ex)
            {
                manejadorDeMensajes.ManejarMensaje(ex, 5000);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
