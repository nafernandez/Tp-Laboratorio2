namespace PetShopForm
{
    partial class FormPetShop
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxVentas = new System.Windows.Forms.RichTextBox();
            this.richTextBoxCompras = new System.Windows.Forms.RichTextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.lblListaProductos = new System.Windows.Forms.Label();
            this.lblListaVentas = new System.Windows.Forms.Label();
            this.lblCompras = new System.Windows.Forms.Label();
            this.gBoxAcciones = new System.Windows.Forms.GroupBox();
            this.listBoxProductos = new System.Windows.Forms.ListBox();
            this.lblError = new System.Windows.Forms.Label();
            this.listBoxDetalleProducto = new System.Windows.Forms.ListBox();
            this.gBoxAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxVentas
            // 
            this.richTextBoxVentas.Location = new System.Drawing.Point(29, 288);
            this.richTextBoxVentas.Name = "richTextBoxVentas";
            this.richTextBoxVentas.Size = new System.Drawing.Size(331, 150);
            this.richTextBoxVentas.TabIndex = 0;
            this.richTextBoxVentas.Text = "";
            // 
            // richTextBoxCompras
            // 
            this.richTextBoxCompras.Location = new System.Drawing.Point(426, 288);
            this.richTextBoxCompras.Name = "richTextBoxCompras";
            this.richTextBoxCompras.Size = new System.Drawing.Size(334, 150);
            this.richTextBoxCompras.TabIndex = 2;
            this.richTextBoxCompras.Text = "";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(45, 58);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Comprar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnVender
            // 
            this.btnVender.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.Location = new System.Drawing.Point(177, 58);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(75, 23);
            this.btnVender.TabIndex = 4;
            this.btnVender.Text = "Vender";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // lblListaProductos
            // 
            this.lblListaProductos.AutoSize = true;
            this.lblListaProductos.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaProductos.Location = new System.Drawing.Point(25, 16);
            this.lblListaProductos.Name = "lblListaProductos";
            this.lblListaProductos.Size = new System.Drawing.Size(153, 21);
            this.lblListaProductos.TabIndex = 6;
            this.lblListaProductos.Text = "Lista de productos:";
            this.lblListaProductos.UseMnemonic = false;
            // 
            // lblListaVentas
            // 
            this.lblListaVentas.AutoSize = true;
            this.lblListaVentas.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaVentas.Location = new System.Drawing.Point(26, 260);
            this.lblListaVentas.Name = "lblListaVentas";
            this.lblListaVentas.Size = new System.Drawing.Size(105, 21);
            this.lblListaVentas.TabIndex = 7;
            this.lblListaVentas.Text = "Lista Ventas:";
            // 
            // lblCompras
            // 
            this.lblCompras.AutoSize = true;
            this.lblCompras.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompras.Location = new System.Drawing.Point(423, 260);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(118, 21);
            this.lblCompras.TabIndex = 8;
            this.lblCompras.Text = "Lista compras:";
            // 
            // gBoxAcciones
            // 
            this.gBoxAcciones.Controls.Add(this.btnVender);
            this.gBoxAcciones.Controls.Add(this.btnAgregar);
            this.gBoxAcciones.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxAcciones.Location = new System.Drawing.Point(426, 40);
            this.gBoxAcciones.Name = "gBoxAcciones";
            this.gBoxAcciones.Size = new System.Drawing.Size(308, 109);
            this.gBoxAcciones.TabIndex = 9;
            this.gBoxAcciones.TabStop = false;
            this.gBoxAcciones.Text = "Lista de acciones";
            // 
            // listBoxProductos
            // 
            this.listBoxProductos.FormattingEnabled = true;
            this.listBoxProductos.Location = new System.Drawing.Point(29, 47);
            this.listBoxProductos.Name = "listBoxProductos";
            this.listBoxProductos.Size = new System.Drawing.Size(318, 173);
            this.listBoxProductos.TabIndex = 10;
            this.listBoxProductos.SelectedIndexChanged += new System.EventHandler(this.listBoxProductos_SelectedIndexChanged_1);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(393, 16);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16);
            this.lblError.TabIndex = 12;
            // 
            // listBoxDetalleProducto
            // 
            this.listBoxDetalleProducto.FormattingEnabled = true;
            this.listBoxDetalleProducto.Location = new System.Drawing.Point(426, 162);
            this.listBoxDetalleProducto.Name = "listBoxDetalleProducto";
            this.listBoxDetalleProducto.Size = new System.Drawing.Size(308, 95);
            this.listBoxDetalleProducto.TabIndex = 13;
            // 
            // FormPetShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxDetalleProducto);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.listBoxProductos);
            this.Controls.Add(this.gBoxAcciones);
            this.Controls.Add(this.lblCompras);
            this.Controls.Add(this.lblListaVentas);
            this.Controls.Add(this.lblListaProductos);
            this.Controls.Add(this.richTextBoxCompras);
            this.Controls.Add(this.richTextBoxVentas);
            this.Name = "FormPetShop";
            this.Text = "Formulario";
            this.Load += new System.EventHandler(this.FormPetShop_Load);
            this.gBoxAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxVentas;
        private System.Windows.Forms.RichTextBox richTextBoxCompras;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Label lblListaProductos;
        private System.Windows.Forms.Label lblListaVentas;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.GroupBox gBoxAcciones;
        private System.Windows.Forms.ListBox listBoxProductos;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ListBox listBoxDetalleProducto;
    }
}

