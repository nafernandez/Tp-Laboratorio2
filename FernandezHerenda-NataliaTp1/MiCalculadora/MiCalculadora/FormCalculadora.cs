using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Método que se desata luego del evento click sobre el boton operar.
        /// Corrobora que no ingrese vacío los textBox y el comboBox no sea nulo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text != "" && txtNumero2.Text != "" && this.cmbOperador.SelectedItem != null)
            {
                this.lblResultado.Text = (Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.SelectedItem.ToString()).ToString());
            }
            else
                lblResultado.Text = "Valores inválidos";
        }
        /// <summary>
        /// Limpia los textBox, comboBox y el Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.ResetText();
            cmbOperador.ResetText();
        }
        /// <summary>
        /// Llama al método Operar para poder realizar la operacion que es recibida por operador
        /// con los numeros que son recibidos.
        /// </summary>
        /// <param name="numero1">Tipo string para poder crear un nuevo Numero</param>
        /// <param name="numero2">Tipo string para poder crear un nuevo Numero</param>
        /// <param name="operador">Tipo string para poder usarlo como parametro para el método Operar</param>
        /// <returns>Retorna un double como resultado.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            Numero primerNumero = new Numero(numero1);
            Numero segundoNumero = new Numero(numero2);
            resultado = Calculadora.Operar(primerNumero, segundoNumero, operador);
            
            return resultado;
        }
        /// <summary>
        /// Cierra el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Convierte en binario el numero que tiene el label y se le asigna al label nuevamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
        }
        /// <summary>
        /// Convierte en decimal el numero que tiene el label y se le asigna al label nuevamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
        }

       
    }
}
