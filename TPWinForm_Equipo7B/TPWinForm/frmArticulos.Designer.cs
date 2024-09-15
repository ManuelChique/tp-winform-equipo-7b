namespace TPWinForm
{
    partial class frmArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkbVerDetalle = new System.Windows.Forms.CheckBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.btnModificarArticulo = new System.Windows.Forms.Button();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // chkbVerDetalle
            // 
            this.chkbVerDetalle.AutoSize = true;
            this.chkbVerDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbVerDetalle.Location = new System.Drawing.Point(340, 57);
            this.chkbVerDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.chkbVerDetalle.Name = "chkbVerDetalle";
            this.chkbVerDetalle.Size = new System.Drawing.Size(97, 21);
            this.chkbVerDetalle.TabIndex = 26;
            this.chkbVerDetalle.Text = "Ver Detalle";
            this.chkbVerDetalle.UseVisualStyleBackColor = true;
            this.chkbVerDetalle.CheckedChanged += new System.EventHandler(this.chkbVerDetalle_CheckedChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(98, 57);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(200, 20);
            this.txtFiltro.TabIndex = 25;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(442, 58);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(286, 287);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 24;
            this.pbxArticulo.TabStop = false;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.BackColor = System.Drawing.SystemColors.Control;
            this.lblFiltro.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltro.Location = new System.Drawing.Point(8, 53);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(99, 24);
            this.lblFiltro.TabIndex = 23;
            this.lblFiltro.Text = "Buscar : ";
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarArticulo.Location = new System.Drawing.Point(252, 351);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(111, 37);
            this.btnEliminarArticulo.TabIndex = 22;
            this.btnEliminarArticulo.Text = "Eliminar";
            this.btnEliminarArticulo.UseVisualStyleBackColor = true;
            this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
            // 
            // btnModificarArticulo
            // 
            this.btnModificarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarArticulo.Location = new System.Drawing.Point(135, 351);
            this.btnModificarArticulo.Name = "btnModificarArticulo";
            this.btnModificarArticulo.Size = new System.Drawing.Size(111, 37);
            this.btnModificarArticulo.TabIndex = 21;
            this.btnModificarArticulo.Text = "Modificar";
            this.btnModificarArticulo.UseVisualStyleBackColor = true;
            this.btnModificarArticulo.Click += new System.EventHandler(this.btnModificarArticulo_Click);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(18, 351);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(111, 37);
            this.btnAgregarArticulo.TabIndex = 20;
            this.btnAgregarArticulo.Text = "Agregar";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvArticulos.Location = new System.Drawing.Point(18, 101);
            this.dgvArticulos.MultiSelect = false;
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            this.dgvArticulos.RowHeadersWidth = 51;
            this.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArticulos.Size = new System.Drawing.Size(385, 244);
            this.dgvArticulos.TabIndex = 19;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(551, 351);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(95, 37);
            this.btnSiguiente.TabIndex = 27;
            this.btnSiguiente.Text = "Otra Imagen";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click_1);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(442, 351);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(103, 37);
            this.btnAnterior.TabIndex = 28;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click_1);
            // 
            // frmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 447);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.chkbVerDetalle);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnEliminarArticulo);
            this.Controls.Add(this.btnModificarArticulo);
            this.Controls.Add(this.btnAgregarArticulo);
            this.Controls.Add(this.dgvArticulos);
            this.MaximumSize = new System.Drawing.Size(816, 486);
            this.MinimumSize = new System.Drawing.Size(816, 486);
            this.Name = "frmArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmArticulos";
            this.Load += new System.EventHandler(this.frmArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkbVerDetalle;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Button btnEliminarArticulo;
        private System.Windows.Forms.Button btnModificarArticulo;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
    }
}