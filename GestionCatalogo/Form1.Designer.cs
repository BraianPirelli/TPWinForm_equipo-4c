namespace GestionCatalogo
{
    partial class Form1
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
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.picArticulos = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscador = new System.Windows.Forms.Label();
            this.lblMenuPrincipal = new System.Windows.Forms.Label();
            this.btnCambiarImagen = new System.Windows.Forms.Button();
            this.txtFiltroAvanzado = new System.Windows.Forms.TextBox();
            this.lblFiltroAvanzado = new System.Windows.Forms.Label();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.lblCampo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblValidarCampo = new System.Windows.Forms.Label();
            this.lblValidarFiltroAvanzado = new System.Windows.Forms.Label();
            this.lblValidarCriterio = new System.Windows.Forms.Label();
            this.lblMasDetalles = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCatalogo.Location = new System.Drawing.Point(7, 73);
            this.dgvCatalogo.MultiSelect = false;
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(640, 260);
            this.dgvCatalogo.TabIndex = 0;
            this.dgvCatalogo.SelectionChanged += new System.EventHandler(this.dgvCatalogo_SelectionChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(7, 339);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(88, 339);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(169, 339);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // picArticulos
            // 
            this.picArticulos.Location = new System.Drawing.Point(653, 73);
            this.picArticulos.Name = "picArticulos";
            this.picArticulos.Size = new System.Drawing.Size(246, 213);
            this.picArticulos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArticulos.TabIndex = 5;
            this.picArticulos.TabStop = false;
            this.picArticulos.Click += new System.EventHandler(this.picArticulos_Click);
            this.picArticulos.DoubleClick += new System.EventHandler(this.picArticulos_DoubleClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(68, 47);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(478, 20);
            this.txtBuscar.TabIndex = 6;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscador
            // 
            this.lblBuscador.AutoSize = true;
            this.lblBuscador.Location = new System.Drawing.Point(10, 51);
            this.lblBuscador.Name = "lblBuscador";
            this.lblBuscador.Size = new System.Drawing.Size(52, 13);
            this.lblBuscador.TabIndex = 7;
            this.lblBuscador.Text = "Buscador";
            // 
            // lblMenuPrincipal
            // 
            this.lblMenuPrincipal.AutoSize = true;
            this.lblMenuPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuPrincipal.Location = new System.Drawing.Point(13, 13);
            this.lblMenuPrincipal.Name = "lblMenuPrincipal";
            this.lblMenuPrincipal.Size = new System.Drawing.Size(192, 31);
            this.lblMenuPrincipal.TabIndex = 8;
            this.lblMenuPrincipal.Text = "Menu Principal";
            // 
            // btnCambiarImagen
            // 
            this.btnCambiarImagen.Location = new System.Drawing.Point(653, 310);
            this.btnCambiarImagen.Name = "btnCambiarImagen";
            this.btnCambiarImagen.Size = new System.Drawing.Size(246, 23);
            this.btnCambiarImagen.TabIndex = 9;
            this.btnCambiarImagen.Text = "Cambiar Imagen";
            this.btnCambiarImagen.UseVisualStyleBackColor = true;
            this.btnCambiarImagen.Click += new System.EventHandler(this.cambiarImagen_Click);
            // 
            // txtFiltroAvanzado
            // 
            this.txtFiltroAvanzado.Location = new System.Drawing.Point(452, 379);
            this.txtFiltroAvanzado.Name = "txtFiltroAvanzado";
            this.txtFiltroAvanzado.Size = new System.Drawing.Size(121, 20);
            this.txtFiltroAvanzado.TabIndex = 20;
            // 
            // lblFiltroAvanzado
            // 
            this.lblFiltroAvanzado.AutoSize = true;
            this.lblFiltroAvanzado.Location = new System.Drawing.Point(413, 383);
            this.lblFiltroAvanzado.Name = "lblFiltroAvanzado";
            this.lblFiltroAvanzado.Size = new System.Drawing.Size(35, 13);
            this.lblFiltroAvanzado.TabIndex = 19;
            this.lblFiltroAvanzado.Text = "Filtro: ";
            // 
            // cboCriterio
            // 
            this.cboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(268, 379);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(121, 21);
            this.cboCriterio.TabIndex = 18;
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(220, 383);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(42, 13);
            this.lblCriterio.TabIndex = 17;
            this.lblCriterio.Text = "Criterio:";
            // 
            // cboCampo
            // 
            this.cboCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(80, 379);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(121, 21);
            this.cboCampo.TabIndex = 16;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(34, 384);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(43, 13);
            this.lblCampo.TabIndex = 15;
            this.lblCampo.Text = "Campo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(590, 379);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(121, 21);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblValidarCampo
            // 
            this.lblValidarCampo.AutoSize = true;
            this.lblValidarCampo.Location = new System.Drawing.Point(16, 384);
            this.lblValidarCampo.Name = "lblValidarCampo";
            this.lblValidarCampo.Size = new System.Drawing.Size(0, 13);
            this.lblValidarCampo.TabIndex = 21;
            // 
            // lblValidarFiltroAvanzado
            // 
            this.lblValidarFiltroAvanzado.AutoSize = true;
            this.lblValidarFiltroAvanzado.Location = new System.Drawing.Point(395, 384);
            this.lblValidarFiltroAvanzado.Name = "lblValidarFiltroAvanzado";
            this.lblValidarFiltroAvanzado.Size = new System.Drawing.Size(0, 13);
            this.lblValidarFiltroAvanzado.TabIndex = 22;
            // 
            // lblValidarCriterio
            // 
            this.lblValidarCriterio.AutoSize = true;
            this.lblValidarCriterio.Location = new System.Drawing.Point(207, 383);
            this.lblValidarCriterio.Name = "lblValidarCriterio";
            this.lblValidarCriterio.Size = new System.Drawing.Size(0, 13);
            this.lblValidarCriterio.TabIndex = 23;
            // 
            // lblMasDetalles
            // 
            this.lblMasDetalles.AutoSize = true;
            this.lblMasDetalles.Location = new System.Drawing.Point(663, 51);
            this.lblMasDetalles.Name = "lblMasDetalles";
            this.lblMasDetalles.Size = new System.Drawing.Size(229, 13);
            this.lblMasDetalles.TabIndex = 24;
            this.lblMasDetalles.Text = "Doble click en la imagen para ver mas detalles.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 411);
            this.Controls.Add(this.lblMasDetalles);
            this.Controls.Add(this.lblValidarCriterio);
            this.Controls.Add(this.lblValidarFiltroAvanzado);
            this.Controls.Add(this.lblValidarCampo);
            this.Controls.Add(this.txtFiltroAvanzado);
            this.Controls.Add(this.lblFiltroAvanzado);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCambiarImagen);
            this.Controls.Add(this.lblMenuPrincipal);
            this.Controls.Add(this.lblBuscador);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.picArticulos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvCatalogo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(920, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(920, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestiones Anomalas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCatalogo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox picArticulos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscador;
        private System.Windows.Forms.Label lblMenuPrincipal;
        private System.Windows.Forms.Button btnCambiarImagen;
        private System.Windows.Forms.TextBox txtFiltroAvanzado;
        private System.Windows.Forms.Label lblFiltroAvanzado;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblValidarCampo;
        private System.Windows.Forms.Label lblValidarFiltroAvanzado;
        private System.Windows.Forms.Label lblValidarCriterio;
        private System.Windows.Forms.Label lblMasDetalles;
    }
}

